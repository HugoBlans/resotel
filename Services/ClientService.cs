using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    class ClientService
    {
        public static ClientService instance;

        public static ClientService Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ClientService();
                }
                return instance;
            }
        }

        private ClientService()
        {

        }

        public List<Client> ChargerClients()
        {
            List<Client> lst = new List<Client>();

            using(Entities.AppContext context = new Entities.AppContext())
            {
                lst = context.Clients.ToList();
            }
            return lst;
        }


        public Client Enregistrer(Client cli)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                if (cli.IdentifiantCli > 0)
                {
                    context.Clients.Attach(cli);
                    context.Entry(cli).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    context.Clients.Add(cli);
                }
                context.SaveChanges();
            }
            return cli;
        }

        public bool Supprimer(Client client)
        {
            try
            {
                using( Entities.AppContext context = new Entities.AppContext())
                {
                    context.Clients.Attach(client as Client);
                    context.Clients.Remove(client as Client);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }
    }
}
