using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Contracts.Report.Marketing
{
    public interface ITrackSaleStatistic
    {
        string maxSaleName { get; }
        string maxSaleNumber { get; }
        string minSaleName { get; }
        string minSaleNumber { get; }
        string maxPaidSaleName { get; }
        string maxPaidSaleNumber { get; }
        string minPaidSaleName { get; }
        string minPaidSaleNumber { get; }

    }
}
