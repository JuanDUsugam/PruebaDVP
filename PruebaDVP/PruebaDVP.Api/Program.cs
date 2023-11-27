using PruebaDVP.Infra;
using PruebaDVP.Application;
using PruebaDVP.Api.Middleares;
using PruebaDVP.Infra.Persistence.SQLSever.Context;
using PruebaDVP.Infra.Persistence.SQLSever.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.MapControllers();

using(var scoped = app.Services.CreateScope())
{
    var services = scoped.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        await LoadDataBase.InsertData(context);
    }
    catch (Exception ex)
    {

        throw;
    }
}


app.Run();

