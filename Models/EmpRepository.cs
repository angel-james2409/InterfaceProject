using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class EmpRepository:IEmpRepository
    {
        private List<Emp> emps = new List<Emp>();
        private int _nextId = 1;
        public EmpRepository()
        {
            Add(new Emp { Name = "jeni",Location="chennai" });
            Add(new Emp { Name = "cha", Location = "dubai" });
            Add(new Emp { Name = "mike", Location = "chennai" });
        }
        public IEnumerable<Emp> GetAll()
        {
            return emps;
        }
        public Emp Get(int id)
        {
            return emps.Find(e => e.Id == id);
        }

        public Emp Add(Emp item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            emps.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            emps.RemoveAll(e => e.Id == id);
        }

        public bool Update(Emp item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = emps.FindIndex(e => e.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            emps.RemoveAt(index);
            emps.Add(item);
            return true;
        }

        Product IEmpRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        Product IEmpRepository.Add(Emp item)
        {
            throw new NotImplementedException();
        }
    }
}




