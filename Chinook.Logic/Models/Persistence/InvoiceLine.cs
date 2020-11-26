using CsvMapper.Logic.Attributes;

namespace Chinook.Models
{
    [CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/InvoiceLines.csv")]
    internal class InvoiceLine : Chinook.Logic.Models.IdentityObject
    {
        [DataPropertyInfo(OrderPosition = 5)]
        public int Quantity { get; set; }
        [DataPropertyInfo(OrderPosition = 4)]
        public double UnitPrice { get; set; }
        [DataPropertyInfo(OrderPosition = 3)]
        public int TrackId { get; set; }
        [DataPropertyInfo(OrderPosition = 2)]
        public int InvoiceId { get; set; }
        [DataPropertyInfo(OrderPosition = 1)]
        public int InvoiceLineId { get; set; }
    }
}