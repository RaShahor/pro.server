using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Entities;
#nullable disable

namespace DAL
{
    public partial class SignContext : DbContext
    {
        public SignContext()
        {
        }

        public SignContext(DbContextOptions<SignContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<FormSigner> FormSigners { get; set; }
        public virtual DbSet<FormTemplate> FormTemplates { get; set; }
        public virtual DbSet<FormToSigner> FormToSigners { get; set; }
        public virtual DbSet<FormUser> FormUsers { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Sign> Signs { get; set; }
        public virtual DbSet<Signer> Signers { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer(MyPc);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Hebrew_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.HasIndex(e => new { e.Name, e.OfficeId }, "class_unique")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("name")
                    .IsFixedLength(true);

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Office");
            });

            modelBuilder.Entity<FormSigner>(entity =>
            {
                entity.ToTable("form_signer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClassId)
                    .HasColumnName("class_id")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.FormTosignerId).HasColumnName("formTosigner_id");

                entity.Property(e => e.Known).HasColumnName("known?");

                entity.Property(e => e.SavedAtFile)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("saved_at_file");

                entity.Property(e => e.SignedFrom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("signed_from");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.FormSigners)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("class_id_fk");

                entity.HasOne(d => d.FormTosigner)
                    .WithMany(p => p.FormSigners)
                    .HasForeignKey(d => d.FormTosignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_form_signer_form_to_signer");
            });

            modelBuilder.Entity<FormTemplate>(entity =>
            {
                entity.ToTable("form_template");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.FormUserId).HasColumnName("form_user_id");

                entity.HasOne(d => d.FormUser)
                    .WithMany(p => p.FormTemplates)
                    .HasForeignKey(d => d.FormUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_form_template_form_user");
            });

            modelBuilder.Entity<FormToSigner>(entity =>
            {
                entity.ToTable("formToSigner");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class).HasColumnName("class");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.SignerId).HasColumnName("Signer_id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.FormToSigners)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_formToSigner_formToUser");

                entity.HasOne(d => d.Signer)
                    .WithMany(p => p.FormToSigners)
                    .HasForeignKey(d => d.SignerId)
                    .HasConstraintName("FTSSIGNER");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.FormToSigners)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("FK_formToSigner_Status");
            });

            modelBuilder.Entity<FormUser>(entity =>
            {
                entity.ToTable("form_user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FormName)
                    .HasMaxLength(50)
                    .HasColumnName("form_name");

                entity.Property(e => e.FormTemplateId).HasColumnName("form_template_id");

                entity.Property(e => e.NumOfSigners)
                    .HasColumnName("num_of_signers")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("path");

                entity.Property(e => e.Resign).HasColumnName("resign");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.FormTemplate)
                    .WithMany(p => p.FormUsers)
                    .HasForeignKey(d => d.FormTemplateId)
                    .HasConstraintName("ftfu_fk");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FormUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Userfu_fk");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.ToTable("Office");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.Fee)
                    .HasColumnType("money")
                    .HasColumnName("fee");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FName)
                    .HasMaxLength(20)
                    .HasColumnName("f_name");

                entity.Property(e => e.IdentityNumber)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("identity_number");

                entity.Property(e => e.LName)
                    .HasMaxLength(20)
                    .HasColumnName("l_name");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("mail");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("password");

                entity.Property(e => e.Salt)
                    .HasMaxLength(20)
                    .HasColumnName("salt")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("RATING");

                entity.Property(e => e.RatingId).HasColumnName("RATING_ID");

                entity.Property(e => e.Host)
                    .HasMaxLength(50)
                    .HasColumnName("HOST");

                entity.Property(e => e.Method)
                    .HasMaxLength(10)
                    .HasColumnName("METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.Path)
                    .HasMaxLength(50)
                    .HasColumnName("PATH");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Referer)
                    .HasMaxLength(100)
                    .HasColumnName("REFERER");

                entity.Property(e => e.UserAgent).HasColumnName("USER_AGENT");
            });

            modelBuilder.Entity<Sign>(entity =>
            {
                entity.ToTable("Sign");

                entity.HasIndex(e => new { e.FormId, e.PageNum }, "form_id_non_clustered_index");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasDefaultValueSql("(N'A')");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.PageNum)
                    .HasColumnName("pageNum")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.X1).HasColumnName("x1");

                entity.Property(e => e.X2).HasColumnName("x2");

                entity.Property(e => e.Y1).HasColumnName("y1");

                entity.Property(e => e.Y2).HasColumnName("y2");

                entity.HasOne(d => d.ClassNavigation)
                    .WithMany(p => p.Signs)
                    .HasForeignKey(d => d.Class)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sign_Class");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.Signs)
                    .HasForeignKey(d => d.FormId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SIGN_form");
            });

            modelBuilder.Entity<Signer>(entity =>
            {
                entity.ToTable("Signer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Signers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Signer_Person");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Signers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("Usersigner_fk");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.HasIndex(e => e.Status1, "UQ__status__A858923C32262B09")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status1)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("status");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OfficeId).HasColumnName("office_id");

                entity.Property(e => e.PersonId).HasColumnName("person_id");

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OfficeId)
                    .HasConstraintName("FK_USER_Office");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USER_Person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
