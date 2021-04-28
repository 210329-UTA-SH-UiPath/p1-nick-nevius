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
    public class ToppingController : ControllerBase
    {

        private readonly IRepository<ATopping> repo;

        public ToppingController(IRepository<ATopping> repo)
        {
            this.repo = repo;
        }

        // GET: api/<ToppingController>
        [HttpGet]
        public IEnumerable<ATopping> Get()
        {
            return repo.GetList();
        }

        // GET api/<ToppingController>/5
        [HttpGet("{id}")]
        public ATopping Get(int id)
        {
            return repo.GetById(id);
        }

        // POST api/<ToppingController>
        [HttpPost]
        public void Post([FromBody] ATopping value)
        {
            repo.Add(value);
        }

        // PUT api/<ToppingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ATopping value)
        {
            value.ID = id;
            repo.Update(value);
        }

        // DELETE api/<ToppingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Remove(id);
        }
    }
}
