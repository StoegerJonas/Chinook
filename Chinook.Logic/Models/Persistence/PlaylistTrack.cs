using CsvMapper.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Logic.Models.Persistence
{
    [DataClass(HasHeader = true, FileName = "CsvData/PlaylistTrack.csv")]
    internal class PlaylistTrack : IdentityObject, Contracts.Persistence.IPlaylistTrack
    {
        [DataPropertyInfo(OrderPosition =1)]
        public string TrackId { get; set; }
    }
}
