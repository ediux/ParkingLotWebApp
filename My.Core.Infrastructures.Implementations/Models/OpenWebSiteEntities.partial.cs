using My.Core.Infrastructures.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Core.Infrastructures.Implementations.Models
{
    public partial class OpenWebSiteEntities : IUnitOfWork
    {
        private bool _requireuniqueEmail = false;
        public bool RequireUniqueEmail { get { return _requireuniqueEmail; } set { _requireuniqueEmail = value; } }

        public DbContext Context
        {
            get
            {
                return this;
            }

            set
            {
                
            }
        }

        public bool LazyLoadingEnabled
        {
            get
            {
                return Configuration.LazyLoadingEnabled;
            }

            set
            {
                Configuration.LazyLoadingEnabled = value;
            }
        }

        public bool ProxyCreationEnabled
        {
            get
            {
                return Configuration.ProxyCreationEnabled;
            }

            set
            {
                Configuration.ProxyCreationEnabled = value;
            }
        }

        public string ConnectionString
        {
            get
            {
               return Database.Connection.ConnectionString;
            }

            set
            {
                Database.Connection.ConnectionString = value;
            }
        }

        public OpenWebSiteEntities(string nameorconnectionstring)
            : base(nameorconnectionstring)
        {
            _requireuniqueEmail = false;
        }

        public static OpenWebSiteEntities Create()
        {
            return new OpenWebSiteEntities();
        }

        public void Commit()
        {
            SaveChanges();
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
        }
    }
}
