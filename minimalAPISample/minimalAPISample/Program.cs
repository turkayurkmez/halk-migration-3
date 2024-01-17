using minimalAPISample;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
 * Minimal api'de controller yok. Dolayısıyla Action ve doğal olarak Filter yok.
 * O zaman, MapXXX (GET, POST, PUT vs) ile request'i yönlendirmeniz gerekecek. Yani MapXXX fonksiyonlarının, request delegate parametresi, ProductService gibi instance'ları parametre olarak almalı.
 */
builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/products", (IProductService productService) => productService.GetProducts());

app.MapGet("/products/search/{name}", (string name, IProductService productService) => productService.SearchByName(name));

app.MapGet("/products/details/{id}", (int id, IProductService productService) => productService.GetProduct(id));

app.MapPost("/products", (IProductService productService, CreateProductDto createRequest) =>
{
    var id = productService.CreateProduct(createRequest);
    return Results.Created($"/products/details/{id}", id);
});





app.Run();

