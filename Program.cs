using IdentityUserCustom.Datas;
using IdentityUserCustom.Models;
using IdentityUserCustom.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<VerifyMeService>(client =>
{
    client.BaseAddress = new Uri("https://vapi.verifyme.ng/v1/verifications/identities");
});
builder.Services.AddScoped<VerifyMeService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer
(
    builder.Configuration.GetConnectionString("ConnectionLink")
    ));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<UserData>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = long.MaxValue;
});

var app = builder.Build();

app.MapIdentityApi<UserData>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
