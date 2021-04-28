using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p1_nick_nevius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {

        private readonly IRepository<ASize> repo;

        public SizeController(IRepository<ASize> repo)
        {
            this.repo = repo;
        }

        // GET: api/<SizeController>
        [HttpGet]
        public IEnumerable<ASize> Get()
        {
            return repo.GetList();
        }

        // GET api/<SizeController>/5
        [HttpGet("{id}")]
        public ASize Get(int id)
        {
            return repo.GetById(id);
        }

        // POST api/<SizeController>
        [HttpPost]
        public void Post([FromBody] ASize value)
        {
            repo.Add(value);
        }

        // PUT api/<SizeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ASize value)
        {
            value.ID = id;
            repo.Update(value);
        }

        // DELETE api/<SizeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Remove(id);
        }
    }
}
