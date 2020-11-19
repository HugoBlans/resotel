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
            // For test only
            App.Current.Properties["isStandardiste"] = true;
            App.Current.Properties["isHygiene"] = true;
            App.Current.Properties["isRestauration"] = true;
            if (principal.IsInRole(domaine + "\\ResotelHote"))
            {
                App.Current.Properties["isStandardiste"] = true;
                App.Current.Properties["isHygiene"] = true;
                App.Current.Properties["isRestauration"] = true;
            }
            else if (principal.IsInRole(domaine + "\\ResotelStandardiste"))
            {
                App.Current.Properties["isStandardiste"] = true;
            }
            else if (principal.IsInRole(domaine + "\\ResotelHygiene"))
            {
                App.Current.Properties["isHygiene"] = true;
            }
            else if (principal.IsInRole(domaine + "\\ResotelRestauration"))
            {
                App.Current.Properties["isRestauration"] = true;
            }
            else
            {
                Log.Error(this.GetType(), "Utilisateur sans rôle associé");
                //MessageBox.Show("L'utilisateur windows courrant n'a pas les attributions nécessaires pour éxécuter l'application.", "Utilisateur Inconnu",MessageBoxButton.OK, MessageBoxImage.Error);
                //App.Current.Shutdown();
            }


        }
    }
}
