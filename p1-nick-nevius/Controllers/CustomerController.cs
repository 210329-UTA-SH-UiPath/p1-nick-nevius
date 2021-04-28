using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p1_nick_nevius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<PizzaBox.Domain.Models.Customer> repo;

        public CustomerController(IRepository<PizzaBox.Domain.Models.Customer> repo)
        {
            this.repo = repo;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public List<PizzaBox.Domain.Models.Customer> Get()
        {
            return repo.GetList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public PizzaBox.Domain.Models.Customer Get(int id)
        {
            return repo.GetById(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] PizzaBox.Domain.Models.Customer customer)
        {
            repo.Add(customer);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PizzaBox.Domain.Models.Customer customer)
        {
            customer.ID = id;
            repo.Update(customer);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Remove(id);
        }
    }
}
