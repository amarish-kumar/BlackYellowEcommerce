using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Core.Domain.Interfaces
{
    public interface IDomainEvent
    { 
        int Versao { get; }
        DateTime DataOcorrencia { get; }
    }
}
