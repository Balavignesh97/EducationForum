using Microsoft.EntityFrameworkCore;
using EducationForum.Domain;

namespace EducationForum.DataAccess
{
    public class EForumDBContext : DbContext
    {
        public EForumDBContext(DbContextOptions<EForumDBContext> options) : base(options)
        {

        }
        [DbFunction("EncryptPassword", "EForum")]
        public static Byte[] Encrypt(Guid userid, string password)
        {
            throw new NotImplementedException();
        }
        public DbSet<MasterState> States { get; set; } = null!;
        public DbSet<MasterGender> Genders { get; set; } = null!;
        public DbSet<MasterUserType> UserTypes { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TemplateCourses> TemplateCourses { get; set; } = null!;

        public DbSet<Subjects> Subjects { get; set; } = null!;
        public DbSet<Grades> Grades { get; set; } = null!;
        public DbSet<ClassTypes> ClassTypes { get; set; } = null!;
        public DbSet<StudentEnquiry> StudentEnquiry { get; set; } = null!;
        public DbSet<StudentEnquiryGradeSubjectMap> StudentEnquiryGradeSubjectMap { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterState>(entity =>
            {
                entity.HasKey(e => e.StateID);
                entity.ToTable("State", "EForumMaster");
            });
            modelBuilder.Entity<MasterGender>(entity =>
            {
                entity.HasKey(e => e.GenderID);
                entity.ToTable("Gender", "EForumMaster");
            });
            modelBuilder.Entity<MasterUserType>(entity =>
            {
                entity.HasKey(e => e.UserTypeID);
                entity.ToTable("UserType", "EForumMaster");
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserID);
                entity.ToTable("User", "EForum");
                //entity.Property(e => e.DateAdded)
                //    .HasColumnType("datetime")
                //    .HasDefaultValue("(getdate())");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.IsActive).HasDefaultValueSql("(1)");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("(0)");
                entity.Property(e => e.IsLocked).HasDefaultValueSql("(0)");
                entity.Property(e => e.IsTwoFactorAuthentication).HasDefaultValueSql("(0)");
                entity.Property(e => e.UserGUID).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<TemplateCourses>(entity =>
            {
                entity.HasKey(e => e.CourseTemplateID);
                entity.ToTable("Courses", "Template");
                entity.Property(e => e.IsActive).HasDefaultValueSql("(1)");
                entity.Property(e => e.IsDeleted).HasDefaultValueSql("(0)");
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(GETDATE())");
            });

            
            modelBuilder.Entity<Subjects>().ToTable("Subjects", "EForumMaster");
            modelBuilder.Entity<Grades>().ToTable("Grade", "EForumMaster");
            modelBuilder.Entity<ClassTypes>().ToTable("ClassType", "EForumMaster");
            modelBuilder.Entity<StudentEnquiry>().ToTable("StudentEnquiry", "EForum");
            modelBuilder.Entity<StudentEnquiryGradeSubjectMap>().ToTable("StudentEnquiryGradeSubjectMap", "EForum");
        }
    }
}
