﻿using Microsoft.EntityFrameworkCore;
using EducationForum.Domain;
using EducationForum.Domain.ViewModels;

namespace EducationForum.DataAccess
{
    public class EForumDBContext : DbContext
    {
        public EForumDBContext(DbContextOptions<EForumDBContext> options) : base(options)
        {

        }
        [DbFunction("EncryptPassword", "EForum")]
        public static Byte[] Encrypt(string password)
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
        public DbSet<GradeSubjectMap> GradeSubjectMaps { get; set; } = null!;
        public DbSet<MasterInstructiveLanguage> MasterInstructiveLanguages { get; set; } = null!;
        public DbSet<EnquiryQueue> EnquiryQueues { get; set; } = null!;
        public DbSet<MasterBoards> Boards { get; set; } = null!;

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
            modelBuilder.Entity<MasterBoards>(entity =>
            {
                entity.HasKey(e => e.BoardID);
                entity.ToTable("Boards", "EForumMaster");
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
            modelBuilder.Entity<StudentEnquiry>(entity =>
            {
                entity.ToTable("StudentEnquiry", "EForum");
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(GETDATE())");

                entity.HasMany(e => e.studentEnquiryGradeSubjectMaps).WithOne(e => e.StudentEnquiry)
                .HasForeignKey(e => e.EnquiryID)
                .HasConstraintName("FK_StudentEnquiry_studentEnquiryGradeSubjectMaps");

                entity.HasOne(e => e.ClassTypes).WithOne(e => e.StudentEnquiry)
                .HasForeignKey<StudentEnquiry>(e => e.ClassTypeID)
                .HasConstraintName("FK_StudentEnquiry_ClassTypeID").OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.InstructiveLanguage).WithOne(e => e.StudentEnquiry)
                .HasForeignKey<StudentEnquiry>(e => e.InstructiveLanguageID)
                .HasConstraintName("FK_StudentEnquiry_InstructiveLanguageID").OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Boards).WithOne(e => e.Enquiry)
                .HasForeignKey<StudentEnquiry>(e => e.BoardID)
                .HasConstraintName("FK_StudentEnquiry_BoardID").OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<StudentEnquiryGradeSubjectMap>(entity =>
            {
                entity.ToTable("StudentEnquiryGradeSubjectMap", "EForum");
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(GETDATE())");

                entity.HasOne(e => e.Grade)
                .WithMany(e => e.StudentEnquiryGradeSubjectMaps)
                .HasForeignKey(e => e.GradeID)
                .HasConstraintName("FK_StudentEnquiryGradeSubjectMaps_GradeID").OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Subject)
               .WithMany(e => e.StudentEnquiryGradeSubjectMaps)
               .HasForeignKey(e => e.SubjectID)
               .HasConstraintName("FK_StudentEnquiryGradeSubjectMaps_SubjectID").OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<GradeSubjectMap>(entity =>
            {
                entity.ToTable("GradeSubjectMap", "EForum");
                entity.Property(e => e.IsActive).HasDefaultValueSql("(1)");
                entity.Property(e => e.DateAdded).HasDefaultValueSql("(GETDATE())");
            });
            modelBuilder.Entity<MasterInstructiveLanguage>(entity =>
            {
                entity.HasKey(e => e.InstructiveLanguageID);
                entity.ToTable("InstructiveLanguage", "EForumMaster");
            });
        }
    }
}
