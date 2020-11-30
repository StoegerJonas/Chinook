using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public interface ITrack : IIdentifiable, IComparable
    {
        string Name { get; set; }
        int AlbumId { get; set; }
        int MediaTypeId { get; set; }
        int GenreId { get; set; }
        string Composer { get; set; }
        int Milliseconds { get; set; }
        string Bytes { get; set; }
        string UnitPrice { get; set; }
    }
}
