using System;

namespace ExNoSQL
{
    [Serializable]
    public abstract class Entity
    {
        public Guid Id { get; set; }

        
        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
