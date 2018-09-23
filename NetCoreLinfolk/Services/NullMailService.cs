using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetCoreLinfolk.Services
{
    public class NullMailService : IMailService 
    {
        private readonly ILogger<NullMailService> _logger;

        public NullMailService(ILogger<NullMailService> logger)
        {
            _logger = logger;
        }

        public void SendMessage(string To, string Subject, string Body)
        {
            //log the message
            _logger.LogInformation($"To: {To} Subject: {Subject } Body: {Body}");
            sendMail("thilankaranasinghe1989@gmail.com",1,Body, Subject);
        }
        
        public static SmtpClient GetSMTP()
        {
            //smtpClient.Port = 25;
            SmtpClient smtpClient = new SmtpClient();
            //smtpClient.UseDefaultCredentials = true;
            //smtpClient.Host = "192.168.3.11";
            smtpClient.Host = "smtp.live.com";
            //smtpClient.Port = 25;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("thilankaranasinghe1989@hotmail.com", "Pathfi1989");
            return smtpClient;
        }

        public static void sendMail(string Email, int type,string Body, string Subject)
        {

            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = GetSMTP();
            mail.IsBodyHtml = true;

            mail.From = new MailAddress("thilankaranasinghe1989@hotmail.com");
            if (type == 1)
            {
                mail.To.Add(Email);
            }
            else if (type == 2)
            {
                mail.CC.Add(Email);
            }
            else
            {
                mail.Bcc.Add(Email);
            }

            mail.Subject = Subject;
            mail.Body = Body;

            smtpClient.Send(mail);
        }

        public static MailMessage sendDynamicMail(List<String[]> mailList, string subject, string body)
        {
            //int recieverId, string Body, string Subject
            // List string have emailAddress emailType subject body respectively 0 1 2 3
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;

            mail.From = new MailAddress("cdbcrm@cdb.lk");
            foreach (var list in mailList)
            {
                if (list[1] == "1")
                {
                    mail.To.Add(list[0]);
                }
                else if (list[1] == "2")
                {
                    mail.CC.Add(list[0]);
                }
                else
                {
                    mail.Bcc.Add(list[0]);
                }
            }

            mail.Subject = subject;
            mail.Body = body;

            //skip errors of the SSL certificate
            //ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            //{ 
            //    return true; 
            //};

            return mail;
        }

        public static string PopulateAlternate(string template, string reciever, string customer, string description, string subjectId, string subject)
        {

            //string template = string.Empty;
            ////var htmlGenericControl = new System.Web.HttpServerUtility();
            var regex = new Regex("{.*?}");
            var matches = regex.Matches(template);
            var connectionString = "Connection String";
            foreach (var match in matches)
            {
                string queryString = "SELECT * FROM EmailKeyword WHERE Keyword='" + match + "'";
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(queryString, connection);
                    connection.Open();
                    List<String> columns = new List<String>();
                    List<Array> tables = new List<Array>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            //string secondCommand = "SELECT "+reader["ColumnName"].ToString()+" FROM " + reader["TableName"].ToString() + " WHERE CustomerID = "+ customer;

                            columns.Add(reader["ColumnName"].ToString());
                            columns.Add(reader["TableName"].ToString());
                            tables.Add(columns.ToArray());
                            //if (ddlTables.Items.FindByText(reader["COLUMN_NAME"].ToString()) == null)
                            //{
                            //    ddlColumn.DataTextField = "COLUMN_NAME";
                            //    ddlColumn.Items.Add(reader["COLUMN_NAME"].ToString());
                            //}
                            //Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));
                            //ddlTables.DataSource 
                        }
                    }

                    foreach (var info in tables)
                    {
                        string secondCommand = "SELECT " + info.GetValue(0) + " FROM " + info.GetValue(1) + " WHERE CustomerID = " + customer;
                        var command2 = new SqlCommand(secondCommand, connection);
                        //using (var reader2 = command2.ExecuteReader())
                        //{
                        //    //while (reader2.Read())
                        //{
                        string readValue = command2.ExecuteScalar().ToString();

                        template = info.GetValue(0).ToString() == "DateOfBirth" ? template.Replace(match.ToString(), Convert.ToDateTime(readValue).ToString().Substring(0, 10)) : template.Replace(match.ToString(), readValue);
                        //}
                        //}

                    }
                }

            }
            //get keywords to a list
            return template;
        }

        public static string PopulateBody(string template, string User, string MembershipNumber, string url, string description, string Image, string subjectId)
        {

            //string template = string.Empty;
            ////var htmlGenericControl = new System.Web.HttpServerUtility();
            //var regex = new Regex("{.*?}");
            //var matches = regex.Matches(template);
            //var connectionString = ConfigurationManager.ConnectionStrings["CustomerLoyaltyContext"].ConnectionString;
            //foreach (var match in matches) 
            //{
            //    string queryString = "SELECT * FROM EmailKeyword WHERE Keyword="+match;
            //    using (var connection = new SqlConnection(connectionString))
            //    {
            //        var command = new SqlCommand(queryString, connection);
            //        connection.Open();
            //        using (var reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                if (reader["ColumnName"] == "CustomerID" || reader["ColumnName"] == "CustomerId") 
            //                {

            //                }
            //                string secondCommand = "SELECT * FROM " + reader["TableName"].ToString() + " WHERE "; 
            //                //if (ddlTables.Items.FindByText(reader["COLUMN_NAME"].ToString()) == null)
            //                //{
            //                //    ddlColumn.DataTextField = "COLUMN_NAME";
            //                //    ddlColumn.Items.Add(reader["COLUMN_NAME"].ToString());
            //                //}
            //                //Console.WriteLine(String.Format("{0}, {1}", reader[0], reader[1]));

            //                //ddlTables.DataSource 
            //            }
            //        }
            //    }

            //}
            ////get keywords to a list


            template = template.Replace("{SubjectNumber}", subjectId);
            template = template.Replace("{MembershipNumber}", MembershipNumber);
            template = template.Replace("{Url}", url);
            template = template.Replace("{Description}", description);
            template = template.Replace("{Image}", Image);
            template = template.Replace("{User}", User);
            return template;

        }
    }
}
