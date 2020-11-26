using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Report
{
	public class MarketingReports
	{
		public static IEnumerable<Contracts.Report.Marketing.IArtistStatistic> GetArtistStatistics()
		{
			var albums = Logic.Factory.GetAllAlbums();
			var artists = Logic.Factory.GetAllArtists();

			// Abfrage 
			var result = default(IEnumerable<Contracts.Report.Marketing.IArtistStatistic>);

			return result;
		}
	}
}
