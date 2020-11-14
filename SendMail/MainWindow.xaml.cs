using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMail
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(emailBody.Document.ContentStart, emailBody.Document.ContentEnd);
            string Aliciemail = emailAlici.Text;
            string mailHeader = emailHeader.Text;
            string mailBody = range.Text;
            string mailSender = emailSender.Text;
            string emailPass = emailPassword.Password;
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(mailSender);
                mail.To.Add(Aliciemail);
                mail.Subject = mailHeader;
                mail.Body = mailBody;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(mailSender, emailPass);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("E-posta Gönderildi");
            }
            catch (Exception)
            {

                MessageBox.Show("E-posta Gönderilmedi!\n Lütfen Eposta sağlayıcı ayarlarına bakın");
            }
        }
    }
}
