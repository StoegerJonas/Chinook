using CsvMapper.Logic.Attributes;

namespace Chinook.Models
{
    [CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/Invoice.csv")]
    internal class Invoice : Chinook.Logic.Models.IdentityObject, Contracts.Persistence.IInvoice
    {
        [DataPropertyInfo(OrderPosition = 9)]
        public double Total { get; set; }
        [DataPropertyInfo(OrderPosition = 8)]
        public string BillingPostalCode { get; set; }
        [DataPropertyInfo(OrderPosition = 7)]
        public string BillingCountry { get; set; }
        [DataPropertyInfo(OrderPosition = 6)]
        public string BillingState { get; set; }
        [DataPropertyInfo(OrderPosition = 5)]
        public string BillingCity { get; set; }
        [DataPropertyInfo(OrderPosition = 4)]
        public string BillingAddress { get; set; }
        [DataPropertyInfo(OrderPosition = 3)]
        public string InvoiceDate { get; set; }
        [DataPropertyInfo(OrderPosition = 2)]
        public int CustomerId { get; set; }
        [DataPropertyInfo(OrderPosition = 1)]
        public int InvoiceId { get; set; }
    }
}