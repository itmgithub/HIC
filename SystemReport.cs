using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace HIC
{
    class SystemReport
    {

        // Return the environment variables for this user/system.
        private string getAllEnvironmentVariables()
        {
            var allEV = String.Format("{0,-25}   {1}\n", "Key:", "Value:");

            allEV += "----------------------------------------------------------------------\n";
            foreach (DictionaryEntry e in System.Environment.GetEnvironmentVariables())
            {
                allEV += String.Format("{0,-25} = {1}\n", e.Key, e.Value);
            }
            allEV += "\n";
            return allEV;
        }

        // Return all drives, freespace and ready status
        private string listAllDrives()
        {
            var allDrives = String.Format("{0,-32}   {1,-16} (Drive ready)\n", "Drive name:", "Free space:");

            allDrives += "----------------------------------------------------------------------\n";
            try
            {
                foreach (DriveInfo d in DriveInfo.GetDrives())
                {
                    if (d.IsReady)
                    {
                        allDrives += String.Format("{0,-32} : {1,16} (Ready: YES)\n", d.Name, d.TotalFreeSpace);
                    }
                    else
                    {
                        allDrives += String.Format("{0,-32} : {1,16} (Ready: NO)\n", d.Name, -1);
                    }
                }
            }
            catch { }
            allDrives += "\n";
            return allDrives;
        }

        // List processes
        private string listAllProcesses()
        {
            Process[] procList = Process.GetProcesses();
            var allProc = String.Format("{0,-10} : {1,-40} ({2,-10}) NR\n", "PID:", "Process name:", "VirMemSize");

            allProc += "----------------------------------------------------------------------\n";
            try
            {
                foreach (Process p in procList)
                {
                    allProc += String.Format("{0,-10} : {1,-40} ({2,10})", p.Id, p.ProcessName, p.VirtualMemorySize.ToString());
                    if (!p.Responding)
                    {
                        allProc += " NR\n";
                    }
                    else
                    {
                        allProc += "\n";
                    }
                }
            }
            catch { }
            allProc += "\n";
            return allProc;
        }

        // Calculate the Windows uptime in milliseconds.
        private TimeSpan upTime()
        {
            var u = new PerformanceCounter("System", "System Up Time");
            u.NextValue();
            return TimeSpan.FromSeconds(u.NextValue());
        }


        public string buildSystemReport()
        {
            string tmpFName;
            tmpFName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".rtf";

            RichTextBox rapportBox = new RichTextBox();

            rapportBox.Clear();
            rapportBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rapportBox.AppendText(Application.ProductName + " version " + Application.ProductVersion + " problem report\n");
            rapportBox.AppendText("----------------------------------------------------------------------\n");
            rapportBox.AppendText("Generated on  : " + DateTime.Now.ToString() + "\n");
            rapportBox.AppendText("Windows uptime: " + upTime().ToString() + "\n");
            rapportBox.AppendText("Locale        : " + CultureInfo.CurrentCulture.Name + "\n");
            rapportBox.AppendText("User          : " + Environment.UserDomainName.ToUpper() + "\\" + Environment.UserName + "\n");
            rapportBox.AppendText("\n\n\n");
            rapportBox.AppendText(listAllDrives());
            rapportBox.AppendText(getAllEnvironmentVariables());
            rapportBox.AppendText(listAllProcesses());
            rapportBox.SaveFile(tmpFName);

            return tmpFName;
        }
    }
}
