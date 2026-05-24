using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace JT7SKU.Aspire.Integrations.Steam
{
    public static class SteamResourceBuilderExtensions
    {
        private const string KayttajaYmpVarNimi = "STEAM_SISAANTULEVA_KAYTTAJA";
        private const string SalasanaYmpVarNimi = "STEAM_SISAANTULEVA_SALURI";
        public static IResourceBuilder<SteamResource> AddSteamDB(
            this IDistributedApplicationBuilder rakentaja, [ResourceName] string nimi, int? port = null,
            IResourceBuilder<ParameterResource>? kayttajanimi = null, IResourceBuilder<ParameterResource>? salasana = null)
        {
            var salasanaParametri = salasana?.Resource ?? ParameterResourceBuilderExtensions.CreateDefaultPasswordParameter(rakentaja, $"{nimi}-salasana");
            var resourssi = new SteamResource(nimi,kayttajanimi?.Resource,salasanaParametri);

            return rakentaja.AddResource(resourssi);
                
        }
    }
}
