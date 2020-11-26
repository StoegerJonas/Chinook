using CsvMapper.Logic.Attributes;

namespace Chinook.Models
{
    [CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/PlaylistTrack.csv")]
    internal class PlaylistTrack : Chinook.Logic.Models.IdentityObject
    {
        [DataPropertyInfo(OrderPosition = 2)]
        public string TrackId { get; set; }
        [DataPropertyInfo(OrderPosition = 1)]
        public int PlaylistId { get; set; }
    }
}