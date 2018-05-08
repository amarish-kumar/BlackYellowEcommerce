using System;
using BlackYellow.Core.Domain.Commands;

namespace BlackYellow.Core.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
