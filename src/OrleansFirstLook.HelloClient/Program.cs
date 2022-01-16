// See https://aka.ms/new-console-template for more information
using Orleans;
using OrleansFirstLook.Common;

Console.WriteLine("Hello, World!");

var client = new ClientBuilder()
    .UseLocalhostClustering()
    .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(IHelloGrain).Assembly).WithReferences())
    .Build();

await client.Connect();

string reply = await client.GetGrain<IHelloGrain>("friend").SayHello("Good morning!");
Console.WriteLine($"\n\n{reply}\n\n");
