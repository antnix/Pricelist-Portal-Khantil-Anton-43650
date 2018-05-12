namespace Pricelist_Portal_Khantil_Anton_43650.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.SqlClient;

    public partial class PricelistModel : DbContext
    {
        public PricelistModel()
            : base("name=PricelistConnection")
        {
        }

        public virtual DbSet<Headphone> Headphones { get; set; }
        public virtual DbSet<TV> TVs { get; set; }

        public static void ClearTables(string tableName)
        {
            using (PricelistModel db = new PricelistModel())
                db.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tableName}]");
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Headphone>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<TV>()
                .Property(e => e.Price)
                .HasPrecision(10, 2);
        }
    }
}
