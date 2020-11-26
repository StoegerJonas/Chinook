using System;
using System.Linq;
using Chinook.Models;
using Chinook.Logic;

namespace ChinookCLI
{
    class Program
    {
        /// <summary>
        /// Main Method for ChinookCLI
        /// </summary>
        /// <param name="args">unused</param>
        static void Main(string[] args)
        {
            var artists = FileReader.Read<Artist>();
            var albums = FileReader.Read<Album>();
            var customers = FileReader.Read<Customer>();
            var employees = FileReader.Read<Employee>();
            var genres = FileReader.Read<Genre>();
            var invoices = FileReader.Read<Invoice>();
            var invoiceLines = FileReader.Read<InvoiceLine>();
            var mediaTypes = FileReader.Read<MediaType>();
            var playlists = FileReader.Read<Playlist>();
            var playlistTracks = FileReader.Read<PlaylistTrack>();
            var tracks = FileReader.Read<Track>();

            {
                Console.WriteLine("Track-Zeit-Auswertung\n" +
                                  "Track/Titel\t\t\t\tZeit[sec]");
                var max = tracks.Max();
                Console.WriteLine(max.Name + "\t\t\t" + max.Milliseconds / 1000);
                var min = tracks.Min();
                Console.WriteLine(min.Name + "\t\t" + min.Milliseconds / 1000);
                var avg = tracks.Average(track => track.Milliseconds);
                Console.WriteLine("AVG-Time: " + Math.Round(avg / 1000) + "\n\n");
            }

            {
                Console.WriteLine("Album-Zeit-Auswertung\n" +
                                  "Album/Titel\t\t\t\tZeit[sec]");
                var max = (from t in tracks
                           join a in albums on t.AlbumId equals a.AlbumId
                           group t.Milliseconds by a.Title).Select(val => (val.Key, val.Sum())).OrderBy(a => a.Item2).Last();

                Console.WriteLine($"Max: {max.Key} Time: {max.Item2 / 1000}");

                var min = (from t in tracks
                           join a in albums on t.AlbumId equals a.AlbumId
                           group t.Milliseconds by a.Title).Select(val => (val.Key, val.Sum())).OrderBy(a => a.Item2).First();

                Console.WriteLine($"Min: {min.Key} Time: {min.Item2 / 1000}");

                var avg = (from t in tracks
                           join a in albums on t.AlbumId equals a.AlbumId
                           group t.Milliseconds by a.Title).Select(val => (val.Key, val.Sum())).Average(a => a.Item2);
                Console.WriteLine("Average Album Time: " + Math.Round(avg / 1000));
            }

            {
                Console.WriteLine("\n\n\nTrack-Verkauf-Auswertung");
                var res1 = (from il in invoiceLines
                            join t in tracks on il.TrackId equals t.TrackId
                            group il.Quantity by t.Name).Select(val => (val.Key, val.Sum())).OrderBy(a => a.Item2);

                Console.WriteLine($"Höchste Verkaufszahl: {res1.Last().Key}: {res1.Last().Item2}");

                Console.WriteLine($"Niedrigste Verkaufszahl: {res1.First().Key}: {res1.First().Item2}");

                var res2 = (from il in invoiceLines
                            join t in tracks on il.TrackId equals t.TrackId
                            group il by t.Name).Select(val => (val.Key, val.Sum(a => a.Quantity * a.UnitPrice))).OrderBy(a => a.Item2);

                Console.WriteLine($"Höchster Umsatz: {res2.Last().Key}: {res2.Last().Item2}");

                Console.WriteLine($"Niedrigster Umsatz: {res2.First().Key}: {res2.First().Item2}");
            }

            {
                Console.WriteLine("\n\n\nKunde-Verkauf-Auswertung (Umsatz)");
                var res1 = (from i in invoices
                            join c in customers on i.CustomerId equals c.CustomerId
                            group i by c.LastName).Select(val => (val.Key, val.Sum(a => a.Total))).OrderBy(a => a.Item2);
                Console.WriteLine($"Höchster Umsatz: {res1.Last().Key}: {res1.Last().Item2}");

                Console.WriteLine($"Niedrigster Umsatz: {res1.First().Key}: {res1.First().Item2}");
            }

            Console.ReadKey();
        }
    }
}