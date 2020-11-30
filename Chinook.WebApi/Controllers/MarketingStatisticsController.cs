using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chinook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketingStaticsController : ControllerBase
    {
        [HttpGet("api/[controller]/GenreStatistics")]
        public string Message()
        {
            return "fdsafdsfds";
        }

        [HttpGet("api/[controller]/AlbumTimeStatistic")]
        public Contracts.Report.Marketing.IAlbumTimeStatistic AlbumTime()
        {
            return Report.MarketingReports.GetAlbumTimeStatistic();
        }

        [HttpGet("api/[controller]/CostumerSaleStatistic")]
        public Contracts.Report.Marketing.ICostumerSaleStatistic CostumerSale()
        {
            return Report.MarketingReports.GetCostumerSaleStatistic();
        }

        [HttpGet("api/[controller]/TrackSaleStatistic")]
        public Contracts.Report.Marketing.ITrackSaleStatistic TrackSale()
        {
            return Report.MarketingReports.GetTrackSaleStatistic();
        }

        [HttpGet("api/[controller]/TrackTimeStatistic")]
        public Contracts.Report.Marketing.ITrackTimeStatistic TrackTime()
        {
            return Report.MarketingReports.GetTrackTimeStatistic();
        }
    }
}
