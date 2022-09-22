using VisitorManagement.Operations;

namespace VisitorManagement.Services
{
    public interface IAPI
    {
        Task<Root> WeatherAPI();
        Weather WeatherApiResult();
    }
}