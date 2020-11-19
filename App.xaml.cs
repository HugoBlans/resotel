using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetRESOTEL
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            var domaine = System.Environment.UserDomainName;

            if (principal.IsInRole(domaine + "\\ResotelHote"))
            {
                App.Current.Properties["isStandardiste"] = true;
                App.Current.Properties["isHygiene"] = true;
                App.Current.Properties["isRestauration"] = true;
            }
            else
            {
                App.Current.Properties["isStandardiste"] = principal.IsInRole(domaine + "\\ResotelStandardiste");
                App.Current.Properties["isHygiene"] = principal.IsInRole(domaine + "\\ResotelHygiene");
                App.Current.Properties["isRestauration"] = principal.IsInRole(domaine + "\\ResotelRestauration");
            }

            // For test only
            App.Current.Properties["isStandardiste"] = true;
            App.Current.Properties["isHygiene"] = true;
            App.Current.Properties["isRestauration"] = true;
        }
    }
}
