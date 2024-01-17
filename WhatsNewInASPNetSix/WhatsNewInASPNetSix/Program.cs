using WhatsNewInASPNetSix.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureHostOptions(o => o.ShutdownTimeout = TimeSpan.FromSeconds(60));

//var builder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    EnvironmentName = Environments.Staging,
//    WebRootPath = "yeniwwwroot"
//});


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(opt => opt.IdleTimeout = TimeSpan.FromMinutes(5));

//Sadece bir instance al. Hiç yok etme:
//builder.Services.AddSingleton<IProductService, ProductService>();
//builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddScoped<IProductService, AlternateProductService>();

var info = builder.Configuration.GetConnectionString("myValue");
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Configuration.AddIniFile("appsetting.ini");

//builder.Logging.AddJsonConsole();
var app = builder.Build();

var productService = app.Services.GetRequiredService<IProductService>();
app.Logger.LogInformation($"IoC'ye kaydedilen nesne {productService.GetType().Name}\nicerdigi bilgi:{string.Join(",", productService.GetProductNames().ToArray())}");


app.Logger.LogInformation($" DİKKAT!! Ortam değeri: {info} ");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //entity framework migrations sırasında veya DbContext nesnesinden kaynaklanan hatalar nedeniyle özelleşmiş hata sayfaları aracılığıyla, bu hataları handle ediyoruz.
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



//.net 3.1 ve .net 5.0
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/test", () => "Bu bir test adresidir");
//});

app.MapGet("/test", () => "Bu bir test adresidir");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
