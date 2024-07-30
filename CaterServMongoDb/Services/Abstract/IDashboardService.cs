using CaterServMongoDb.Dtos.DashboardDtos;

namespace CaterServMongoDb.Services.Abstract
{
    public interface IDashboardService
    {
        ResultDashboardStatisticDto GetDashboardStatistic();
    }
}
