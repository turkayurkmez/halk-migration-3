namespace minimalAPISample
{
    public interface IProductService
    {
        int CreateProduct(CreateProductDto createProductRequest);
        ProductDisplayDto GetProduct(int id);
        IEnumerable<ProductDisplayDto> GetProducts();
        IEnumerable<ProductDisplayDto> SearchByName(string name);
    }
}