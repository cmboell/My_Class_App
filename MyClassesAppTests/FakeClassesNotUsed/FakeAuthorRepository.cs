using My_Classes_App.Models;
using System;
using System.Collections.Generic;

namespace My_Classes_App.Tests
{
    class FakeAuthorRepository : IRepository<Teacher>
    {
        public void Update(Teacher entity) { }  // does nothing
        public void Save() { }  // does nothing

        public int Count => throw new NotImplementedException();

        public void Delete(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public Teacher Get(QueryOptions<Teacher> options)
        {
            throw new NotImplementedException();
        }

        public Teacher Get(int id)
        {
            throw new NotImplementedException();
        }

        public Teacher Get(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> List(QueryOptions<Teacher> options)
        {
            throw new NotImplementedException();
        }
    }
}
