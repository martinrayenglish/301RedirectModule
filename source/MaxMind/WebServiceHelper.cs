using System;
using System.Collections.Generic;

using MaxMind.GeoIP2;
using Sitecore.Diagnostics;

namespace SharedSource.RedirectModule.MaxMind
{
    public class WebServiceHelper
    {   
        private static int? UserId
        {
            get
            {
                int userId;
                var isInt = int.TryParse(Sitecore.Configuration.Settings.GetSetting(Constants.Settings.MaxMindUserId), out userId);

                if (isInt)
                {
                    return userId;
                }

                return null;
            }
        }

        public static KeyValuePair<string, string> GetCodeFromIP(string ipaddress)
        {
            var foundCountry = new KeyValuePair<string, string>();

            if (!UserId.HasValue)
            {
                return foundCountry;
            }
            
            var client = new WebServiceClient(UserId.Value, Sitecore.Configuration.Settings.GetSetting(Constants.Settings.MaxMindLicenseKey));

            try
            {
                var response = client.Country(ipaddress);

                foundCountry = new KeyValuePair<string, string>(response.Continent.Code, response.Country.IsoCode);
            }
            catch (Exception error)
            {
                Log.Error(string.Format("SharedSource.RedirectModule.MaxMind.WebServiceHelper {0}", error.Message), typeof(WebServiceHelper));
            }

            return foundCountry;
        }
    }
}
