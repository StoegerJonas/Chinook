using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public class IInvoiceLines : IIdentifiable
    {
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public int TrackId { get; set; }
        public int InvoiceId { get; set; }
        public int InvoiceLineId { get; set; }
        public int Id { get; set; }
    }
}
