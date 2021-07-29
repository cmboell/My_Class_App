using System.Collections.Generic;

namespace My_Classes_App.Models
{
    public interface IClass
    {
        void Load(IRepository<Class> data);
        double Subtotal { get; }
        int? Count { get; }
        IEnumerable<ClassItem> List { get; }
        ClassItem GetById(int id);
        void Add(ClassItem item);
        void Edit(ClassItem item);
        void Remove(ClassItem item);
        void Clear();
        void Save();
    }
}