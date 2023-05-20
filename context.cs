using Microsoft.EntityFrameworkCore;
using superheores.models;

namespace superheores
{
    public class context:DbContext
    {
       public DbSet<colour> colour {get;set;}   
       public DbSet<gender> genders {get;set;}


        public context(DbContextOptions<context> options) : base(options){}


    }
}

