﻿using JP_Devolupment.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace JP_Devolupment.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}