using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SchoolManagementDataAcessLayer.Model
{
    public partial class SchoolContext : DbContext
    {

        //public SchoolContext()
        //{
        //}

        public SchoolContext(DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<SchoolDetail> SchoolDetails { get; set; }
        public virtual DbSet<SchoolShift> SchoolShifts { get; set; }
        public virtual DbSet<SchoolType> SchoolTypes { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
            
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog =School;Integrated Security=true");
//            }
            
//        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolDetail>(entity =>
            {
                entity.HasKey(e => e.SchoolName)
                    .HasName("PK__SchoolDe__E3D5B6A4DC5F1C2F");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfInaugration).HasColumnType("date");

                entity.Property(e => e.PrincipalName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SchoolShift>(entity =>
            {
                entity.HasKey(e => new { e.SchoolName, e.SchoolShiftProp })
                    .HasName("PK__SchoolSh__6C52DBF118B17EA8");

                entity.ToTable("SchoolShift");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolShiftProp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SchoolShift");

                entity.HasOne(d => d.SchoolNameNavigation)
                    .WithMany(p => p.SchoolShifts)
                    .HasForeignKey(d => d.SchoolName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolShi__Schoo__2A4B4B5E");
            });

            modelBuilder.Entity<SchoolType>(entity =>
            {
                entity.HasKey(e => new { e.SchoolName, e.SchoolTypeProp })
                    .HasName("PK__SchoolTy__F8B0196821AA5D36");

                entity.ToTable("SchoolType");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolTypeProp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SchoolType");

                entity.HasOne(d => d.SchoolNameNavigation)
                    .WithMany(p => p.SchoolTypes)
                    .HasForeignKey(d => d.SchoolName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SchoolTyp__Schoo__286302EC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
