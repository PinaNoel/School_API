
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

    public virtual DbSet<ActualPeriodSubject> ActualPeriodSubjects { get; set; }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Curriculum> Curriculums { get; set; }

    public virtual DbSet<CurriculumSubject> CurriculumSubjects { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupPeriod> GroupPeriods { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsGroup> StudentsGroups { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActualPeriodSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ActualPe__3214EC07E33F30AA");

            entity.HasOne(d => d.GroupPeriods).WithMany(p => p.ActualPeriodSubjects)
                .HasForeignKey(d => d.GroupPeriodsId)
                .HasConstraintName("FK__ActualPer__Group__5BE2A6F2");

            entity.HasOne(d => d.TeacherSubjects).WithMany(p => p.ActualPeriodSubjects)
                .HasForeignKey(d => d.TeacherSubjectsId)
                .HasConstraintName("FK__ActualPer__Teach__5AEE82B9");
        });

        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Careers__3214EC07D671A2F4");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Curriculum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curricul__3214EC075ED7B071");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Career).WithMany(p => p.Curricula)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK__Curriculu__Caree__49C3F6B7");
        });

        modelBuilder.Entity<CurriculumSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curricul__3214EC071A3E89CE");

            entity.HasOne(d => d.Curriculum).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.CurriculumId)
                .HasConstraintName("FK__Curriculu__Curri__4E88ABD4");

            entity.HasOne(d => d.Semester).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__Curriculu__Semes__5070F446");

            entity.HasOne(d => d.Subject).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Curriculu__Subje__4F7CD00D");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC076615FB71");

            entity.Property(e => e.Unit1).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Unit2).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Unit3).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC072F9A5033");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<GroupPeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupPer__3214EC07EE8A26D8");

            entity.HasOne(d => d.Group).WithMany(p => p.GroupPeriods)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__GroupPeri__Group__5812160E");

            entity.HasOne(d => d.Period).WithMany(p => p.GroupPeriods)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK__GroupPeri__Perio__571DF1D5");
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Periods__3214EC0710F0808E");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semester__3214EC073E7A7712");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC076329D56D");

            entity.HasOne(d => d.Career).WithMany(p => p.Students)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK__Students__Career__3C69FB99");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Students__UserId__3B75D760");
        });

        modelBuilder.Entity<StudentsGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC073FB8206A");

            entity.HasOne(d => d.ActualPeriodSubjects).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.ActualPeriodSubjectsId)
                .HasConstraintName("FK__StudentsG__Actua__60A75C0F");

            entity.HasOne(d => d.Grades).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.GradesId)
                .HasConstraintName("FK__StudentsG__Grade__5EBF139D");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentsG__Stude__5FB337D6");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC076A9CBFC9");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teacher__3214EC0793386B43");

            entity.ToTable("Teacher");

            entity.Property(e => e.Speciality).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Teacher__UserId__3F466844");
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherS__3214EC07FF902EA0");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__TeacherSu__Subje__5441852A");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherSu__Teach__534D60F1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07A18945CA");

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
