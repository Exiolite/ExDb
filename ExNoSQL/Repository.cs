using System;
using System.Collections.Generic;
using System.Linq;

namespace ExNoSQL
{
    [Serializable]
    public class Repository<T> where T : Entity
    {
        public List<T> Content { get; set; } = new List<T>();

        
        public T GetOrCreate(Func<T, bool> predicate, T input)
        {
            T entity = Content.FirstOrDefault(predicate);

            return entity ?? Insert(input);
        }

        public T Insert(T entity)
        {
            Content.Add(entity);

            return entity;
        }

        public bool TryGet(T input, out T entity)
        {
            entity = null;

            entity = Content.FirstOrDefault(o => o.Id == input.Id);

            return entity != null;
        }

        public bool TryGet(Func<T, bool> predicate, out T entity)
        {
            entity = Content.FirstOrDefault(predicate);

            return entity != null;
        }

        public List<T> GetAll()
        {
            return new List<T>(Content);
        }

        public bool Exists(Predicate<T> match)
        {
            return Content.Exists(match);
        }

        public bool TryDelete(T input)
        {
            input = Content.FirstOrDefault(o => o.Id == input.Id);

            if (input == null) return false;

            Content.Remove(input);

            return true;
        }
    }
}
