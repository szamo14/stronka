using System;

namespace Evento.Core.Domain
{
    public abstract class Entity
    {
        public Guid ID {get; protected set;}

        protected Entity()
        {
            ID= Guid.NewGuid();            
        }

    }
} 