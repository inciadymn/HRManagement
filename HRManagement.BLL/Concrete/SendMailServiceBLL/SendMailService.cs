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
        public static bool SendMail(string userMailAdress, string password)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress("hrmanagementsp1@outlook.com");    //Şirketin bir mail adresi olmalı --> Buraya Örn. bir adres yazdım.    
            message.To.Add(userMailAdress);
            message.Subject = "Şifremi Unuttum - Şifre Değiştirme Maili";
            message.IsBodyHtml = true;
            message.Body = string.Format($"<h1 style='font-size:28px;font-weight:300;line-height:150%;margin:0;text-align:center;color:black;background-color:inherit'>Merhabalar</h1>Değerli kullanıcımız şifreniz değiştirilmiştir.<br/> Şifreniz {password}");

            // message.Body'deki href'de verilen url link uzantısı henüz oluşturulmadı.

            smtp.Port = 587;
            smtp.Host = "smtp.office365.com"; // --smtp.radorehosting.com-- Gmail için --> smtp.Host = "smtp.gmail.com"; --- smtp.Host = "smtp.live.com";  //gmail veya hotmail için host için --> Dene????
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("hrmanagementsp1@outlook.com", "HR.man123");   //Mail adresi ve şifre henüz oluşturulmadı. Ör. olarak yazdım.
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
