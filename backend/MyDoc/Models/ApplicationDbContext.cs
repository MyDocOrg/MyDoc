using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MyDoc.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Cita { get; set; }

    public virtual DbSet<Consultorio> Consultorio { get; set; }

    public virtual DbSet<ConsultorioMedico> ConsultorioMedico { get; set; }

    public virtual DbSet<Consulta> Consulta { get; set; }

    public virtual DbSet<EstadoCita> EstadoCita { get; set; }

    public virtual DbSet<HistorialMedico> HistorialMedico { get; set; }

    public virtual DbSet<MedicacionHorario> MedicacionHorario { get; set; }

    public virtual DbSet<Medicamento> Medicamento { get; set; }

    public virtual DbSet<Medico> Medico { get; set; }

    public virtual DbSet<Notificacion> Notificacion { get; set; }

    public virtual DbSet<Paciente> Paciente { get; set; }

    public virtual DbSet<RecetaMedicamento> RecetaMedicamento { get; set; }

    public virtual DbSet<Receta> Receta { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost;Database=MyDoc;Trusted_Connection=True;TrustServerCertificate=True");

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        modelBuilder.Entity<Cita>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Cita__3214EC07CDDE6E48");

//            entity.Property(e => e.Fecha).HasColumnType("datetime");

//            entity.HasOne(d => d.Consultorio).WithMany(p => p.Cita)
//                .HasForeignKey(d => d.ConsultorioId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Cita_Consultorio");

//            entity.HasOne(d => d.EstadoNavigation).WithMany(p => p.Cita)
//                .HasForeignKey(d => d.Estado)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Estado_Cita");

//            entity.HasOne(d => d.Medico).WithMany(p => p.Cita)
//                .HasForeignKey(d => d.MedicoId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Cita_Medico");

//            entity.HasOne(d => d.Paciente).WithMany(p => p.Cita)
//                .HasForeignKey(d => d.PacienteId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Cita_Paciente");
//        });

//        modelBuilder.Entity<Consultorio>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Consulto__3214EC077532CA3A");

//            entity.ToTable("Consultorio");

//            entity.Property(e => e.Direccion).HasMaxLength(200);
//            entity.Property(e => e.Email).HasMaxLength(100);
//            entity.Property(e => e.Nombre).HasMaxLength(100);
//            entity.Property(e => e.Telefono).HasMaxLength(20);
//        });

//        modelBuilder.Entity<ConsultorioMedico>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Consulto__3214EC073D490FFD");

//            entity.ToTable("ConsultorioMedico");

//            entity.HasOne(d => d.Consultorio).WithMany(p => p.ConsultorioMedicos)
//                .HasForeignKey(d => d.ConsultorioId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CM_Consultorio");

//            entity.HasOne(d => d.Medico).WithMany(p => p.ConsultorioMedicos)
//                .HasForeignKey(d => d.MedicoId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_CM_Medico");
//        });

//        modelBuilder.Entity<Consulta>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Consulta__3214EC07BCDD5672");

//            entity.Property(e => e.Diagnostico).IsUnicode(false);
//            entity.Property(e => e.Fecha).HasColumnType("datetime");
//            entity.Property(e => e.Motivo).IsUnicode(false);

//            entity.HasOne(d => d.Consultorio).WithMany(p => p.Consulta)
//                .HasForeignKey(d => d.ConsultorioId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Consulta_Consultorio");

//            entity.HasOne(d => d.Medico).WithMany(p => p.Consulta)
//                .HasForeignKey(d => d.MedicoId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Consulta_Medico");

//            entity.HasOne(d => d.Paciente).WithMany(p => p.Consulta)
//                .HasForeignKey(d => d.PacienteId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Consulta_Paciente");
//        });

//        modelBuilder.Entity<EstadoCita>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__EstadoCi__3214EC07FFDBA4B0");

//            entity.Property(e => e.Description).HasMaxLength(100);
//            entity.Property(e => e.Nombre).HasMaxLength(100);
//        });

//        modelBuilder.Entity<HistorialMedico>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Historia__3214EC07B5D98EEC");

//            entity.ToTable("HistorialMedico");

//            entity.Property(e => e.Diagnostico).HasMaxLength(500);
//            entity.Property(e => e.FechaRegistro)
//                .HasDefaultValueSql("(getdate())")
//                .HasColumnType("datetime");
//            entity.Property(e => e.Observaciones).HasMaxLength(500);

//            entity.HasOne(d => d.Cita).WithMany(p => p.HistorialMedicos)
//                .HasForeignKey(d => d.CitaId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Historial_Cita");

//            entity.HasOne(d => d.Consulta).WithMany(p => p.HistorialMedicos)
//                .HasForeignKey(d => d.ConsultaId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Historial_Consulta");
//        });

//        modelBuilder.Entity<MedicacionHorario>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Medicaci__3214EC078083D931");

//            entity.ToTable("MedicacionHorario");

//            entity.Property(e => e.Tomado).HasDefaultValue(false);

//            entity.HasOne(d => d.Medicamento).WithMany(p => p.MedicacionHorarios)
//                .HasForeignKey(d => d.MedicamentoId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_MH_Medicamento");

//            entity.HasOne(d => d.Receta).WithMany(p => p.MedicacionHorarios)
//                .HasForeignKey(d => d.RecetaId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_MH_Receta");
//        });

//        modelBuilder.Entity<Medicamento>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Medicame__3214EC0729D10FAB");

//            entity.ToTable("Medicamento");

//            entity.Property(e => e.Descripcion).HasMaxLength(200);
//            entity.Property(e => e.Nombre).HasMaxLength(100);
//            entity.Property(e => e.Presentacion).HasMaxLength(50);
//        });

//        modelBuilder.Entity<Medico>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Medico__3214EC077FC7035D");

//            entity.ToTable("Medico");

//            entity.Property(e => e.CedulaProfesional).HasMaxLength(50);
//            entity.Property(e => e.Email).HasMaxLength(100);
//            entity.Property(e => e.Especialidad).HasMaxLength(100);
//            entity.Property(e => e.Nombre).HasMaxLength(100);
//            entity.Property(e => e.Telefono).HasMaxLength(20);
//        });

//        modelBuilder.Entity<Notificacion>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC0730519A48");

//            entity.ToTable("Notificacion");

//            entity.Property(e => e.Enviada).HasDefaultValue(false);
//            entity.Property(e => e.FechaEnvio).HasColumnType("datetime");

//            entity.HasOne(d => d.MedicacionHorario).WithMany(p => p.Notificacions)
//                .HasForeignKey(d => d.MedicacionHorarioId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Notificacion_Horario");
//        });

//        modelBuilder.Entity<Paciente>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Paciente__3214EC07C8882169");

//            entity.ToTable("Paciente");

//            entity.Property(e => e.Direccion).HasMaxLength(200);
//            entity.Property(e => e.Email).HasMaxLength(100);
//            entity.Property(e => e.Nombre).HasMaxLength(100);
//            entity.Property(e => e.Sexo)
//                .HasMaxLength(1)
//                .IsUnicode(false)
//                .IsFixedLength();
//            entity.Property(e => e.Telefono).HasMaxLength(20);
//        });

//        modelBuilder.Entity<RecetaMedicamento>(entity =>
//        {
//            entity
//                .HasNoKey()
//                .ToTable("RecetaMedicamento");

//            entity.Property(e => e.Dosis).HasMaxLength(100);
//            entity.Property(e => e.Duracion).HasMaxLength(50);
//            entity.Property(e => e.Frecuencia).HasMaxLength(100);

//            entity.HasOne(d => d.IdNavigation).WithMany()
//                .HasForeignKey(d => d.Id)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_RM_Receta");

//            entity.HasOne(d => d.Medicamento).WithMany()
//                .HasForeignKey(d => d.MedicamentoId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_RM_Medicamento");
//        });

//        modelBuilder.Entity<Receta>(entity =>
//        {
//            entity.HasKey(e => e.Id).HasName("PK__Receta__3214EC071C38E693");

//            entity.Property(e => e.Fecha)
//                .HasDefaultValueSql("(getdate())")
//                .HasColumnType("datetime");
//            entity.Property(e => e.IndicacionesGenerales).HasMaxLength(500);

//            entity.HasOne(d => d.HistorialMedico).WithMany(p => p.Receta)
//                .HasForeignKey(d => d.HistorialMedicoId)
//                .OnDelete(DeleteBehavior.ClientSetNull)
//                .HasConstraintName("FK_Receta_Historial");
//        });

//        OnModelCreatingPartial(modelBuilder);
//    }

//    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
