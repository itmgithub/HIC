using System;
using Microsoft.Office.Interop.Outlook;
using System.Net.Mail;
using System.Windows.Forms;
using System.Net;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;

namespace HIC
{
    class mailIssue
    {
        string userMessage = "";
        string userContact = "";

        public mailIssue(string userMessage, string userContact)
        {
            this.userMessage = userMessage;
            this.userContact = userContact;
        }

        private string mailBody()
        {
            string msgBody=Culture.getText("rptBody") + "\n\n";
            msgBody += "------------------------------------------------------------------------\n\n";
            msgBody += userMessage + "\n\n";
            if (!String.IsNullOrEmpty(userContact))
            { 
                msgBody += Culture.getText("rptContactUser") + userContact + "\n\n";
            }
            msgBody += "------------------------------------------------------------------------\n\n";
            return msgBody;

        }
        /*
         * Fill the mailMessage object with the correct values
         */
        private MailMessage setupNewMail(SmtpClient smtpServer)
        {
            MailMessage rptMail = new MailMessage();

            if ((String.IsNullOrEmpty(HICConfig.reportFrom)) && (String.IsNullOrEmpty(UserPrincipal.Current.EmailAddress)))
            {
                rptMail.From = new MailAddress(UserPrincipal.Current.EmailAddress);
            }
            else
            {
                rptMail.From = new MailAddress(HICConfig.reportFrom);
            }

            foreach (string toAddress in HICConfig.reportToSMTP)
            {
                rptMail.To.Add(toAddress);
            }

            if (String.IsNullOrEmpty(userContact))
            {
                rptMail.Subject = Culture.getText("rptSubject");
            }
            else
            {
                rptMail.Subject = Culture.getText("rptSubjectMark") + " " + Culture.getText("rptSubject");
            }

            rptMail.Body = mailBody();
            return rptMail;
        }


        /*
         * Send the mail as attachment to the report mailbox (via SMTP)
        */
        private void sendViaSMTP(List<string> attachment)
        {
            SmtpClient smtpServer = new SmtpClient(HICConfig.smtpServer);

            if (!String.IsNullOrEmpty(HICConfig.smtpUsername))
            {
                smtpServer.UseDefaultCredentials = false;
                smtpServer.Credentials = new NetworkCredential(HICConfig.smtpUsername, HICConfig.smtpPassword);
            }

            MailMessage rptMail = setupNewMail(smtpServer);

            attachment.ForEach(delegate (string fName)
            {
                rptMail.Attachments.Add(new System.Net.Mail.Attachment(fName));
            });

            try
            {
                smtpServer.Send(rptMail);
            }
            catch
            {
                MessageBox.Show(Culture.getText("errFailSent"), "HIC Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            rptMail.Dispose();
            smtpServer.Dispose();
        }

        /*
         * Send the mail as attachment to the report mailbox (via MAPI)
         */
        private void sendViaMAPI(List<string> attachment)
        {
            Microsoft.Office.Interop.Outlook.Application mapi = new Microsoft.Office.Interop.Outlook.Application();
            MailItem rptMail = mapi.CreateItem(OlItemType.olMailItem);

            if (String.IsNullOrEmpty(userContact))
            {
                rptMail.Subject = Culture.getText("rptSubject");
            } else
            {
                rptMail.Subject = Culture.getText("rptSubjectMark")+" " + Culture.getText("rptSubject");
            }

            rptMail.To = HICConfig.reportToMAPI;

            rptMail.Body = mailBody();

            attachment.ForEach(delegate (string fName)
            {
                rptMail.Attachments.Add(fName);
            });

            rptMail.Importance = OlImportance.olImportanceNormal;

            rptMail.Send();
        }



        public void reportViaMail(List<string> attachment)
        {
            if (HICConfig.useSMTP)
            {
                sendViaSMTP(attachment);
            }
            else
            {
                sendViaMAPI(attachment);
            }
        }

    }
}
