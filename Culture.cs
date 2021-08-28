using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;

namespace HIC
{
    static public class Culture
    {
        private static ResourceManager res_man;

        static Culture()
        {
            res_man = new ResourceManager("HIC.Lang_" + HICConfig.isoLanguageName, Assembly.GetExecutingAssembly());
        }

        public static string getText(string token)
        {
            if (!String.IsNullOrEmpty(res_man.GetString(token)))
            {
                String msgString = res_man.GetString(token);
                msgString = msgString.Replace("[D]", Environment.UserDomainName.ToUpper());  // Replace [D] with the domain name of this PC
                msgString = msgString.Replace("[U]", Environment.UserName);                 // Replace [U] with the username logged-on on this PC

                return msgString;
            }
            else
            {
                switch (token) // Default value fall-backs.
                {
                    case "author":
                        return "Mark Feenstra";
                    case "appTitle":
                        return "Help is coming";
                    case "lblWelkomText":
                        return "Please provide short description of your problem.";
                    case "cbxCallMeBack":
                        return "Please contact me at:";
                    case "cbxScreenShot":
                        return "Attach screenshot to report";
                    case "btnSubmit":
                        return "Submit";
                    case "tbxContactDetail":
                        return "(xxx) xxx-xxxx";
                    case "errNonDescription":
                        return "A short description is required inorder for us to help you quickly resolve the issue.";
                    case "errFailSent":
                        return "Unable to sent report; please call the helpdesk to get assistance.";
                    case "rptSubject":
                        return "HIC Report";
                    case "rptSubjectMark":
                        return "[!]";
                    case "rptBody":
                        return "User \"" + Environment.UserDomainName.ToUpper() + "\\" + Environment.UserName + "\" reported an issue via HIC that needs investigation.";
                    case "rptContactUser":
                        return "The user could like to be contacted at: ";
                    default:
                        return "Unknown";
                }
            }
        }
    }
}
