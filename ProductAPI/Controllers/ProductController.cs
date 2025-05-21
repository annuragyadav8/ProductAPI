using DtosLayer;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer;

namespace ProductAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("GetProducts")]
        public ActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult AddProduct([FromBody] ProductClass product)
        {
            return Ok(_productService.AddProduct(product));
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public ActionResult UpdateProduct([FromBody] ProductClass product)
        {
            return Ok(_productService.UpdateProduct(product));
        }

        [HttpPost]
        [Route("DeleteProduct/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            return Ok(_productService.DeleteProduct(id));
        }

        [HttpGet]
        [Route("GetProductData/{id}")]
        public ActionResult GetProductData(int id)
        {
            return Ok(_productService.GetProduct(id));
        }
    }
}

