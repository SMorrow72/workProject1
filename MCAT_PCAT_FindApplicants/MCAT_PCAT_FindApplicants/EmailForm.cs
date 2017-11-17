using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LECOM;
using System.Security.Principal;
using System.DirectoryServices.AccountManagement;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace MCAT_PCAT_FindApplicants
{
    public partial class EmailForm : Form
    {
        DataTable mailingList = new DataTable();
        DataTable testMailingList = new DataTable();
        public LECOM.SqlConnection cn = new LECOM.SqlConnection("SIS", "Sarah");
        string fromAddress;

        public EmailForm()
        {
            InitializeComponent();
            string sqlCommand = "SELECT email, fname FROM LECOM_MCAT_PCAT_TABLE WHERE LECOM != 'Match'";

            mailingList.Columns.Add("email", typeof(string));
            mailingList.Columns.Add("name", typeof(string));

            fromAddress = NTEnvironment.CurrentUserPrincipal().EmailAddress;
            fromAddressLabel.Text = fromAddress;

            if(cn.IsOpen)
            {
                //Get info for all non-matches in Mcat Pcat Table
                mailingList = cn.FetchTable(sqlCommand, SQLTypes.Text);
                //Console.WriteLine(mailingList.Rows[0][0].ToString().Trim() + " " + mailingList.Rows[0][1].ToString().Trim());
            }

            //Test Data Configuration
            testMailingList.Columns.Add("email", typeof(string));
            testMailingList.Columns.Add("name", typeof(string));

            testMailingList.Rows.Add("smorrow72@gmail.com", "Sarah");
            testMailingList.Rows.Add("smorrow1272@gmail.com", "Sarah 2: Electric Boogaloo");
            testMailingList.Rows.Add("smorrow@lecom.edu", "Business!Sarah");
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            
            string subject = subTextBox.Text;
            string body = bodyTextBox.Text;

            SendEmail(testMailingList, fromAddress, subject, body, MailPriority.Normal);
        }

        private void SendEmail(DataTable toTable, string From, string Subject, string Body, MailPriority priority)
        {           
            //Set up SMTP client to send mail on the lecom mail server
            SmtpClient client = new SmtpClient("mailserver.lecom.edu", 25);

            //Set Email Addresses
            MailAddress MailFrom = new MailAddress(From, NTEnvironment.CurrentUserPrincipal().EmailAddress);
            //TODO: Check if it sends to this email address too

            //Add each address to an array of MailMessages
            List<MailAddress> addressList = new List<MailAddress>();
            for(int r = 0; r < toTable.Rows.Count; r++)
            {
                //Create a mail address with the email address and name
                MailAddress MailToTmp = new MailAddress(toTable.Rows[r][0].ToString().Trim(), toTable.Rows[r][1].ToString().Trim());
                addressList.Add(MailToTmp);
            }

            try
            {
                foreach(MailAddress address in addressList)
                {
                    MailMessage mail = new MailMessage(MailFrom, address);
                    
                    mail.Subject = Subject;
                    mail.Priority = priority;
                    mail.ReplyToList.Add(mail.From);
                    mail.IsBodyHtml = false;
                    mail.Body = "Hello " + address.DisplayName.ToString() + ", " + Environment.NewLine + Environment.NewLine + Body;

                    client.Send(mail);
                }

                statusLabel.Text = "Emails sent!";
            }
            catch (SmtpFailedRecipientException ex)
            {
                SmtpStatusCode statusCode = ex.StatusCode;

                if (statusCode == SmtpStatusCode.MailboxBusy ||
                    statusCode == SmtpStatusCode.MailboxUnavailable ||
                    statusCode == SmtpStatusCode.TransactionFailed)
                {
                    statusLabel.Text = "Failed to send to: " + ex.FailedRecipient.ToString();

                    switch (statusCode)
                    {
                        case SmtpStatusCode.MailboxBusy:
                            statusLabel.Text += " (Mailbox Busy)";
                            break;
                        case SmtpStatusCode.MailboxUnavailable:
                            statusLabel.Text += " (Mailbox Unavailable)";
                            break;
                        case SmtpStatusCode.TransactionFailed:
                            statusLabel.Text += " (Transaction Failed)";
                            break;
                    }
                }
                else
                {
                    throw;
                }
            }
        }

        //I might not actually need this
        void TokenizeString(string input, string delims, ref List<string> tokens)
        {
            int beg_index = 0;
            int end_index = 0;

            while (end_index != -1)
            {
                end_index = input.IndexOf(delims, beg_index);

                if (end_index != -1)
                    tokens.Add(input.Substring(beg_index, end_index - beg_index));
                else
                    tokens.Add(input.Substring(beg_index, input.Length - beg_index));

                //set the beginning index for the next run through the loop
                beg_index = end_index + 1;
            }
        }
    }
}
