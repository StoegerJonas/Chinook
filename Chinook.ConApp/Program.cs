using System;
using System.Collections.Generic;
using System.Linq;
using Chinook.Contracts.Persistence;


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
            var costumers = Logic.Factory.GetAllCostumers();
            var employees = Logic.Factory.GetAllEmployees();
            var invoices = Logic.Factory.GetAllInvoices();
            var invoicesLines = Logic.Factory.GetAllInvoicesLines();
            var mediatypes = Logic.Factory.GetAllMediaTypes();
            var playlist = Logic.Factory.GetAllPlaylists();
            var playlistTracks = Logic.Factory.GetAllPlayListeTracks();
            var roomData = Logic.Factory.GetAllRoomDatas();
            var tracks = Logic.Factory.GetAllTracks();

            var artistStatistics = Report.MarketingReports.GetArtistStatistics();


            Console.WriteLine("Chinook Marketing\nGrösswang Sebastian\n");

            Console.WriteLine("Track-Zeit-Auswertung");
            Console.WriteLine("Track/Titel\t\t\t\tZeit[sec]");
            Console.WriteLine(TrackTimeQueryMax(tracks));
            Console.WriteLine(TrackTimeQueryMin(tracks));
            Console.WriteLine(TrackTimeQueryAverage(tracks));
            Console.WriteLine();

            Console.WriteLine("Album-Zeit-Auswertung");
            Console.WriteLine("Album/Titel\t\t\t\t\tZeit[sec]");
            Console.WriteLine(AlbumTimeQueryMax(tracks, albums));
            Console.WriteLine(AlbumTimeQueryMin(tracks, albums));
            Console.WriteLine(AlbumTimeQueryAverage(tracks, albums));
            Console.WriteLine();

            Console.WriteLine("Track-Verkauf-Auswertung");
            Console.WriteLine("Track/Titel\t\t\t\t\tQuantity");
            Console.WriteLine(TrackSaleQueryMax(invoicesLines, tracks));
            Console.WriteLine(TrackSaleQueryMin(invoicesLines, tracks));
            Console.WriteLine(TrackSaleQueryHighPaid(invoicesLines, tracks));
            Console.WriteLine(TrackSaleQueryLowPaid(invoicesLines, tracks));
            Console.WriteLine();

            Console.WriteLine("Kunde-Verkauf-Auswertung");
            Console.WriteLine("Kunde/Name");
            Console.WriteLine(CustomerQueryMax(invoices, costumers));
            Console.WriteLine(CustomerQueryMin(invoices, costumers));
            Console.WriteLine(CustomerQueryAverage(invoices, costumers));

            Console.WriteLine();
            Console.WriteLine("Genre-Verkauf-Auswertung");
            Console.WriteLine("Genre/Name");
            Console.ReadKey();

        }

        private static string CustomerQueryAverage(IEnumerable<IInvoice> invoices, IEnumerable<ICostumer> costumers)
        {
            var item = (from i in invoices
                        join c in costumers on i.CustumerId equals c.Id
                        group i by c.LastName)
                        .Select(j => (j.Key, j.Sum(a => a.Total)))
                        .OrderBy(a => a.Item2)
                        .Average(k => k.Item2);
            return "Average: " + item;
        }

        private static string CustomerQueryMin(IEnumerable<IInvoice> invoices, IEnumerable<ICostumer> costumers)
        {
            var item = (from i in invoices
                        join c in costumers on i.CustumerId equals c.Id
                        group i by c.LastName)
                          .Select(j => (j.Key, j.Sum(a => a.Total)))
                          .OrderBy(a => a.Item2)
                          .First();
            return "Min " + item.Key + " => " + item.Item2;
        }

        private static string CustomerQueryMax(IEnumerable<IInvoice> invoices, IEnumerable<ICostumer> costumers)
        {
            var item = (from i in invoices
                        join c in costumers on i.CustumerId equals c.Id
                        group i by c.LastName)
                        .Select(j => (j.Key, j.Sum(a => a.Total)))
                        .OrderBy(a => a.Item2)
                        .Last();
            return "Max " + item.Key + " => " + item.Item2;
        }

        private static string TrackSaleQueryLowPaid(IEnumerable<IInvoiceLine> invoicesLines, IEnumerable<ITrack> tracks)
        {
            var res = (from i in invoicesLines
                       join t in tracks on i.TrackId equals t.Id
                       group i.Quantity by t.Name)
                        .Select(item => (item.Key, item.Sum()))
                        .OrderBy(a => a.Item2)
                        .First();
            return res.Key + ":" + res.Item2;
        }

        private static string TrackSaleQueryHighPaid(IEnumerable<IInvoiceLine> invoicesLines, IEnumerable<ITrack> tracks)
        {
            var res = (from i in invoicesLines
                       join t in tracks on i.TrackId equals t.Id
                       group i.Quantity by t.Name)
                        .Select(item => (item.Key, item.Sum()))
                        .OrderBy(a => a.Item2)
                        .Last();
            return res.Key + ":" + res.Item2;
        }

        private static string TrackSaleQueryMin(IEnumerable<IInvoiceLine> invoicesLines, IEnumerable<ITrack> tracks)
        {
            var item = (from i in invoicesLines
                        group i.Quantity by i.TrackId).Select(i => (i.Key, i.Sum())).Min();
            var track = tracks.Where(q => q.Id == item.Key).SingleOrDefault();
            return track.Name + ":" + item.Item2;
        }

        private static string TrackSaleQueryMax(IEnumerable<IInvoiceLine> invoicesLines, IEnumerable<ITrack> tracks)
        {
            var item = (from i in invoicesLines
                        group i.Quantity by i.TrackId).Select(i => (i.Key, i.Sum())).Max();
            var track = tracks.Where(q => q.Id == item.Key).SingleOrDefault();
            return track.Name + ":" + item.Item2;
        }

        private static string AlbumTimeQueryAverage(IEnumerable<ITrack> tracks, IEnumerable<IAlbum> albums)
        {
            var item = (from t in tracks
                        join a in albums on t.AlbumId equals a.Id
                        group t.Milliseconds by a.Title)
                        .Select(i => (i.Key, i.Sum())).Average(a => a.Item2);
            return "Average Album Time: " + Math.Round(item / 1000);
        }

        private static string
            AlbumTimeQueryMin(IEnumerable<ITrack> tracks, IEnumerable<IAlbum> albums)
        {
            var item = (from t in tracks
                        join a in albums on t.AlbumId equals a.Id
                        group t.Milliseconds by a.Title)
                      .Select(i => (i.Key, i.Sum())).OrderBy(a => a.Item2).First();
            return item.Key + "\t" + item.Item2 / 1000;
        }

        private static string AlbumTimeQueryMax(IEnumerable<ITrack> tracks, IEnumerable<IAlbum> albums)
        {
            var item = (from t in tracks
                        join a in albums on t.AlbumId equals a.Id
                        group t.Milliseconds by a.Title)
                      .Select(i => (i.Key, i.Sum())).OrderBy(a => a.Item2).Last();
            return item.Key + "\t\t\t\t\t" + item.Item2 / 1000;

        }

        private static string TrackTimeQueryAverage(IEnumerable<ITrack> tracks)
        {
            var track = tracks.Average(t => t.Milliseconds);
            return "AVG-Time: " + Math.Round(track / 1000);

        }

        private static string TrackTimeQueryMin(IEnumerable<ITrack> tracks)
        {
            var track = tracks.Min();
            return track.Name + "\t\t" + track.Milliseconds + "/ 1000";

        }

        private static string TrackTimeQueryMax(IEnumerable<ITrack> tracks)
        {
            var track = tracks.Max();

            return track.Name + "\t\t\t" + track.Milliseconds + "/ 1000";

        }
    }
}
