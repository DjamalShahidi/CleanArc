using Serilog;
using System.Data;
using Serilog.Exceptions;
using Serilog.Enrichers.Span;
using Serilog.Formatting.Json;
using Serilog.Sinks.MSSqlServer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace CleanArc.Infrastructure.CrossCutting.Logging
{
    public static class LoggingConfiguration
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogger => (context, configuration) =>
        {
            #region Enriching Logger Context

            var env = context.HostingEnvironment;

            configuration.Enrich.FromLogContext()
                         .Enrich.WithProperty("ApplicationName", env.ApplicationName)
                         .Enrich.WithProperty("Environment", env.EnvironmentName)
                         .Enrich.WithSpan()
                         .Enrich.WithExceptionDetails();
            #endregion


            var columnOpts = new ColumnOptions();
            columnOpts.Store.Remove(StandardColumn.Properties);
            columnOpts.Store.Add(StandardColumn.LogEvent);
            columnOpts.LogEvent.DataLength = 4096;
            columnOpts.PrimaryKey = columnOpts.Id;
            columnOpts.Id.DataType = SqlDbType.Int;

            if (!context.HostingEnvironment.IsDevelopment())
            {
                configuration.WriteTo
                    .MSSqlServer(
                        connectionString: context.Configuration.GetConnectionString("SqlServer"),
                        sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true, SchemaName = "log" })
                    .MinimumLevel.Warning();
            }
            else
            {
                configuration.WriteTo.Console().MinimumLevel.Information();
                configuration.WriteTo.File(new JsonFormatter(), "logs/log.json").MinimumLevel.Information();
            }
        };
    }
}
