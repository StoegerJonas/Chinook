using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public interface IPlaylist : IIdentifiable
    {
        string Name { get; set; }
    }
}
