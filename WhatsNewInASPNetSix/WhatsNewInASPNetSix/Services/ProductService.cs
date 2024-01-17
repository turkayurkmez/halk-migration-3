namespace WhatsNewInASPNetSix.Services
{
    public class ProductService : IProductService
    {
        public List<string> GetProductNames()
        {
            return new List<string>() { "A", "B", "C" };
        }
    }
}
