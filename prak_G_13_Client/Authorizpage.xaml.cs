using System;
using System.Collections.Generic;
using System.Linq;
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

namespace prak_G_13_Client
{
    /// <summary>
    /// Interaction logic for Authorizpage.xaml
    /// </summary>
    public partial class Authorizpage : Page
    {
        public Authorizpage()
        {
            InitializeComponent();
            Api.getuser();
        }
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string clientemail = mailtb.Text;
            if (IsValidEmail(clientemail))
            {
                user us = Api.lstus.Where(x => x.Email == clientemail && x.Password == passtb.Text).FirstOrDefault();
                if (us==null)
                {
                    return;
                }
                else
                {
                    Api.itus = us;
                    Data.mainframe.NavigationService.Navigate(new Errorpage());
                }
            }
        }
    }
}
