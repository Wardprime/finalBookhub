using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookhubApi.Modelss
{
    public partial class Dbookhub : DbContext
    {
        public Dbookhub()
        {
        }

        public Dbookhub(DbContextOptions<Dbookhub> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Coment> Coments { get; set; }
        public virtual DbSet<ImagenBook> ImagenBooks { get; set; }
        public virtual DbSet<ImagenPerfil> ImagenPerfils { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NH96RKR;Initial Catalog=BookHub;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("books");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Book1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("book");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users");
            });

            modelBuilder.Entity<Coment>(entity =>
            {
                entity.HasKey(e => e.ComentsId)
                    .HasName("PK__coments__4714759766E2842B");

                entity.ToTable("coments");

                entity.Property(e => e.ComentsId).HasColumnName("coments_id");

                entity.Property(e => e.Coment1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("coment");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.PublicationId).HasColumnName("publication_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Publication)
                    .WithMany(p => p.Coments)
                    .HasForeignKey(d => d.PublicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkbooks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Coments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usersfk");
            });

            modelBuilder.Entity<ImagenBook>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("imagenBook");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Imagen)
                    .HasColumnType("text")
                    .HasColumnName("imagen");

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imagnbook");
            });

            modelBuilder.Entity<ImagenPerfil>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("imagenPerfil");

                entity.Property(e => e.Imagen)
                    .HasColumnType("text")
                    .HasColumnName("imagen");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("imagenUser");
            });

            modelBuilder.Entity<Publication>(entity =>
            {
                entity.ToTable("publication");

                entity.Property(e => e.PublicationId).HasColumnName("publication_id");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("estado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Publication1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("publication");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_books");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("roles");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("role");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userole");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Contra)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("contra");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("correo");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
