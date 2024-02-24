using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Contracts.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        IBookRepository BookRepository { get; }

        Task Save(CancellationToken cancellationToken);
    }
}
