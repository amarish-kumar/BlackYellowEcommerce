using BlackYellow.Authetication.Data.Context;
using BlackYellow.Core.Domain.Commands;
using BlackYellow.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authetication.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerEFContext _context;

        public UnitOfWork(CustomerEFContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
