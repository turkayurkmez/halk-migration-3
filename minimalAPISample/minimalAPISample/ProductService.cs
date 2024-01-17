using System.Xml.Linq;

namespace minimalAPISample
{
    public record ProductDisplayDto(int Id, string Name, decimal Price);
    public record CreateProductDto(string Name, decimal Price);

    public class ProductService : IProductService
    {
        private List<ProductDisplayDto> products = new List<ProductDisplayDto>()
            {
                new (Id:1, Name:"Product1 ", Price: 100),
                new (Id:2, Name:"Product2 ", Price: 150),
                new (Id:3, Name:"Product3 ", Price: 160),


            };
        public IEnumerable<ProductDisplayDto> GetProducts()
        {
            return products;
        }

        public ProductDisplayDto GetProduct(int id) => products.FirstOrDefault(p => p.Id == id);

        public IEnumerable<ProductDisplayDto> SearchByName(string name) => products.Where(p => p.Name.Contains(name));

        public int CreateProduct(CreateProductDto createProductRequest)
        {
            var lastId = products.Last().Id + 1;
            var newProduct = new ProductDisplayDto(lastId, createProductRequest.Name, createProductRequest.Price);
            products.Add(newProduct);

            return lastId;

        }

    }
}
