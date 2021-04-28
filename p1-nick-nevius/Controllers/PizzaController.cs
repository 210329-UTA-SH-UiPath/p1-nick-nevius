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
    public class PizzaController : ControllerBase
    {


       private readonly IRepository<APizza> repo;

        public PizzaController(IRepository<APizza> repo)
        {
            this.repo = repo;
        }

        // GET: api/<PizzaController>
        [HttpGet]
        public IEnumerable<APizza> Get()
        {
            return repo.GetList();
        }

        // GET api/<PizzaController>/5
        [HttpGet("{id}")]
        public APizza Get(int id)
        {
            return repo.GetById(id);
        }

        // POST api/<PizzaController>
        [HttpPost]
        public void Post([FromBody] APizza value)
        {
            repo.Add(value);
        }

        // PUT api/<PizzaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] APizza value)
        {
            value.ID = id;
            repo.Update(value);
        }

        // DELETE api/<PizzaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.Remove(id);
        }
    }
}
