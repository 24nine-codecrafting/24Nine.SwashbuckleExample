using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.v1_0;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1_0
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")] // the v{version:apiVersion} must be added to comply to the querystring/url search mechanism of the versioning for swagger.
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Product> _productList;

        public ProductsController()
        {
            _productList = new List<Product>
            {
                new Product(Guid.NewGuid(), "Roomkaas", "zuivel"),
                new Product(Guid.NewGuid(), "Salami", "vleeswaren")
            };
        }

        /// <summary>
        /// some xml documentation for the products get method
        /// </summary>
        /// <returns></returns>
        // GET: api/<ProductsController>
        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), 200)] //States the returntype of the succeeded object, swagger will use this for craeting the response example.
        [ProducesResponseType(typeof(string), 400)]
        [MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            return Ok(_productList);
        }


        /// <summary>
        /// returns the product by id xml comment...
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<ProductsController>/5
        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Product), 200)] //States the returntype of the succeeded object, swagger will use this for craeting the response example.
        [ProducesResponseType(typeof(string), 400)]
        [MapToApiVersion("1.0")]
        public IActionResult Get(Guid id)
        {
            var result = _productList.FirstOrDefault(_ => _.Id == id);

            if (result == null)
                return NotFound($"no object found with id: {id}");

            return Ok(result);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [MapToApiVersion("1.0")] // you'll have to map the methods to all the versions in which the given method will be visible, without having to rewrite it in the new version.
        [MapToApiVersion("2.0")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [MapToApiVersion("1.0")] // you'll have to map the methods to all the versions in which the given method will be visible, without having to rewrite it in the new version.
        [MapToApiVersion("2.0")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")] // you'll have to map the methods to all the versions in which the given method will be visible, without having to rewrite it in the new version.
        [MapToApiVersion("2.0")]
        public void Delete(int id)
        {
        }
    }
}
