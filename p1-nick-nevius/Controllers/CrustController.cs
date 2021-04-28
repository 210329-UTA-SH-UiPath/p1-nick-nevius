using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain.Abstracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace p1_nick_nevius.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrustController : ControllerBase
    {

        private readonly IRepository<ACrust> repo;

        public CrustController(IRepository<ACrust> repo)
        {
            this.repo = repo;
        }

        // GET: api/<CrustController>
        [HttpGet]
        public IEnumerable<ACrust> Get()
        {
            return repo.GetList();
        }

        // GET api/<CrustController>/5
        [HttpGet("{id}")]
        public ACrust Get(int id)
        {
            return repo.GetById(id);
        }

        // POST api/<CrustController>
        [HttpPost]
        public void Post([FromBody] ACrust value)
        {
            repo.Add(value);
        }

        // PUT api/<CrustController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ACrust value)
        {
            value.ID = id;
            repo.Update(value);
        }

        // DELETE api/<CrustController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Remove(id);
        }
    }
}
