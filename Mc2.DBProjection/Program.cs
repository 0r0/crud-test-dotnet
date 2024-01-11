using Autofac;
using Autofac.Extensions.DependencyInjection;
using Mc2.DBProjection;
using Neo4j.Driver;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Services.Configure<ApplicationSettings>(builder.Configuration.GetSection("ApplicationSettings"));
var settings = new ApplicationSettings();
builder.Configuration.GetSection("ApplicationSettings").Bind(settings);
builder.Services.AddSingleton(GraphDatabase.Driver(settings.Neo4jConnection,
    AuthTokens.Basic(settings.Neo4jUser, settings.Neo4jPassword)));

builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder =>
    autofacBuilder.RegisterModule(new ProjectionModule(settings)));
var app = builder.Build();


app.Run();