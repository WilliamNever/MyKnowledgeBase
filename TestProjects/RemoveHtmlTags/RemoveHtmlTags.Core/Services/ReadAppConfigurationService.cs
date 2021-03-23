using RemoveHtmlTags.Core.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveHtmlTags.Core.Services
{
    public class ReadAppConfigurationService
    {
        public ReadAppConfigurationService()
        {

        }
        public AppSettingsModel ReadAppConfig()
        {
            return new AppSettingsModel
            {
                MainRegx = System.Configuration.ConfigurationManager.AppSettings["MainRegx"]
            };
        }
    }
}
