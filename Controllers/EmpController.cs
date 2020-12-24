using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        static readonly IEmpRepository repository = new EmpRepository();
        // GET: api/<EmpController>
        [HttpGet]
        public IEnumerable<Emp> GetAllEmp()
        {
            return repository.GetAll();
        }


        // GET api/<EmpController>/5
        [HttpGet("{id}")]
        public Emp GetEmp(int id)
        {
            Emp item = repository.Get(id);
            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        // POST api/<EmpController>
        [HttpPost]
        public string PostEmp(Emp item)
        {
            item = repository.Add(item);
            return "added sucessfully";
        }


        // PUT api/<EmpController>/5
        [HttpPut("{id}")]
        public void PutEmp(int id, Emp emps)
        {
            emps.Id = id;
            if (!repository.Update(emps))
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/<EmpController>/5
        [HttpDelete("{id}")]
        public void DeleteEmp(int id)
        {
            Emp item = repository.Get(id);
            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}