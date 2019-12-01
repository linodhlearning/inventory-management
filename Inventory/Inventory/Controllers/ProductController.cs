using System.Collections.Generic;
using Inventory.Service;
using Inventory.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Inventory.Infrastructure.DTO;
namespace Inventory.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IServiceCoordinator _service;
        //public ProductController()
        //{
        //    string connectionString = "";//todo use IOC later
        //   // this._service = new ServiceCoordinator(connectionString);
        //}

        public ProductController(Infrastructure.Entities.InventoryContext context)
        {
            this._service = new ServiceCoordinator(context);
            //this._service = service;
        }

        // GET api/values
        [HttpGet]
        [Route("api/products")] 
        public ActionResult<IEnumerable<ProductDTO>> GetAll()
        {
            var products = this._service.Product.GetActiveProducts();
            return Ok(products);
            //return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("List")]
        public ActionResult<IEnumerable<string>> Add()
        {
            return new string[] { "value1", "value2" };
        }
    }
}