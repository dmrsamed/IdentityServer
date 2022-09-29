using Identity.MobilApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(Config.GetApiResource())
    .AddInMemoryApiScopes(Config.GetApiScope())
    .AddInMemoryClients(Config.GetClient())
    .AddDeveloperSigningCredential(); //Localde bir Public ve private key oluşturur

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();