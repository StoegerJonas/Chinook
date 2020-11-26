using System;

namespace Chinook.ConApp
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Chinook-Marketing!");

			var genres = Logic.Factory.GetAllGenres();
			var artists = Logic.Factory.GetAllArtists();
			var albums = Logic.Factory.GetAllAlbums();

			var artistStatistics = Report.MarketingReports.GetArtistStatistics();
		}
	}
}
