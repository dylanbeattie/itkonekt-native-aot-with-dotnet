using System.Net.Mime;

namespace Songbook;

public static class Html {
	private static IResult Template(string title, string body)
		=> Results.Text($"""
	<!DOCTYPE html>
	<html>
	<head><title>{title}</title></head>
	<body>{body}
	<footer>
	Songbook running on {Environment.MachineName} at {DateTime.Now:O}
	</footer>
	</body>
	</html>
""", contentType: "text/html");

	public static IResult Index(HttpContext context) =>	Template("Songbook API", """
		<p>Welcome to the Songbook API</p>
		<ul>
			<li><a href="/artists">/artists</a></li>
			<li><a href="/tracks">/tracks</a></li>
		</ul>
	""");
}
