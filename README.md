# HIC ; Help is coming

## Intro
HIC is an application to provide end-users with a simple interface to send support emails. The benefit over having the user send an email is that HIC will collect some basic system information that may aid in troubleshooting the problem. Also HIC allows the user to attach screenshots by just setting a simple tick in the checkbox.

## Features
- Simple interface
- Automatically attach screenshots
- Multi-language
- Can use an SMTP server or Outlook to send the email
- Multiple displays supported (one attachment for each screen)
- Collect some system information and attach this as an RTF report
    - System uptime
    - Username
    - Domainname
    - Locale
    - Available disk-drives, free space and drive-ready status
    - Environment variable Key/Value pairs
    - Process list


## Status
HIC is still considered: testing. First results have been proven reliable but I would still consider this beta due to its limited testing scenario’s. That said, HIC is the forth iteration and its predecessors (called HOH) has been in use for several years. HIC was just released because I wanted it to go back to its roots, which HOH had deviated from.

HIC currently only supports Dutch (nl_NL) and English (en_US). Contact me if you need additional language support. Please note that you do need to provide the translations yourself, as Dutch and English are the only two languages I feel comfortable enough with to make sense when I use it. Also, please note that if you need specific translations (like for your own company), you need to build HIC from sources yourself, although, if I have them time I am most likely willing to assist with that.

## Configuration
All configuration in HIC is done in the App.config file. This file contains the following items:

| Section     | Key                 | Default value     | Description                                                 |
| :---------- | :------------------ | :---------------- | :---------------------------------------------------------- |
| appSettings | isoLanguageName     | en_US             | ISO language code to load right translations                |
| appSettings | allowContact        | true              | Enable the "Please contact me" feature of HIC               |
| appSettings | useSMTP             | false             | Use SMTP or Outlook to forward the email                    |
| appSettings | reportFrom          | noreply@localhost | Senders address when using an SMTP server for forwarding    |
| appSettings | reportTo            | noreply@localhost | Semicolon seperated list of destination email addresses     |
| appSettings | smtpServer          | localhost         | SMTP server hostname or IP address                          |
| appSettings | username            | <none>            | Username for authenticated SMTP; only use when you have to. |
| appSettings | password            | <none>            | Password for authenticated SMTP; only use when you have to. |

### Note:
The SMTP username and password are in clear text in the configuration file. This is obviously bad practice and therefore not a recommended feature to use. But if you have to, make sure you limit access to the App.config file using OS permission settings.


## TODO:
- Code-sign a release package.
- Document installation process.
- Refactor the system gathering class; this is mostly still from the pre-HOH release which is the predecessor of the HIC predecessor and literally the first real C# application I wrote.

## Screenshot
Empty screen:
![Empty screen](/ScreenShots/HIC-screenshot1.png)

Example use:
![Example use](/ScreenShots/HIC-screenshot2.png)

Produced email:
![Produced email](/ScreenShots/HIC-screenshot3.png)


