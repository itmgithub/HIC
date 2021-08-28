using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HIC
{
    public partial class frmHIC : Form
    {
        public frmHIC()
        {
            InitializeComponent();
        }

        private void frmHIC_Load(object sender, EventArgs e)
        {
            this.Text = Culture.getText("appTitle");
            lblWelkomText.Text = Culture.getText("lblWelkomText");
            cbxCallMeBack.Text = Culture.getText("cbxCallMeBack");
            cbxScreenShot.Text = Culture.getText("cbxScreenShot");
            btnSubmit.Text = Culture.getText("btnSubmit");
            tbxContactDetail.Text = Culture.getText("tbxContactDetail");

            if (!HICConfig.allowContact)
            {
                cbxCallMeBack.Visible = false;
                tbxContactDetail.Visible = false;
            }

        }

        private void cbxCallMeBack_CheckedChanged(object sender, EventArgs e)
        {
            tbxContactDetail.Enabled = !tbxContactDetail.Enabled;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            List<string> attachments = new List<string>();
            mailIssue reportMail;
            SystemReport systemReport = new SystemReport();


            if (!String.IsNullOrEmpty(tbxIssueDescription.Text))
            {
                if (cbxScreenShot.Checked)
                {

                    Screenshot screenshot = new Screenshot();
                    attachments = screenshot.takeScreenshot(this);
                }
                if (!cbxCallMeBack.Checked)
                {
                    reportMail = new mailIssue(tbxIssueDescription.Text, "");
                }
                else
                {
                    reportMail = new mailIssue(tbxIssueDescription.Text, tbxContactDetail.Text);
                }


                attachments.Add(systemReport.buildSystemReport());

                reportMail.reportViaMail(attachments);

                attachments.ForEach(delegate (string fName)
                {
                    try
                    {
                        File.Delete(fName);
                    }
                    catch { };
                });

                Application.Exit();
            }
            else
            {
                MessageBox.Show(Culture.getText("errNonDescription"), "HIC Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
