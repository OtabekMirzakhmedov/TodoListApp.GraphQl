using Microsoft.EntityFrameworkCore;
using TodoListApp.GraphQl.Models;

namespace TodoListApp.GraphQl.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<ItemData> Items { get; set; }

        public virtual DbSet<ItemList> Lists { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemData>(entity =>
            {
                entity.HasOne(d => d.ItemList)
                .WithMany(p => p.ItemDatas)
                .HasForeignKey(d => d.ListId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("Fk_ItemData_ItemList");
            });
        }
    }
}
