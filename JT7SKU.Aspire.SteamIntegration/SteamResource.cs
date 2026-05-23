using Aspire.Hosting.ApplicationModel;

namespace JT7SKU.Aspire.Integrations.Steam
{
    public class SteamResource([ResourceName] string nimi) : ContainerResource(nimi), IResourceWithConnectionString
    {
        public ReferenceExpression ConnectionStringExpression => throw new NotImplementedException();
    }
}
