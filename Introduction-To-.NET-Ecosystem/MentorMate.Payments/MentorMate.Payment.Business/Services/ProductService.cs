namespace MentorMate.Payment.Business.Services
{
    using Newtonsoft.Json;
    using MentorMate.Payment.Business.Models;
    using System.Reflection;

    public class ProductService : IProductService
    {
        private const string JSON_PATH = "/Datasets/products.json";

        public ICollection<Product> GetProducts()
        {
            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = buildDir + JSON_PATH;

            var jsonString = JSONReader.ReadJsonFile(filePath);

            if (jsonString != null)
            {
                var products = JsonConvert.DeserializeObject<List<Product>>(jsonString);
                return products;
            }
            else
            {
                throw new Exception("Products file is empty.");
            }
        }
    }
}
