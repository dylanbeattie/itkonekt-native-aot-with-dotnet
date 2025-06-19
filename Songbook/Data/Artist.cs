using System.Text.Json.Serialization;

namespace Songbook.Data;
public class Artist(string name) {
	public string Name { get; } = name;
	public Artist(string name, params string[] trackNames) : this(name) {
		this.Tracks = [.. trackNames.Select(t => new Track(this, t))];
	}

	[JsonIgnore]
	public List<Track> Tracks { get; init; } = [];
}

public class Database {
	public List<Artist> Artists { get; } = [
		new("AC/DC", "Highway to Hell", "Thunderstruck", "Back in Black"),
		new("Bon Jovi", "Livin' on a Prayer", "Bad Medicine", "Wanted Dead Or Alive"),
		new("Def Leppard", "Animal", "Rocket", "Let's Get Rocked", "Hysteria"),
		new("Vixen", "Rev It Up", "Edge Of A Broken Heart", "Love Is A Killer")
	];

	public List<Track> ListTracksByArtist(string name) {
		var artist = this.Artists.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
		return artist?.Tracks ?? [];
	}
}
