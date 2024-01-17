namespace WhatsNewInASPNetSix.Services
{
    public class AlternateProductService : IProductService
    {
        public List<string> GetProductNames()
        {
            return new List<string>() { "X", "Y", "Z" };
        }
    }
}
