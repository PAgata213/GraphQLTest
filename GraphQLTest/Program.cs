using GraphQLTest.Components;
using GraphQLTest.Context;
using GraphQLTest.GQL.Comments;
using GraphQLTest.GQL.Posts;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents()
		.AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(o =>
{
	o.UseNpgsql(builder.Configuration.GetConnectionString("GraphQLDB"));
});

builder.Services
		.AddGraphQLServer()
		.AddQueryType()
		.AddType<CommentsQuery>()
		.AddType<PostsQuery>()
		.AddMutationType()
		.AddType<PostMutations>()
		.AddType<CommentMutations>()
		.AddFiltering()
		.AddSorting()
		.AddProjections();

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	await dbContext.Database.MigrateAsync();
	if(!await dbContext.Posts.AnyAsync())
	{
		await SeedData.SeedDataToDBAsync(dbContext);
	}
}

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.MapGraphQL("/graphql");

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
		.AddInteractiveServerRenderMode()
		.AddInteractiveWebAssemblyRenderMode()
		.AddAdditionalAssemblies(typeof(GraphQLTest.Client._Imports).Assembly);

app.Run();
