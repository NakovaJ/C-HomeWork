using System;
using System.Collections.Generic;
using System.Text;
using TImeTracking.Domain.Core.Interfaces;

namespace TImeTracking.Domain.Core.Entities
{
    public abstract class BaseEntity : IBaseEntity
    {
        public abstract void Print();
        
    }
}
