using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;

using GraphQLTest.Client.GraphQL;

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IGraphQLClient>(_ => new GraphQLHttpClient(builder.HostEnvironment.BaseAddress, new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<IPostsGQLService, PostsGQLService>();

await builder.Build().RunAsync();