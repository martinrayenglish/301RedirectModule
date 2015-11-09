﻿using System.ComponentModel;

namespace SharedSource.RedirectModule
{
    public static class Constants
    {
        public static class Paths
        {
            public static string VisitorIdentification = "/layouts/system/visitoridentification";
            public static string MediaLibrary = "/sitecore/media library/";
        }

        public static class Settings
        {
            public static string RedirExactMatch = "SharedSource.RedirectModule.RedirectionType.ExactMatch";
            public static string RedirPatternMatch = "SharedSource.RedirectModule.RedirectionType.Pattern";
            public static string QueryExactMatch = "SharedSource.RedirectModule.QueryType.ExactMatch";
            public static string QueryPatternMatch = "SharedSource.RedirectModule.QueryType.PatternMatch";
            public static string RedirectRootNode = "SharedSource.RedirectModule.RedirectRootNode";
            public static string MaxMindUserId = "SharedSource.RedirectModule.MaxMindWebServiceUserID";
            public static string MaxMindLicenseKey = "SharedSource.RedirectModule.MaxMindWebServiceLicenseKey";
            public static string MaxMindType = "SharedSource.RedirectModule.MaxMindType";
            public static string MaxMindDatabasePath = "SharedSource.RedirectModule.MaxMindDatabasePath";
            public static string ExternalHosts = "SharedSource.RedirectModule.ExternalHosts";
            public static string MaxCacheSize = "SharedSource.RedirectModule.MaxCacheSize";
            public static string ExternalHostsNotFoundUrl = "SharedSource.RedirectModule.ExternalHosts.NotFoundUrl";
            
        }
        public static class Templates
        { 
            public static string RedirectUrl = "Redirect Url";
            public static string VersionedRedirectUrl = "Versioned Redirect Url";
            public static string RedirectPattern = "Redirect Pattern";
            public static string VersionedRedirectPattern = "Versioned Redirect Pattern";
            public static string ResponseStatusCodeFolder = "Response Status Code Folder";
            public static string ResponseStatusCode = "Response Status Code";
        }
        public static class Fields
        { 
            public static string RequestedUrl = "Requested Url";
            public static string RedirectToItem = "redirect to item";
            public static string RedirectToUrl = "redirect to url";
            public static string RequestedExpression = "requested expression";
            public static string SourceItem = "source item";
            public static string RelativeDestinationPath = "Redirect To Relative Destination Path";
            public static string ItemProcessRedirects = "Items Which Always Process Redirects";
            public static string ResponseStatusCode = "Response Status Code";
            public static string StatusCode = "Status Code";
			public static string RedirectCode = "Continent or Country Code";
        }

    }
}
