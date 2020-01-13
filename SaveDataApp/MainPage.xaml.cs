using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SaveDataApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public string name = "123";
        public string pwd = "456";
        public string address = "789";

        public string Name {
            get {
                return name;
            }
            set {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Pwd
        {
            get
            {
                return pwd;
            }
            set
            {
                pwd = value;
                OnPropertyChanged();
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            VM = new MyViewModel();
        }

        private MyViewModel VM { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string json = JsonConvert.SerializeObject(VM);
            // save json.
            localSettings.Values["example"] = json;

            // Read data from setting.
            Object value = localSettings.Values["example"];
            MyViewModel model = JsonConvert.DeserializeObject<MyViewModel>(value.ToString());
            
        }
    }
}
