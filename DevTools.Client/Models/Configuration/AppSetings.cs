using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;

namespace DevTools.Client.Models.Configuration
{
    class AppSetings : INotifyPropertyChanged
    {
        private readonly System.Configuration.Configuration _configuration;

        public AppSetings(System.Configuration.Configuration configuration)
        {
            _configuration = configuration;
        }

        public string ApiHost
        {
            get
            {
                return _configuration.AppSettings.Settings[nameof(ApiHost)]?.Value.ToString();
            }
            set
            {
                if(value != ApiHost)
                {
                    _configuration.AppSettings.Settings.Remove(nameof(ApiHost));
                    OnPropertyChanged(nameof(ApiHost));
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName) {});
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
