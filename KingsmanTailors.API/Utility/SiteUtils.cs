using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace KingsmanTailors.API.Utility
{
    public class SiteUtils
    {
        internal const string SuperUser = "Super User";
        internal const string SalesRep = "Sales Rep";
        internal const string DemoUser = "Demo User";
        internal const string GuestUser = "Guest";

        //till I can think of a better way to retrieve usernames and passwords for database connection...
        private const string AZR_DEMO_PASSWORD = "Ayomide98_D3m0";

        private const string AZR_DEMO_USERNAME = "kt-rdr";
        private const string AZR_PASSWORD = "AyomsK1n8tlo4";
        private const string AZR_USERNAME = "kt-adm";

        public static string Mode { get; set; }

        private static bool isProductionEnvironment => Mode.Equals("_azr_dnc", StringComparison.CurrentCultureIgnoreCase);

        public static string SqlConnectionString(IConfiguration config)
        {
            //use the mode to find which connection string to load
            Mode = config.GetValue("Mode", "");
            var connectSetting = config.GetConnectionString(Mode) ?? "";
            if (connectSetting.Contains("[USERNAME]"))
            {
                connectSetting = replaceTag(connectSetting, new[] { "[USERNAME]", "[PASSWORD]" });
            }
            return connectSetting;
        }

        private static string replaceTag(string value, string[] keys)
        {
            // if value contains username or password then do tag replace otherwise return value
            if (keys.ToList().Any(value.Contains))
            {
                value = value.Replace("[PASSWORD]", isProductionEnvironment ? AZR_PASSWORD : AZR_DEMO_PASSWORD);
                value = value.Replace("[USERNAME]", isProductionEnvironment ? AZR_USERNAME : AZR_DEMO_USERNAME);
            }
            return value;
        }

    }
}
