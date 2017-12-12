using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using unirest_net.http;

namespace WpfDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnTranslate.IsEnabled = false;
        }

        private void btnTranslate_Click(object sender, RoutedEventArgs e)
        {
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://yoda.p.mashape.com/");
            //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("X-Mashape-Key", "zVcTJBa3H3mshvcot6As86uycEnep1ZKEkdjsnL8GBGUY6UWMF");
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
            //   var response= client.GetAsync("yoda?sentence="+ txtWords.Text.Trim().ToString()).Result;

            //    string json = new JavaScriptSerializer().Serialize(jsonResult.Data);
            //}  

            try
            {
                Task<HttpResponse<string>> response = Unirest.get("https://yoda.p.mashape.com/yoda?sentence=" + txtWords.Text.Trim().ToString())
                .header("X-Mashape-Key", "zVcTJBa3H3mshvcot6As86uycEnep1ZKEkdjsnL8GBGUY6UWMF")
                .header("Accept", "text/plain").asStringAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void txtWords_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtWords.Text.Trim() == string.Empty)
            {
                btnTranslate.IsEnabled = false;
            }
            else
            {
                btnTranslate.IsEnabled = true;
            }
        }
    }
}
