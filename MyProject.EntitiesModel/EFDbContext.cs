namespace MyProject.EntitiesModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=EFDbContext")
        {
        }
        
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        public virtual DbSet<JobType> JobType { get; set; }
        public virtual DbSet<ApplyJob> ApplyJob { get; set; }

        public virtual DbSet<WorkExperience> WorkExperience { get; set; }
        public virtual DbSet<ProjectExperience> ProjectExperience { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.PassWord)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.CompanyName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.Address)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.Tel)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.Email)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.Manager)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.ImgUrl)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.ThumbUrl)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.LicenseUrl)
            //    .IsUnicode(false);

            //modelBuilder.Entity<CompanyInfo>()
            //    .Property(e => e.Describe)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Jobs>()
            //    .Property(e => e.JobName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Jobs>()
            //    .Property(e => e.Describe)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Jobs>()
            //    .Property(e => e.DemandType)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Jobs>()
            //    .Property(e => e.SalaryUpper)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<Jobs>()
            //    .Property(e => e.SalaryLower)
            //    .HasPrecision(19, 4);

            //modelBuilder.Entity<Operator>()
            //    .Property(e => e.OperatName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<Operator>()
            //    .Property(e => e.Password)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Username)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Password)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Name)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.School)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Specialty)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Knowledge)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Tel)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Email)
            //    .IsUnicode(false);

            //modelBuilder.Entity<UserInfo>()
            //    .Property(e => e.Describe)
            //    .IsUnicode(false);
        }
    }
}
