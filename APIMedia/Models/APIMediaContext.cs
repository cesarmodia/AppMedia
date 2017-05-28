using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIMedia.Models
{
    public class APIMediaContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public APIMediaContext() : base("name=APIMediaContext")
        {
        }

        public System.Data.Entity.DbSet<APIMedia.Models.Image> Images { get; set; }

        public System.Data.Entity.DbSet<APIMedia.Models.Video> Videos { get; set; }
    }
}
