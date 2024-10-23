using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

using GraphQLTest.Client.GQL;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IGraphQLClient>(_ =>
{
	var client = new GraphQLHttpClient($"{builder.HostEnvironment.BaseAddress}graphql/", new NewtonsoftJsonSerializer());
	client.HttpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));
	return client;
});
builder.Services.AddScoped<IPostsGQLService, PostsGQLService>();

await builder.Build().RunAsync();