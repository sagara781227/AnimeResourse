namespace AnimeResource.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AnimeContext : DbContext
    {
        public AnimeContext()
            : base("name=AnimeContext")
        {
        }

        public virtual DbSet<anime> animes { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<country> countries { get; set; }
        public virtual DbSet<mark> marks { get; set; }
        public virtual DbSet<profile> profiles { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<serii> seriis { get; set; }
        public virtual DbSet<sex> sexs { get; set; }
        public virtual DbSet<sound> sounds { get; set; }
        public virtual DbSet<type> types { get; set; }
        public virtual DbSet<typeser> typesers { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<users_anime> users_anime { get; set; }
        public virtual DbSet<whatch_seasons> whatch_seasons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<anime>()
                .Property(e => e.nameanim)
                .IsUnicode(false);

            modelBuilder.Entity<anime>()
                .Property(e => e.about)
                .IsUnicode(false);

            modelBuilder.Entity<anime>()
                .Property(e => e.year)
                .IsUnicode(false);

            modelBuilder.Entity<anime>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<anime>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<anime>()
                .HasMany(e => e.comments)
                .WithRequired(e => e.anime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<anime>()
                .HasMany(e => e.marks)
                .WithRequired(e => e.anime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<anime>()
                .HasMany(e => e.seriis)
                .WithRequired(e => e.anime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<anime>()
                .HasMany(e => e.users_anime)
                .WithRequired(e => e.anime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<comment>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.sername)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<profile>()
                .Property(e => e.about)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<role>()
                .HasMany(e => e.users)
                .WithRequired(e => e.role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<serii>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<serii>()
                .HasMany(e => e.whatch_seasons)
                .WithRequired(e => e.serii)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<sex>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sound>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<type>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<type>()
                .HasMany(e => e.animes)
                .WithMany(e => e.types)
                .Map(m => m.ToTable("types_anime", "animedb").MapLeftKey("id_type").MapRightKey("id_anime"));

            modelBuilder.Entity<typeser>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<typeser>()
                .HasMany(e => e.seriis)
                .WithRequired(e => e.typeser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.pasword)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.e_mail)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.comments)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.marks)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasOptional(e => e.profile)
                .WithRequired(e => e.user);

            modelBuilder.Entity<user>()
                .HasMany(e => e.users_anime)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<users_anime>()
                .HasMany(e => e.whatch_seasons)
                .WithRequired(e => e.users_anime)
                .HasForeignKey(e => new { e.id_user, e.id_anime })
                .WillCascadeOnDelete(false);
        }
    }
}
