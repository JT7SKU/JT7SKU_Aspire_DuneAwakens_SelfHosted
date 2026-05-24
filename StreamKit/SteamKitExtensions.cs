using J77SKU.SteamConnector;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StreamKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace J77SKU.SteamKitAsiakas
{
    public static class SteamKitExtensions
    {
        public static void AddSteamKitAsiakas(
            this IHostApplicationBuilder rakentaja, string yhteysNimi, Action<SteamKitAsiakasSettings>? configAsetukset = null) =>
            AddSteamKitAsiakas(rakentaja,SteamKitAsiakasSettings.OletusConfigOsioNimi, configAsetukset, yhteysNimi, palveluAvain: null);

        public static void AddKeyedSteamKitAsiakas(this IHostApplicationBuilder rakentaja, string nimi,Action<SteamKitAsiakasSettings>? configAsetukset = null)
        {
            ArgumentNullException.ThrowIfNull(nimi);
            AddSteamKitAsiakas(rakentaja, $"{SteamKitAsiakasSettings.OletusConfigOsioNimi}:{nimi}", configAsetukset,yhteysNimi: nimi, palveluAvain: nimi);
        }
        private static void AddSteamKitAsiakas(this IHostApplicationBuilder rakentaja, string konfigroitavaOsioNimi, Action<SteamKitAsiakasSettings>? configAsetukset, string yhteysNimi, object? palveluAvain)
        {
            ArgumentNullException.ThrowIfNull(rakentaja);

            var asetukset = new SteamKitAsiakasSettings();

            rakentaja.Configuration.GetSection(konfigroitavaOsioNimi).Bind(asetukset);

            if (rakentaja.Configuration.GetConnectionString(yhteysNimi) is string yhteysstring)
            {
                asetukset.ParseConnectionString(yhteysstring);
            }
            configAsetukset?.Invoke(asetukset);

            if (palveluAvain is null)
            {
                rakentaja.Services.AddScoped(LuoSteamKitAsiakasTehdas);
            }
            else
            {
                rakentaja.Services.AddKeyedScoped(palveluAvain, (sp, avain) => LuoSteamKitAsiakasTehdas(sp));
            }

            SteamKitAsiakasTehdas LuoSteamKitAsiakasTehdas(IServiceProvider _)
            {
                return new SteamKitAsiakasTehdas(asetukset);
            }

            if (asetukset.DisableHealthChecks is false)
            {
                rakentaja.Services.AddHealthChecks().AddCheck<SteamKitTerveysTarkastus>(name: palveluAvain is null ? "SteamKit" : $"SteamKit{yhteysNimi}", failureStatus: default, tags: []);
            }

            //if (asetukset.DisableTracing is false)
            //{
            //    rakentaja.Services.AddOpenTelemetry()
            //         .WithTracing(
            //  traceBuilder => traceBuilder.AddSource(
            //     Telemetry.SteamClient.ActivitySourceName));
            //}

            //if (asetukset.DisableMetrix is false)
            //{
            //    // Required by MailKit to enable metrics
            //    Telemetry.SteamClient.Configure();

            //    rakentaja.Services.AddOpenTelemetry()
            //        .WithMetrics(
            //            metricsBuilder => metricsBuilder.AddMeter(
            //                Telemetry.SteamClient.MeterName));
            //}
        }
    }
}
