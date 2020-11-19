using ProjetRESOTEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL.Services
{
    public class ClientsService
    {
        public int AddClient(Client client)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                if (client != null)
                {
                    context.Clients.Add(client);
                    context.SaveChanges();
                }
            }
            return client.IdentifiantCli;
        }

        public Client GetClient(int? id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return context.Clients.Find(id);
            }
        }

        public List<Client> GetAllClients()
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                return context.Clients.ToList();
            }
        }

        public void UpdateClient(Client client)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                Client clientToUpdate = context.Clients.Find(client.IdentifiantCli);
                if (clientToUpdate != null)
                {
                    clientToUpdate.Nom = client.Nom;
                    clientToUpdate.Prenom = client.Prenom;
                    clientToUpdate.Telephone = client.Telephone;
                    clientToUpdate.Email = client.Email;
                    context.SaveChanges();
                }
            }
        }

        public void RemoveClient(int? id)
        {
            using (Entities.AppContext context = new Entities.AppContext())
            {
                Client clientToRemove = context.Clients.Find(id);
                if (clientToRemove != null)
                {
                    context.Clients.Remove(clientToRemove);
                    context.SaveChanges();
                }
            }
        }
    }
}
