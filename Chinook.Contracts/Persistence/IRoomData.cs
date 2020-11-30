using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public interface IRoomData : IIdentifiable
    {
        string DislozierungID { get; set; }
        string Kurzbezeichnung { get; set; }
        string Bezeichnung { get; set; }
        string Code { get; set; }
        string UPISBez { get; set; }
    }
}
