using System;

namespace Chinook.Models
{
    public class Track : ModelObject, IComparable
    {
        public double UnitPrice { get; set; }
        public int Bytes { get; set; }
        public int Milliseconds { get; set; }
        public string Composer { get; set; }
        public int GenreId { get; set; }
        public int MediaTypeId { get; set; }
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public int TrackId { get; set; }
        
        public int CompareTo(object obj)
        {
            return Milliseconds.CompareTo(((Track) obj).Milliseconds);
        }
    }
}