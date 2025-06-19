using Songbook.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddSingleton(new Database());
var app = builder.Build();
if (app.Environment.IsDevelopment()) app.MapOpenApi();

// app.MapGet("/", () => new {
// 	_links = new {
// 		artists = new { href = "/artists" },
// 		tracks = new { href = "/tracks" }
// 	},
// 	message = "Songbook API"
// });
app.MapGet("/foo/{bar}", (string bar) => bar);
app.MapGet("/artists", (Database db) => db.Artists);
app.MapGet("/artists/{name}/tracks", (string name, Database db) => db.ListTracksByArtist(name));
app.MapGet("/tracks", (Database db) => db.Artists.SelectMany(a => a.Tracks));

app.Run();
