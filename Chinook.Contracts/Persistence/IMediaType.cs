using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Persistence
{
    public interface IMediaType : IIdentifiable
    {
        public string Name { get; set; }
        public int MediaTypeId { get; set; }
    }
}
