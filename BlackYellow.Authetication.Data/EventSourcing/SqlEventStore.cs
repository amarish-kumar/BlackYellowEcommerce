using BlackYellow.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authetication.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        //private readonly IEventStoreRepository _eventStoreRepository;
        //private readonly IUser _user;

        public SqlEventStore()
        {
            //_eventStoreRepository = eventStoreRepository;
           // _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
           
        }
    }
}
