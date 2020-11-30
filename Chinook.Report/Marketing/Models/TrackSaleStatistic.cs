using System;
using System.Collections.Generic;
using System.Text;

namespace Chinook.Report.Marketing.Models
{
    internal class TrackSaleStatistic : Contracts.Report.Marketing.ITrackSaleStatistic
    {
        public string maxSaleName { get; set; }

        public string maxSaleNumber { get; set; }

        public string minSaleName { get; set; }

        public string minSaleNumber { get; set; }

        public string maxPaidSaleName { get; set; }

        public string maxPaidSaleNumber { get; set; }

        public string minPaidSaleName { get; set; }

        public string minPaidSaleNumber { get; set; }
    }
}
