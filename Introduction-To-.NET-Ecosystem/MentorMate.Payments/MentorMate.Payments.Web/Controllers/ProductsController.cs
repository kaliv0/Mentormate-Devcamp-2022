namespace MentorMate.Payments.Web.Controllers
{
    using System.Text;
    using Microsoft.AspNetCore.Mvc;
    using MentorMate.Payment.Business.Services;

    [ApiController]
    [Route("/")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(Name = "GetProducts")]
        public ActionResult<string> GetProducts()
        {
            var products = _productService.GetProducts();

            var sb = new StringBuilder();

            foreach (var product in products)
            {
                sb.AppendLine($"{product.Id}. {product.Name} - {product.Description} - ${product.Price}");
            }

            return sb.ToString();
        }
    }
}
