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
    public class StoreController : ControllerBase
    {
        private readonly IRepository<AStore> repo;

        public StoreController(IRepository<AStore> repo)
        {
            this.repo = repo;
        }

        // GET: api/<StoreController>
        [HttpGet]
        public IEnumerable<AStore> Get()
        {
            return repo.GetList();
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public AStore Get(int id)
        {
            return repo.GetById(id);
        }

        // POST api/<StoreController>
        [HttpPost]
        public void Post([FromBody] AStore value)
        {
            repo.Add(value);
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AStore value)
        {
            value.ID = id;
            repo.Update(value);
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Remove(id);
        }
    }
}
