using Catalog.API.Data;
using Catalog.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura��es de servi�os
//builder.Services.AddDbContext<AlunoContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPostgres"));
//});

//var builder = WebApplication.CreateBuilder(args);

//var app = builder.Build();


builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllers(); // Removido AddControllersWithViews e AddMvc
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Configura��o do Swagger para documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��es do pipeline de execu��o
var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=}/{action=}/{id?}");

    endpoints.MapControllers();
});

app.Run();
