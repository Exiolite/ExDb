using System.Collections.Generic;
using System.Linq;

namespace ExNoSQL
{
    public sealed class Repository<T> where T : Entity
    {
        public List<T> Content { get; set; } = new List<T>();
        public List<T> Cache { get; set; } = new List<T>();
        
        
        public void Add(T input)
        {
            Content.Add(input);
            Cache.Add(input);
        }

        public T Get(T input)
        {
            if (Cache.Exists(o => o.Id == input.Id))
            {
                return Cache.FirstOrDefault(o => o.Id == input.Id);
            }


            T contentEntity = Content.FirstOrDefault(o => o.Id == input.Id);
            Cache.Add(contentEntity);
            return contentEntity;
        }
        
        public List<T> GetAll()
        {
            return Content;
        }
        
        public void Delete(T input)
        {
            if (Content.Exists(o => o.Id == input.Id)) ;
            Content.Remove(Content.FirstOrDefault(o => o.Id == input.Id));
        }
    }
}