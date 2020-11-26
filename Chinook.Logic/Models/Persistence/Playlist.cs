using CsvMapper.Logic.Attributes;

namespace Chinook.Models
{
    [CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/Playlist.csv")]
    internal class Playlist : Chinook.Logic.Models.IdentityObject
    {
        [DataPropertyInfo(OrderPosition = 2)]
        public string Name { get; set; }
        [DataPropertyInfo(OrderPosition = 1)]
        public int PlaylistId { get; set; }
    }
}