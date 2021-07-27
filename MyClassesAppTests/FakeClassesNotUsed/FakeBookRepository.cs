using My_Classes_App.Models;
using System;
using System.Collections.Generic;

namespace My_Classes_App.Tests
{
    class FakeBookRepository : IRepository<Class>
    {
        public int Count => throw new NotImplementedException();
        public void Delete(Class entity) => throw new NotImplementedException();
        public Class Get(QueryOptions<Class> options) => new Class();  // returns a new Class object

        public Class Get(int id)
        {
            throw new NotImplementedException();
        }

        public Class Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Class entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> List(QueryOptions<Class> options)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Class entity)
        {
            throw new NotImplementedException();
        }
    }
}
