using Microsoft.EntityFrameworkCore;
using School_API.Core.Models;

namespace School_API.Infrastructure.Persistence;

public partial class SchoolApiContext : DbContext
{
    public SchoolApiContext()
    {
    }

    public SchoolApiContext(DbContextOptions<SchoolApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Curriculum> Curriculums { get; set; }

    public virtual DbSet<CurriculumSubject> CurriculumSubjects { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupSubject> GroupSubjects { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsGroup> StudentsGroups { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<User> Users { get; set; }





    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Careers__3214EC0758D5CC07");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Curriculum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curricul__3214EC073664E94B");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Career).WithMany(p => p.Curricula)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK__Curriculu__Caree__60A75C0F");
        });

        modelBuilder.Entity<CurriculumSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curricul__3214EC07473A4C6C");

            entity.HasOne(d => d.Curriculum).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.CurriculumId)
                .HasConstraintName("FK__Curriculu__Curri__656C112C");

            entity.HasOne(d => d.Semester).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__Curriculu__Semes__6754599E");

            entity.HasOne(d => d.Subject).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Curriculu__Subje__66603565");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC07E6E4F54A");

            entity.Property(e => e.Unit1).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Unit2).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Unit3).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC079FAE31AA");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<GroupSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupSub__3214EC0774EBB702");

            entity.HasOne(d => d.Grades).WithMany(p => p.GroupSubjects)
                .HasForeignKey(d => d.GradesId)
                .HasConstraintName("FK__GroupSubj__Grade__6B24EA82");

            entity.HasOne(d => d.StudentGroup).WithMany(p => p.GroupSubjects)
                .HasForeignKey(d => d.StudentGroupId)
                .HasConstraintName("FK__GroupSubj__Stude__6C190EBB");

            entity.HasOne(d => d.Subject).WithMany(p => p.GroupSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__GroupSubj__Subje__6A30C649");

            entity.HasOne(d => d.Teacher).WithMany(p => p.GroupSubjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__GroupSubj__Teach__6D0D32F4");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Periods__3214EC071CEA6249");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semester__3214EC07FAAED1F1");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07032BA56F");

            entity.HasOne(d => d.Career).WithMany(p => p.Students)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK__Students__Career__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Students__UserId__4D94879B");
        });

        modelBuilder.Entity<StudentsGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0731D5597B");

            entity.HasOne(d => d.Group).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__StudentsG__Group__59063A47");

            entity.HasOne(d => d.Period).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK__StudentsG__Perio__59FA5E80");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentsG__Stude__5812160E");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC077B2321E0");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3214EC0701944261");

            entity.ToTable("Teacher");

            entity.Property(e => e.Speciality).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Teacher__UserId__5165187F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07D048D1B8");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Enrollment).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(255);
            entity.Property(e => e.Salt).HasMaxLength(50);
            entity.Property(e => e.SecondNames).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
