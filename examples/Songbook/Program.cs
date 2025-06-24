using Songbook;
using Songbook.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options => {
	options.SerializerOptions.TypeInfoResolverChain.Insert(0, SongbookSerializerContext.Default);
});

builder.Services.AddOpenApi();
builder.Services.AddSingleton(new Database());
var app = builder.Build();
if (app.Environment.IsDevelopment()) app.MapOpenApi();

app.MapGet("/", Html.Index);

app.MapGet("/artists", (Database db) => db.Artists);
app.MapGet("/artists/{name}/tracks", (string name, Database db) => db.ListTracksByArtist(name));
app.MapGet("/tracks", (Database db) => db.Artists.SelectMany(a => a.Tracks).ToList());

app.Run();

[JsonSerializable(typeof(Artist))]
[JsonSerializable(typeof(Track))]
[JsonSerializable(typeof(List<Artist>))]
[JsonSerializable(typeof(List<Track>))]
internal partial class SongbookSerializerContext : JsonSerializerContext {

}
