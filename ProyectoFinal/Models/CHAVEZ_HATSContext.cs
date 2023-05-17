using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoFinal.Models
{
    public partial class CHAVEZ_HATSContext : DbContext
    {
        public CHAVEZ_HATSContext()
        {
        }

        public CHAVEZ_HATSContext(DbContextOptions<CHAVEZ_HATSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barbiquejo> Barbiquejos { get; set; } = null!;
        public virtual DbSet<Clase> Clases { get; set; } = null!;
        public virtual DbSet<Forro> Forros { get; set; } = null!;
        public virtual DbSet<InfoEnvio> InfoEnvios { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<Sombrero> Sombreros { get; set; } = null!;
        public virtual DbSet<Tafilete> Tafiletes { get; set; } = null!;
        public virtual DbSet<Talla> Tallas { get; set; } = null!;
        public virtual DbSet<TamanoTalla> TamanoTallas { get; set; } = null!;
        public virtual DbSet<TiposUsario> TiposUsarios { get; set; } = null!;
        public virtual DbSet<Toquilla> Toquillas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<VentasSombrero> VentasSombreros { get; set; } = null!;
        public virtual DbSet<VentasUsuario> VentasUsuarios { get; set; } = null!;
        public virtual DbSet<Ventum> Venta { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-7G1AFOC\\SQLEXPRESS; DataBase=CHAVEZ_HATS; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barbiquejo>(entity =>
            {
                entity.HasKey(e => e.IdBarbiquejo)
                    .HasName("PK__BARBIQUE__79D980F9C8FBF94E");

                entity.ToTable("BARBIQUEJO");

                entity.HasIndex(e => e.NomBarbiquejo, "UQ__BARBIQUE__7B02ABAD798CFF3F")
                    .IsUnique();

                entity.Property(e => e.IdBarbiquejo).HasColumnName("ID_BARBIQUEJO");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NomBarbiquejo)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOM_BARBIQUEJO");
            });

            modelBuilder.Entity<Clase>(entity =>
            {
                entity.HasKey(e => e.IdClase)
                    .HasName("PK__CLASE__38C14A3EBBF9C176");

                entity.ToTable("CLASE");

                entity.HasIndex(e => e.NomClase, "UQ__CLASE__872CDD1CD3520235")
                    .IsUnique();

                entity.Property(e => e.IdClase).HasColumnName("ID_CLASE");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NomClase)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOM_CLASE");
            });

            modelBuilder.Entity<Forro>(entity =>
            {
                entity.HasKey(e => e.IdForro)
                    .HasName("PK__FORRO__278A63787A1C61CC");

                entity.ToTable("FORRO");

                entity.HasIndex(e => e.NomForro, "UQ__FORRO__A0AEF9A8B1EC5D53")
                    .IsUnique();

                entity.Property(e => e.IdForro).HasColumnName("ID_FORRO");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NomForro)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOM_FORRO");
            });

            modelBuilder.Entity<InfoEnvio>(entity =>
            {
                entity.HasKey(e => e.IdInfoEnvio)
                    .HasName("PK__INFO_ENV__095C85CAE6765BF5");

                entity.ToTable("INFO_ENVIO");

                entity.HasIndex(e => e.IdUsuario, "UQ__INFO_ENV__91136B9145270AA1")
                    .IsUnique();

                entity.Property(e => e.IdInfoEnvio).HasColumnName("ID_INFO_ENVIO");

                entity.Property(e => e.Calle)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CALLE")
                    .IsFixedLength();

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CIUDAD")
                    .IsFixedLength();

                entity.Property(e => e.CodigoPostal)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO_POSTAL")
                    .IsFixedLength();

                entity.Property(e => e.Colonia)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("COLONIA")
                    .IsFixedLength();

                entity.Property(e => e.Estado)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("ESTADO")
                    .IsFixedLength();

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Numero)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO")
                    .IsFixedLength();

                entity.Property(e => e.Telefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TELEFONO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithOne(p => p.InfoEnvio)
                    .HasForeignKey<InfoEnvio>(d => d.IdUsuario)
                    .HasConstraintName("FK__INFO_ENVI__ID_US__398D8EEE");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("PK__MATERIAL__B47FC5A357DCB3F8");

                entity.ToTable("MATERIAL");

                entity.Property(e => e.IdMaterial).HasColumnName("ID_MATERIAL");

                entity.Property(e => e.Hab)
                    .IsRequired()
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdBarbiquejo).HasColumnName("ID_BARBIQUEJO");

                entity.Property(e => e.IdForro).HasColumnName("ID_FORRO");

                entity.Property(e => e.IdTafiletes).HasColumnName("ID_TAFILETES");

                entity.Property(e => e.IdToquilla).HasColumnName("ID_TOQUILLA");

                entity.Property(e => e.Ojillos).HasColumnName("OJILLOS");

                entity.Property(e => e.Resorte).HasColumnName("RESORTE");

                entity.HasOne(d => d.IdBarbiquejoNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdBarbiquejo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MATERIAL__ID_BAR__440B1D61");

                entity.HasOne(d => d.IdForroNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdForro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MATERIAL__ID_FOR__4316F928");

                entity.HasOne(d => d.IdTafiletesNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdTafiletes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MATERIAL__ID_TAF__44FF419A");

                entity.HasOne(d => d.IdToquillaNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdToquilla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MATERIAL__ID_TOQ__4222D4EF");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(e => e.IdModelo)
                    .HasName("PK__MODELO__26C704A02AD494A2");

                entity.ToTable("MODELO");

                entity.HasIndex(e => e.NomModelo, "UQ__MODELO__9934385521648526")
                    .IsUnique();

                entity.Property(e => e.IdModelo).HasColumnName("ID_MODELO");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NomModelo)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOM_MODELO");
            });

            modelBuilder.Entity<Sombrero>(entity =>
            {
                entity.HasKey(e => e.IdSombrero)
                    .HasName("PK__SOMBRERO__ADD0DAA87935EE1C");

                entity.ToTable("SOMBRERO");

                entity.Property(e => e.IdSombrero).HasColumnName("ID_SOMBRERO");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdClase).HasColumnName("ID_CLASE");

                entity.Property(e => e.IdMaterial).HasColumnName("ID_MATERIAL");

                entity.Property(e => e.IdModelo).HasColumnName("ID_MODELO");

                entity.Property(e => e.IdTalla).HasColumnName("ID_TALLA");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEN")
                    .HasDefaultValueSql("('PLACEHOLDER')");

                entity.Property(e => e.MedFalda).HasColumnName("MED_FALDA");

                entity.Property(e => e.Personalizado)
                    .HasColumnName("PERSONALIZADO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("PRECIO");

                entity.Property(e => e.Stock)
                    .HasColumnName("STOCK")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdClaseNavigation)
                    .WithMany(p => p.Sombreros)
                    .HasForeignKey(d => d.IdClase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SOMBRERO__ID_CLA__49C3F6B7");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Sombreros)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SOMBRERO__ID_MAT__4AB81AF0");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Sombreros)
                    .HasForeignKey(d => d.IdModelo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SOMBRERO__ID_MOD__48CFD27E");

                entity.HasOne(d => d.IdTallaNavigation)
                    .WithMany(p => p.Sombreros)
                    .HasForeignKey(d => d.IdTalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SOMBRERO__ID_TAL__4BAC3F29");
            });

            modelBuilder.Entity<Tafilete>(entity =>
            {
                entity.HasKey(e => e.IdTafiletes)
                    .HasName("PK__TAFILETE__5639FF24092D52E9");

                entity.ToTable("TAFILETES");

                entity.HasIndex(e => e.NomTafiletes, "UQ__TAFILETE__1B73DCE2DD46B6D8")
                    .IsUnique();

                entity.Property(e => e.IdTafiletes).HasColumnName("ID_TAFILETES");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NomTafiletes)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOM_TAFILETES");
            });

            modelBuilder.Entity<Talla>(entity =>
            {
                entity.HasKey(e => e.IdTalla)
                    .HasName("PK__TALLA__6E1990BE652BAC77");

                entity.ToTable("TALLA");

                entity.HasIndex(e => e.NomTalla, "UQ__TALLA__7995DCB924672FBD")
                    .IsUnique();

                entity.Property(e => e.IdTalla).HasColumnName("ID_TALLA");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NomTalla)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("NOM_TALLA");
            });

            modelBuilder.Entity<TamanoTalla>(entity =>
            {
                entity.HasKey(e => e.IdTamTalla)
                    .HasName("PK__TAMANO_T__176978DD779E7A9D");

                entity.ToTable("TAMANO_TALLA");

                entity.HasIndex(e => e.TamTalla, "UQ__TAMANO_T__E1CB43A19095E9ED")
                    .IsUnique();

                entity.Property(e => e.IdTamTalla).HasColumnName("ID_TAM_TALLA");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTalla).HasColumnName("ID_TALLA");

                entity.Property(e => e.TamTalla).HasColumnName("TAM_TALLA");

                entity.HasOne(d => d.IdTallaNavigation)
                    .WithMany(p => p.TamanoTallas)
                    .HasForeignKey(d => d.IdTalla)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TAMANO_TA__ID_TA__3E52440B");
            });

            modelBuilder.Entity<TiposUsario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOS_US__85A05968861D2159");

                entity.ToTable("TIPOS_USARIO");

                entity.HasIndex(e => e.NomTipoUsuario, "UQ__TIPOS_US__293F21167A8B112D")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NomTipoUsuario)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("NOM_TIPO_USUARIO");
            });

            modelBuilder.Entity<Toquilla>(entity =>
            {
                entity.HasKey(e => e.IdToquilla)
                    .HasName("PK__TOQUILLA__F36A34C338E1CB15");

                entity.ToTable("TOQUILLA");

                entity.HasIndex(e => e.NomToquilla, "UQ__TOQUILLA__509DBBF442B94A8A")
                    .IsUnique();

                entity.Property(e => e.IdToquilla).HasColumnName("ID_TOQUILLA");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.NomToquilla)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("NOM_TOQUILLA");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__91136B90E6191D8E");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Correo, "UQ__USUARIO__264F33C854775EE2")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENA");

                entity.Property(e => e.Correo)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("ID_TIPO_USUARIO");

                entity.Property(e => e.NomUsuario)
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasColumnName("NOM_USUARIO");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__ID_TIPO__34C8D9D1");
            });

            modelBuilder.Entity<VentasSombrero>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VENTAS_SOMBRERO");

                entity.Property(e => e.IdSombrero).HasColumnName("ID_SOMBRERO");

                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");

                entity.Property(e => e.Precio)
                    .HasColumnType("money")
                    .HasColumnName("PRECIO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UndVendidas)
                    .HasColumnName("UND_VENDIDAS")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdSombreroNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSombrero)
                    .HasConstraintName("FK__VENTAS_SO__ID_SO__534D60F1");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK__VENTAS_SO__ID_VE__52593CB8");
            });

            modelBuilder.Entity<VentasUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VENTAS_USUARIO");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__VENTAS_US__ID_US__5812160E");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdVenta)
                    .HasConstraintName("FK__VENTAS_US__ID_VE__571DF1D5");
            });

            modelBuilder.Entity<Ventum>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__VENTA__F3B6C1B462133025");

                entity.ToTable("VENTA");

                entity.Property(e => e.IdVenta).HasColumnName("ID_VENTA");

                entity.Property(e => e.FchVenta)
                    .HasColumnType("date")
                    .HasColumnName("FCH_VENTA")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Hab)
                    .HasColumnName("HAB")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TotalVenta)
                    .HasColumnType("money")
                    .HasColumnName("TOTAL_VENTA")
                    .HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
