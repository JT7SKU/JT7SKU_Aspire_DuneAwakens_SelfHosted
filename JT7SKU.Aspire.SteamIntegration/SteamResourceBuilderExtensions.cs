using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT7SKU.Aspire.Integrations.Steam
{
    public static class SteamResourceBuilderExtensions
    {
        public static IResourceBuilder<SteamResource> AddSteamDB(
            this IDistributedApplicationBuilder rakentaja, [ResourceName] string nimi, int? port = null)
        {
            var resourssi = new SteamReasource(nimi);

            return rakentaja.AddResource(resourssi);
        }
    }
}
