using Autofac;
using Mc2.DBProjection;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder =>
    autofacBuilder.RegisterModule(new ProjectionModule()));
var app = builder.Build();



app.Run();