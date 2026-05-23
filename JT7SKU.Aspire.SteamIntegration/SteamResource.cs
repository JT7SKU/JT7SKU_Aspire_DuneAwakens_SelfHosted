using Aspire.Hosting.ApplicationModel;

namespace JT7SKU.Aspire.Integrations.Steam
{
    public class SteamResource([ResourceName] string nimi, ParameterResource? kayttajanimi, ParameterResource? salasana) : Resource(nimi), IResourceWithConnectionString
    {
        internal const string HttpLiittyntapisteNimi = "http";
        private const string OletusKayttajanimi = "steam-user";
        
        public ParameterResource? KayttajaNimiParametri { get; } = kayttajanimi;

        internal ReferenceExpression UserNameReference => KayttajaNimiParametri is not null ?
    ReferenceExpression.Create($"{KayttajaNimiParametri}") :
    ReferenceExpression.Create($"{OletusKayttajanimi}");
        public ParameterResource SalasanaParametetri { get; } = salasana;

        public ReferenceExpression ConnectionStringExpression => throw new NotImplementedException();
    }
}
