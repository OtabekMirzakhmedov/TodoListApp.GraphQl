using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;
using TodoListApp.GraphQl.Data;
using TodoListApp.GraphQl.GraphQL;
using TodoListApp.GraphQl.GraphQL.Lists;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPooledDbContextFactory<ApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoListGraphQL"));
});

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<TodoListApp.GraphQl.GraphQL.Lists.ListType>()
    .AddProjections()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

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

app.UseRouting();

app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});


app.Run();
