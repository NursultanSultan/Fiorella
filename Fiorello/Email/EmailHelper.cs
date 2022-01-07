using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Fiorello.Email
{
    public class EmailHelper
    {
        //public bool SendEmail(string userEmail , string confirmationLink)
        //{
        //    MailMessage mailMessage = new MailMessage();
        //    mailMessage.From = new MailAddress("nursultan.sultanov02@gmail.com");
        //    mailMessage.To.Add(new MailAddress(userEmail));

        //    mailMessage.Subject = "Confirm your email";
        //    mailMessage.IsBodyHtml = true;
        //    mailMessage.Body = confirmationLink;

        //    SmtpClient client = new SmtpClient();
        //    client.Credentials = new System.Net.NetworkCredential("nursultan.sultanov02@gmail.com", "yourpassword");
        //    client.Host = "smtp.gmail.com";
        //    client.Port = 587;

        //    try
        //    {
        //        client.Send(mailMessage);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        // log exception
        //    }
        //    return false;
        //}
    }
}
