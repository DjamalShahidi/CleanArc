using Demo.Api.Middleware;
using Demo.Application;
using Demo.Persistence;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.ConfigureApplicationServices()
                .ConfigurePersistenceServices(configuration);

builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .Build();
    });
});


//services.AddCors(options =>
//{
//    options.AddPolicy("EnableCORS", builder =>
//    {
//        builder
//            .WithOrigins("http://example.com") // ??????? ????
//            .WithMethods("GET", "POST") // ??????? ???
//            .WithHeaders("Content-Type"); // ??????? ???
//    });
//});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
