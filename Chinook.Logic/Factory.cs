using System.Collections.Generic;

namespace Chinook.Logic
{
    public class Factory
    {
        public static IEnumerable<Contracts.Persistence.IGenre> GetAllGenres()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Genre>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IArtist> GetAllArtists()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Artist>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IAlbum> GetAllAlbums()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Album>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.ICostumer> GetAllCostumers()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Costumer>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IEmployee> GetAllEmployees()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Employee>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IInvoice> GetAllInvoices()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Invoice>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IInvoiceLine> GetAllInvoicesLines()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.InvoiceLine>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IMediaType> GetAllMediaTypes()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.MediaType>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IPlaylist> GetAllPlaylists()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Playlist>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IPlaylistTrack> GetAllPlayListeTracks()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.PlaylistTrack>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.IRoomData> GetAllRoomDatas()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.RoomData>();

            return result;
        }
        public static IEnumerable<Contracts.Persistence.ITrack> GetAllTracks()
        {
            var result = CsvMapper.Logic.CsvHelper.Read<Models.Persistence.Track>();

            return result;
        }
    }
}
