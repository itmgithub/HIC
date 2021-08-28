using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace HIC
{
    static public class HICConfig
    {
        public static string isoLanguageName { get; set; } = System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        public static Boolean allowContact { get; set; } = true;
        public static Boolean useSMTP { get; set; } = true;
        public static string reportFrom { get; set; } = "noreply@localhost";
        public static string[] reportToSMTP { get; set; } = { "noreply@localhost" };
        public static string reportToMAPI { get; set; } = "noreply@localhost";
        public static string smtpServer { get; set; } = "localhost";
        public static string smtpUsername { get; set; } = "";
        public static string smtpPassword { get; set; } = "";

        static HICConfig()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;

            isoLanguageName = appSettings["isoLanguageName"] ?? System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            allowContact = Boolean.Parse(appSettings["allowContact"] ?? "false");
            useSMTP = Boolean.Parse(appSettings["useSMTP"] ?? "true");
            reportFrom = appSettings["reportFrom"] ?? "noreply@localhost";
            reportToMAPI = appSettings["reportTo"] ?? "noreply@localhost";
            reportToSMTP = reportToMAPI.Split(';').Select(str => str.Trim()).ToArray(); // Yes, I know I can split the string later, but here it is a tiny bit more obvious and penalty is minimal.
            smtpServer = appSettings["smtpServer"] ?? "localhost";
            smtpUsername = appSettings["username"] ?? "";
            smtpPassword = appSettings["password"] ?? "";

        }

    }
}
