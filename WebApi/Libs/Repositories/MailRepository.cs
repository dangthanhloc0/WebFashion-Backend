using Libs.Helps;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System.Runtime.InteropServices;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Libs.Repositories
{
    public interface IIMail
    {
        bool SendMail(MailData Mail_Data, String url);
    }
    public class MailRepository : IIMail
    {
        private MailSettings Mail_Settings;
        public MailRepository(IOptions<MailSettings> options)
        {
            Mail_Settings = options.Value;
        }

        public bool SendMail(MailData Mail_Data, String code )
        {
            try
            {
                //MimeMessage - a class from Mimekit
                MimeMessage email_Message = new MimeMessage();
                MailboxAddress email_From = new MailboxAddress(Mail_Settings.Name, Mail_Settings.EmailId);
                email_Message.From.Add(email_From);
                MailboxAddress email_To = new MailboxAddress("Đang test xem nó là gì ", Mail_Data.EmailToId);
                email_Message.To.Add(email_To);
                email_Message.Subject = "Lấy lại mật khẩu";
                string randomString = code;
                String duoi = randomString +" </h2 ></div >s                               <div style = 'background-color: #1877F2; border: 2px #1877F2 solid; border-width: 10px; border-radius:10px; text-align: center;  ' >                                <a style = 'text-decoration: none; font-size: 30px; color: white; font-weight: bold;' href = '' >                                          Đổi mật khẩu                                </a >                           </div>                             <h1 style ='text-align:center;' > Cảm ơn bạn đã ủng hộ chúng tôi </h1 >                       </body>                       </html> ";
                BodyBuilder emailBodyBuilder = new BodyBuilder
                {
                    HtmlBody = @" 
                        <html>
                        <body style ='margin-left:100px;margin-top:20px;font-family:'Times New Roman',Times, serif;'>
                             <img style='width:50px;height:50px;'  src ='cid:myImage' alt ='Image' />
                             <div style='border:1px rgb(102, 99, 99) solid;'></div > 
                             <h3> Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu YODY của bạn </ h3 > 
                             <p> Nhập mã đặt lại mật khẩu sau đây:</ p > 
                             <div style = 'border: 1px rgb(104, 104, 214) solid; border-radius: 10px; width: 150px ; height: 50px; background-color:#E7F3FF; margin: 5px 0; ' > 
                              <h2 style = 'margin-top: 9px ; margin-left: 12px ;'>" + duoi
                };




            // Chèn ảnh vào nội dung email
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "images/rateProduct/246x0w.webp");
                var image = emailBodyBuilder.LinkedResources.Add(imagePath);
                image.ContentId = "myImage"; // Đặt Content-ID để tham chiếu trong HTML
                email_Message.Body = emailBodyBuilder.ToMessageBody();
                //this is the SmtpClient class from the Mailkit.Net.Smtp namespace, not the System.Net.Mail one
                SmtpClient MailClient = new SmtpClient();
                MailClient.Connect(Mail_Settings.Host, Mail_Settings.Port, Mail_Settings.UseSSL);
                MailClient.Authenticate(Mail_Settings.EmailId, Mail_Settings.Password);
                MailClient.Send(email_Message);
                MailClient.Disconnect(true);
                MailClient.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                return false;
            }
        }
    }
}
