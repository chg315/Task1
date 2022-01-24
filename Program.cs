using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EASendMail;


namespace Task
{
    class Program
    {
        public static bool CheckMail(string mail)
        {
            if (mail.Length == 0)
                return false;
            else //בדיקה שהטקסט מכיל את הסימנים '.' ו-'@'.
                if ((mail.IndexOf("@") == -1) || (mail.IndexOf(".") == -1)||((mail.IndexOf(".") == -1)&& (mail.IndexOf("@") == -1)))
                return false;
            else //אם הכתובת נכונה
                return true;
        }
      public static void Func_Send_Email(string email, string subject, string body)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");
                oMail.From = "devgcx@gmail.com";
                oMail.To = email;
                oMail.Subject = subject;
                oMail.TextBody = body;
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                oServer.User = "devgcx@gmail.com";
                oServer.Password = "HelloWorld8@.!a[]hd";
                oServer.Port = 587;
                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();


                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }


        }
    

       static void Main(string[] args)
        {
            string email="";
            bool b = false;
            while (b == false)
            {
                Console.WriteLine("Receiver e-mail address");
                email = Console.ReadLine();
                b = CheckMail(email);
                if (b == false)
                    Console.WriteLine("the mail not valid");
            }
            Console.WriteLine("Subject");
            string subject = Console.ReadLine();
            while(subject=="")
            {
                Console.WriteLine("Subject");
                 subject = Console.ReadLine();
            }
            Console.WriteLine("Body");
            string body = Console.ReadLine();
            Func_Send_Email(email,subject,body);
        }
    }
}
