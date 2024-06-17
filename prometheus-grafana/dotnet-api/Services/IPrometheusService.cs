using Models;

namespace api.Services.PrometheusService
{
    public interface IPrometheusService
    {
        IEnumerable<Prom> GetProms();
    }
}
