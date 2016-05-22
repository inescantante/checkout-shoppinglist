using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using ShoppingList.Models;

namespace ShoppingList.Infrastructure.DbContext
{
    public class ShoppingListDbContext : System.Data.Entity.DbContext
    {
        public ShoppingListDbContext() : base(nameOrConnectionString: "ShoppingListConnectionString")
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Consumer> Consumers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Item>().Property(t => t.Name)
                .IsRequired().HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
                        new IndexAttribute("Name_constraint", 1) { IsUnique = true }));

            modelBuilder.Entity<Consumer>().Property(t => t.Username)
                .IsRequired().HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(
                        new IndexAttribute("Username_contraint", 1) { IsUnique = true }));

            base.OnModelCreating(modelBuilder);
        }
    }
    
}