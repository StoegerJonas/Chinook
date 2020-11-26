using CsvMapper.Logic.Attributes;

namespace Chinook.Models
{
    [CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/MediaType.csv")]
    internal class MediaType : Chinook.Logic.Models.IdentityObject, Contracts.Persistence.IMediaType
    {
        [DataPropertyInfo(OrderPosition = 2)]
        public string Name { get; set; }
        [DataPropertyInfo(OrderPosition = 1)]
        public int MediaTypeId { get; set; }
    }
}