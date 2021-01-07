namespace Reseaarch_Alliances.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ResearchAlliances : DbContext
    {
        public ResearchAlliances()
            : base("name=ResearchAlliances")
        {
        }

        public virtual DbSet<tbladmin> tbladmin { get; set; }
        public virtual DbSet<tblarticle> tblarticles { get; set; }
        public virtual DbSet<tblarticlecomment> tblarticlecomments { get; set; }
        public virtual DbSet<tblarticlelike> tblarticlelikes { get; set; }
        public virtual DbSet<tblcategory> tblcategories { get; set; }
        public virtual DbSet<tblcity> tblcities { get; set; }
        public virtual DbSet<tblresearch> tblresearches { get; set; }
        public virtual DbSet<tblresearchfollower> tblresearchfollowers { get; set; }
        public virtual DbSet<tblresearchrequest> tblresearchrequests { get; set; }
        public virtual DbSet<tblresearchupdate> tblresearchupdates { get; set; }
        public virtual DbSet<tblresearchupdatelike> tblresearchupdatelikes { get; set; }
        public virtual DbSet<tblspecialization> tblspecializations { get; set; }
        public virtual DbSet<tblstate> tblstates { get; set; }
        public virtual DbSet<tblsubcategory> tblsubcategories { get; set; }
        public virtual DbSet<tbluser> tblusers { get; set; }
        public virtual DbSet<tbluserspecialization> tbluserspecializations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbladmin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tbladmin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tblarticle>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<tblarticle>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tblarticle>()
                .Property(e => e.FeaturedImage)
                .IsUnicode(false);

            modelBuilder.Entity<tblarticle>()
                .HasMany(e => e.tblarticlecomments)
                .WithRequired(e => e.tblarticle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblarticle>()
                .HasMany(e => e.tblarticlelikes)
                .WithRequired(e => e.tblarticle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblarticlecomment>()
                .Property(e => e.Comment)
                .IsUnicode(false);

            modelBuilder.Entity<tblcategory>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<tblcategory>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tblcity>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            modelBuilder.Entity<tblresearch>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<tblresearch>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tblresearch>()
                .Property(e => e.FeaturedImage)
                .IsUnicode(false);

            modelBuilder.Entity<tblresearch>()
                .HasMany(e => e.tblresearchfollowers)
                .WithRequired(e => e.tblresearch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblresearch>()
                .HasMany(e => e.tblresearchrequests)
                .WithRequired(e => e.tblresearch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblresearch>()
                .HasMany(e => e.tblresearchupdates)
                .WithRequired(e => e.tblresearch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblresearchupdate>()
                .Property(e => e.UpdateDescription)
                .IsUnicode(false);

            modelBuilder.Entity<tblresearchupdate>()
                .HasMany(e => e.tblresearchupdatelikes)
                .WithRequired(e => e.tblresearchupdate)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblspecialization>()
                .Property(e => e.Specialization)
                .IsUnicode(false);

            modelBuilder.Entity<tblspecialization>()
                .HasMany(e => e.tbluserspecializations)
                .WithRequired(e => e.tblspecialization)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblstate>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<tblsubcategory>()
                .Property(e => e.SubCategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<tblsubcategory>()
                .HasMany(e => e.tblspecializations)
                .WithRequired(e => e.tblsubcategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbluser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<tbluser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tbluser>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<tbluser>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<tbluser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbluser>()
                .Property(e => e.ProfilePic)
                .IsUnicode(false);

            modelBuilder.Entity<tbluser>()
                .Property(e => e.MoNumber)
                .IsUnicode(false);

            modelBuilder.Entity<tbluser>()
                .HasMany(e => e.tblarticlecomments)
                .WithRequired(e => e.tbluser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbluser>()
                .HasMany(e => e.tblarticlelikes)
                .WithRequired(e => e.tbluser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbluser>()
                .HasMany(e => e.tblresearchfollowers)
                .WithRequired(e => e.tbluser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbluser>()
                .HasMany(e => e.tblresearchrequests)
                .WithRequired(e => e.tbluser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbluser>()
                .HasMany(e => e.tblresearchupdates)
                .WithRequired(e => e.tbluser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbluser>()
                .HasMany(e => e.tblresearchupdatelikes)
                .WithRequired(e => e.tbluser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbluser>()
                .HasMany(e => e.tbluserspecializations)
                .WithRequired(e => e.tbluser)
                .WillCascadeOnDelete(false);
        }
    }
}
