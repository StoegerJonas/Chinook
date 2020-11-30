using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public interface ICostumer : IIdentifiable
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string State { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
        string Email { get; set; }
        int SupportRepId { get; set; }
    }
}
