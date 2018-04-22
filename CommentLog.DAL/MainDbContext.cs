using CommentLog.DAL;
using CommentLog.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentLog.DAL
{
    public class MainDbContext : DbContext
    {
        public MainDbContext():base("name=DefaultConnection")
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }

   
}
