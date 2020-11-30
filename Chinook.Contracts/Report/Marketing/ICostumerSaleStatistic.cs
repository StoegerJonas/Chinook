using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Report.Marketing
{
    public interface ICostumerSaleStatistic
    {
        string maxName { get; }
        string maxNumber { get; }
        string minName { get; }
        string minNumber { get; }
        string avgNumber { get; }
    }
}
