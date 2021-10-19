using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftStoreAutoparts.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftStoreAutoparts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    public class TestClassModelsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TestClassModelsController(ApplicationDbContext dbContext)
        {
            this.context = dbContext;
        }

        // GET: api/<TestClassModelsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<TestClassModelsController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TestClassModelsController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<TestClassModelsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<TestClassModelsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //**********************
        [HttpGet]
        public IEnumerable<TestClassModel> Get()
        {
            //return dbContext.Paises.Include(x => x.Provincias).ToList();
            return context.TestClassModel.ToList();
        }

        [HttpGet("{id:long}", Name = "TestClassModelCreado")]
        public IActionResult GetById(long id)
        {
            var test = context.TestClassModel.FirstOrDefault(x => x.Id == id);
            //var pais = context.TestClassModel.Include(x => x.te).FirstOrDefault(x => x.Id == id);
            if (test == null)
                return NotFound();
            else
                return Ok(test);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TestClassModel test)
        {
            if (ModelState.IsValid)
            {
                context.TestClassModel.Add(test);
                context.SaveChanges();
                return new CreatedAtRouteResult("TestClassModelCreado", new { test.Id }, test);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id:long}")]
        public IActionResult Put([FromBody] TestClassModel test, long id)
        {
            if (test.Id != id)
                return BadRequest();

            context.Entry(test).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var test = context.TestClassModel.FirstOrDefault(x => x.Id == id);
            if (test == null)
                return NotFound();

            context.TestClassModel.Remove(test);
            context.SaveChanges();
            return Ok();
        }
    }
}
