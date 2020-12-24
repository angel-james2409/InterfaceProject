using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public interface IEmpRepository
    {
        IEnumerable<Emp> GetAll();
    Product Get(int id);
    Product Add(Emp item);
    void Remove(int id);
    bool Update(Emp item);

     }
}
