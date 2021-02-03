using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoparkWeb.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList(); // get list of items
        T Get(int id); // get one item by id
        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}
