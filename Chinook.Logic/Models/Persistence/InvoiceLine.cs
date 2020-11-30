using CsvMapper.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Logic.Models.Persistence
{
    [DataClass(HasHeader = true, FileName = "CsvData/InvoiceLine.csv")]
    class InvoiceLine : IdentityObject, Contracts.Persistence.IInvoiceLine
    {
        [DataPropertyInfo(OrderPosition =1)]
        public int InvoiceId { get; set; }
        [DataPropertyInfo(OrderPosition = 2)]
        public int TrackId { get; set; }
        [DataPropertyInfo(OrderPosition = 3)]
        public double UnitPrice { get; set; }
        [DataPropertyInfo(OrderPosition = 4)]
        public int Quantity { get; set; }
    }
}
