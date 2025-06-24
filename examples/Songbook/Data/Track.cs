namespace Songbook.Data;

public class Track(Artist artist, string title) {
	public Artist Artist { get; } = artist;
	public string Title { get; } = title;
}
