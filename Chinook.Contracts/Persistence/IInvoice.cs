using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public interface IInvoice : IIdentifiable
    {
        int CustumerId { get; set; }
        string InvoiceDate { get; set; }
        string BillingAdress { get; set; }
        string BillingCity { get; set; }
        string BillingState { get; set; }
        string BillingCountry { get; set; }
        string BillingPostalCode { get; set; }
        double Total { get; set; }
    }
}
