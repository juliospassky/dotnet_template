using System.Reflection;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Repository;
using Infrastructure.Repository.Config;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().ConfigureApiBehaviorOptions(o => o.SuppressMapClientErrors = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ArcSensedia - Api",
        Version = "v1",
        Description = "ArcSensedia"
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// builder.Services.AddMvc(o =>
//     {
//         o.EnableEndpointRouting = false;
//         o.Filters.Add<ValidationFilter>();
//     })
//     .ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; })
//     .AddFluentValidation(options =>
//     {
//         options.ImplicitlyValidateChildProperties = true;
//         options.ImplicitlyValidateRootCollectionElements = true;
//         options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
//     });

builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection("MongoDb"));
builder.Services.AddSingleton<ITodoService, TodoService>();
builder.Services.AddSingleton<ITodoRepository, TodoRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
