using System;
using System.Collections.Generic;

using MaxMind.GeoIP2;
using MaxMind.GeoIP2.Responses;
using Sitecore.Diagnostics;

using SharedSource.RedirectModule.Caching;

namespace SharedSource.RedirectModule.MaxMind
{
    public class DatabaseHelper
    {
        public static KeyValuePair<string, string> GetCodeFromIP(string ipaddress)
        {
            var databasePath = Sitecore.Configuration.Settings.GetSetting(Constants.Settings.MaxMindDatabasePath);
            var foundCountry = new KeyValuePair<string, string>();

            try
            {
                //First try and get the response that matches the IP from cache
                var countryResponse = CacheHelper.RedirectCache.GetObject(ipaddress) as CountryResponse;

                if (countryResponse != null)
                {
                    foundCountry = new KeyValuePair<string, string>(countryResponse.Continent.Code, countryResponse.Country.IsoCode);
                }

                //Else, let's grab it from the database
                using (var reader = new DatabaseReader(databasePath))
                {
                    var dbResponse = reader.Country(ipaddress);
                    //Add to cache
                    CacheHelper.RedirectCache.SetObject(ipaddress, dbResponse);
                    foundCountry = new KeyValuePair<string, string>(dbResponse.Continent.Code, dbResponse.Country.IsoCode);
                }
            }
            catch (Exception error)
            {
                Log.Error(string.Format("[SharedSource.RedirectModule.MaxMind.DatabaseHelper] {0}", error.Message), typeof(DatabaseHelper));
            }

            return foundCountry;
        }
    }
}
