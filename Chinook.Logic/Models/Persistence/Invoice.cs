using CsvMapper.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Logic.Models.Persistence
{
    [DataClass(HasHeader = true, FileName = "CsvData/Invoice.csv")]
    internal class Invoice : IdentityObject, Contracts.Persistence.IInvoice
    {
        [DataPropertyInfo(OrderPosition =1)]
        public int CustumerId { get; set; }
        [DataPropertyInfo(OrderPosition = 2)]
        public string InvoiceDate { get; set; }
        [DataPropertyInfo(OrderPosition = 3)]
        public string BillingAdress { get; set; }
        [DataPropertyInfo(OrderPosition = 4)]
        public string BillingCity { get; set; }
        [DataPropertyInfo(OrderPosition = 5)]
        public string BillingState { get; set; }
        [DataPropertyInfo(OrderPosition = 6)]
        public string BillingCountry { get; set; }
        [DataPropertyInfo(OrderPosition = 7)]
        public string BillingPostalCode { get; set; }
        [DataPropertyInfo(OrderPosition = 8)]
        public double Total { get; set; }
    }
}
