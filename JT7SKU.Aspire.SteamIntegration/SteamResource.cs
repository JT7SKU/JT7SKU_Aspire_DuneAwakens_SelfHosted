using Aspire.Hosting.ApplicationModel;

namespace JT7SKU.Aspire.SteamIntegration
{
    public class SteamReasource([ResourceName] string name) : ContainerResource(name), IResourceWithConnectionString
    {
        public ReferenceExpression ConnectionStringExpression => throw new NotImplementedException();
    }
}
