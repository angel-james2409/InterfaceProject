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
    public class ProductController : ControllerBase

    {
        static readonly IProductRepository repository = new ProductRepository();
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            return repository.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        // POST api/<ProductController>
        [HttpPost]
        public string PostProduct(Product item)
        {
            item = repository.Add(item);
            return "added sucessfully";
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void PutProduct(int id,Product product)
        {
            product.Id = id;
            if (!repository.Update(product))
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
