using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
public class BlogContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=blog;User Id=postgres;Password=postgres;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Comment>(
            entity =>
            {
                entity.HasOne(e => e.Post)
                    .WithMany(e => e.Comments)
                    .HasForeignKey(e => e.PostId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Comment_Post");
            }
        );

        modelBuilder.Entity<Comment>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("NOW()");

        modelBuilder.Entity<Comment>()
            .Property(p => p.PostId)
            .UseIdentityColumn();

        modelBuilder.Entity<Post>()
            .Property(p => p.PostId)
            .UseIdentityColumn();

        modelBuilder.Entity<Post>()
            .Property(c => c.CreatedAt)
            .HasDefaultValueSql("NOW()");


    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
}