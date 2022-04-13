using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.BLL.Concrete.SendMailServiceBLL
{
    public class SendMailService
    {
        public static bool SendMail(string userMailAdress)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress("redteamproject@outlook.com");    //Şirketin bir mail adresi olmalı --> Buraya Örn. bir adres yazdım.    
            message.To.Add(userMailAdress);
            message.Subject = "Şifremi Unuttum - Şifre Değiştirme Maili";
            message.IsBodyHtml = true;
            message.Body = string.Format("<!DOCTYPE html> <html> <head> <meta charset='utf-8'/> <title></title> </head> <body> <h1> Şifre Değiştirme Maili </h1> <p> Merhaba </p> <p> Şifrenizi unuttuğunuz için size bu mail gönderildi. </p> <br /> <p> Şifrenizi değiştirmek için <a href='https://hrmanagementproject.azurewebsites.net/User/ChangePassword'> bu linke tıklayınız. </p> </body> </html>");

            // message.Body'deki href'de verilen url link uzantısı henüz oluşturulmadı.

            smtp.Port = 587;
            smtp.Host = "smtp.office365.com"; // --smtp.radorehosting.com-- Gmail için --> smtp.Host = "smtp.gmail.com"; --- smtp.Host = "smtp.live.com";  //gmail veya hotmail için host için --> Dene????
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("redteamproject@outlook.com", "123toci123");   //Mail adresi ve şifre henüz oluşturulmadı. Ör. olarak yazdım.
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtp.Send(message);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
