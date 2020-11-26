using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public class IPlaylist : IIdentifiable
    {
        public string Name { get; set; }
        public int PlaylistId { get; set; }
        public int Id { get; set; }
    }
}
