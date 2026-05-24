using System.Data.Common;
using System.Net;

namespace StreamKit
{
    public sealed class SteamKitAsiakasSettings
    {
        internal const string OletusConfigOsioNimi = "SteamKit:Asiakas";
        public Uri? Endpoint { get; set; }
        public NetworkCredential? Tunnukset { get; set; }
        public bool DisableHealthChecks { get; set; }
        public bool DisableTracing { get; set; }
        public bool DisableMetrix { get; set; }
        internal void ParseConnectionString(string? connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException($"""
                ConnectionString is missing.
                It should be provided in 'ConnectionStrings:<connectionName>'
                or '{OletusConfigOsioNimi}:Endpoint' key.'
                configuration section.
                """);
            }

            if (Uri.TryCreate(connectionString, UriKind.Absolute, out var uri))
            {
                Endpoint = uri;
            }
            else
            {
                var rakentaja = new DbConnectionStringBuilder
                {
                    ConnectionString = connectionString
                };

                if (rakentaja.TryGetValue("Endpoint", out var endpoint) is false)
                {
                    throw new InvalidOperationException($"""
                    The 'ConnectionStrings:<connectionName>' (or 'Endpoint' key in
                    '{OletusConfigOsioNimi}') is missing.
                    """);
                }

                if (Uri.TryCreate(endpoint.ToString(), UriKind.Absolute, out uri) is false)
                {
                    throw new InvalidOperationException($"""
                    The 'ConnectionStrings:<connectionName>' (or 'Endpoint' key in
                    '{OletusConfigOsioNimi}') isn't a valid URI.
                    """);
                }

                Endpoint = uri;
                if (rakentaja.TryGetValue("Käyttäjänimi", out var kayttajanimi) && rakentaja.TryGetValue("Salasana", out var salasana))
                {
                    Tunnukset = new(kayttajanimi.ToString(), salasana.ToString());
                }
            }
        }
        }
}
