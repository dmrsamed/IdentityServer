using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Routing.Matching;

var builder = WebApplication.CreateBuilder(args);

//Burada sistemlere göre şema değiştirmek gerek, normal üye, bayi üye gibi.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    JwtBearerDefaults.AuthenticationScheme,
    opt =>
    {
        opt.Authority = "https://localhost:7000"; //Acces Tokeni Yayınlayan Kim
        opt.Audience = "iq_api"; //Benden veri alacak kişi kimdir Örneğin IQApi
    });
//Policylerimizi tanımlıyoruz
builder.Services.AddAuthorization(opts =>
    {
        opts.AddPolicy("ReadProduct", policy => { policy.RequireClaim("scope", "iqapi.read"); });
        opts.AddPolicy("UpdateOrCreate", policy => { policy.RequireClaim("scope", new[] {"iqapi.update", "iqapi.write"}); });
        
    }
);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();