using Octokit;
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
    /// Interaction logic for Errorpage.xaml
    /// </summary>
    public partial class Errorpage : System.Windows.Controls.Page
    {
        public Errorpage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(formattb.Text);
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    Error it = new Error();
                    it.Error_id = 0;
                    it.Dop_time = 0;
                    it.Error_name = "Format error";
                    it.Error_type_id = 1;
                    Api.posterror(it);
                }
            }
           

        }
    }
}
