# Unagi
## Intro
Unagi is an Outlook add-in that allows end-users and easy reporting feature for suspicious emails, like phishig attempts. When the user either selects or opens the mail the Unagi button is available to forward the email as an attachment to the security team. It’s just one click and done. 

## Features
- One click forwarding of an email
- (Optionally) move reported email to trash-folder
- Multi-language
- Supports both outlook as-well as an SMTP server to forward the emails.

## Status
Unagi is still in early testing. First results have been proven reliable but I would still consider this beta at-best due to its limited testing scenario’s
Unagi currently only supports Dutch (nl_NL) and English (en_US). Contact me if you need additional language support. Please note that you do need to provide the translations yourself, as Dutch and English are the only two languages I feel comfortable enough with to make sense when I use it. Also, please note that if you need specific translations (like for your own company), you need to build Unagi from sources yourself, although, if I have them time I am most likely willing to assist with that.

## Configuration
All configuration in Unagi is done in the App.config file. This file contains the following items.

| Section       | Key                 | Default value     | Description                                                 |
| :------------ | :------------------ | :---------------- | :---------------------------------------------------------- |
| unagiSettings | isoLanguageName     | en_US             | ISO language code to load right translations                |
| unagiSettings | useSMTP             | false             | Use SMTP or Outlook to forward the email                    |
| unagiSettings | moveReportedToTrash | true              | Move the reported email to the trash folder after reporting |
| unagiSettings | reportTo            | noreply@localhost | Semicolon seperated list of destination email addresses     |
| smtpSettings  | smtpServer          | localhost         | SMTP server hostname or IP address                          |
| smtpSettings  | reportFrom          | noreply@localhost | Senders address when using an SMTP server for forwarding    |
| smtpSettings  | username            | <none>            | Username for authenticated SMTP; only use when you have to. |
| smtpSettings  | password            | <none>            | Password for authenticated SMTP; only use when you have to. |

### Note
The SMTP username and password are in clear text in the configuration file. This is obviously bad practice and therefore not a recommended feature to use. But if you have to make sure you limit access to the App.config file using OS permission settings.


## TODO:
- Code-sign a release package.
- Document installation process.

## Screenshot
Selected email:
![Selected email](/ScreenShots/unagi-screenshot1.png)

Opened email:
![Opened email](/ScreenShots/unagi-screenshot2.png)


