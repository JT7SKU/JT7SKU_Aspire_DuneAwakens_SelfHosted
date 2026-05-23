using J77SKU.SteamConnector;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace J77SKU.SteamKitAsiakas
{
    internal sealed class SteamKitTerveysTarkastus(SteamKitAsiakasTehdas tehdas):IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext kontexti, CancellationToken token = default)
        {
			try
			{
				// tehdas ottaa yhteyden (ja autentikoi)
				_ = tehdas.HaeSteamAsiakas(token);
				return HealthCheckResult.Healthy();
			}
			catch (Exception ex)
			{

				return HealthCheckResult.Unhealthy(exception: ex);
			}
        }
    }
}