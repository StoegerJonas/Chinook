using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public interface IMediaType : IIdentifiable
    {
        string Name { get; set; }
    }
}
