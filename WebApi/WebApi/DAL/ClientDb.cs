using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace WebApi.DAL
{
    public class ClientDb :DbContext
    {
        public ClientDb() :base("ClientDb")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Client> client { get; set; }
        public DbSet<ClientAddress> clientAddresses { set; get; }


    }
}