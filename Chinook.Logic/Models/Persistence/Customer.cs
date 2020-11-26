﻿using Chinook.Attributes;
using CsvMapper.Logic.Attributes;

namespace Chinook.Logic.Models.Persistence
{

    [CsvMapper.Logic.Attributes.DataClass(HasHeader = true, FileName = "CsvData/Customer.csv")]
    internal class Customer : Chinook.Logic.Models.IdentityObject, Contracts.Persistence.ICustomer
    {
        [DataPropertyInfo(OrderPosition = 13)]
        public int SupportRepId { get; set; }
        [DataPropertyInfo(OrderPosition = 12)]
        public string Email { get; set; }
        [DataPropertyInfo(OrderPosition = 11)]
        public string Fax { get; set; }
        [DataPropertyInfo(OrderPosition = 10)]
        public string Phone { get; set; }
        [DataPropertyInfo(OrderPosition = 9)]
        public string PostalCode { get; set; }
        [DataPropertyInfo(OrderPosition = 8)]
        public string Country { get; set; }
        [DataPropertyInfo(OrderPosition = 7)]
        public string State { get; set; }
        [DataPropertyInfo(OrderPosition = 6)]
        public string City { get; set; }
        [DataPropertyInfo(OrderPosition = 5)]
        public string Address { get; set; }
        [DataPropertyInfo(OrderPosition = 4)]
        public string Company { get; set; }
        [DataPropertyInfo(OrderPosition = 3)]
        public string LastName { get; set; }
        [DataPropertyInfo(OrderPosition = 2)]
        public string FirstName { get; set; }
        [DataPropertyInfo(OrderPosition = 1)]
        public int  CustomerId { get; set; }
       
    }
}