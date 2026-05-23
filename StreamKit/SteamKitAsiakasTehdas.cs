using SteamKit2;
using StreamKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace J77SKU.SteamConnector
{
    public sealed class SteamKitAsiakasTehdas(SteamKitAsiakasSettings asetukset)
    {
        public SteamClient HaeSteamAsiakas(CancellationToken cancellationToken)
        {
            var asiakas = new SteamClient();
            try
            {
                if (asetukset.Endpoint is not null)
                {
                    //await asiakas.Connect();
                }
                return asiakas;
            }
            catch (Exception)
            {
                //disconnect
                throw;
            }
        }
    }
}