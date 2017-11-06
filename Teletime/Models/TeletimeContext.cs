using System;
using Microsoft.EntityFrameworkCore;

namespace Teletime.Models
{
    public class TeletimeContext : DbContext
    {
		public TeletimeContext(DbContextOptions<TeletimeContext> options)
			: base(options)
        {
        }

		public DbSet<Cargo> Cargos { get; set; }
		public DbSet<Departamento> Departamentos { get; set; }
		public DbSet<Ponto> Pontos { get; set; }
		public DbSet<Funcionario> Funcionarios { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity("Teletime.Models.Cargo", b =>
			{
				b.Property<int>("IdCargo")
					.ValueGeneratedOnAdd();

				b.Property<string>("NomeCargo")
                 .HasColumnType("varchar(50)");

				b.HasKey("IdCargo");

				b.ToTable("Cargo");
			});

			modelBuilder.Entity("Teletime.Models.Departamento", b =>
			{
				b.Property<int>("IdDepartamento")
					.ValueGeneratedOnAdd();

                b.Property<string>("NomeDepartamento")
                 .HasColumnType("varchar(50)");

				b.HasKey("IdDepartamento");

				b.ToTable("Departamento");
			});

			modelBuilder.Entity("Teletime.Models.Funcionario", b =>
			{
				b.Property<long>("CPF")
                 .ValueGeneratedNever();

				b.Property<long?>("CPFResponsavel");

				b.Property<DateTime>("DataAdmissao");

				b.Property<DateTime?>("DataDemissao");

				b.Property<int>("IdCargo");

				b.Property<int>("IdDepartamento");

                b.Property<string>("Nome")
                 .HasColumnType("varchar(200)");

				b.HasKey("CPF");

				b.HasIndex("IdCargo");

				b.HasIndex("IdDepartamento");

				b.HasIndex("CPFResponsavel");

				b.ToTable("Funcionario");
			});

			modelBuilder.Entity("Teletime.Models.Ponto", b =>
			{
				b.Property<int>("IdPonto")
					.ValueGeneratedOnAdd();

				b.Property<long>("CPF");

				b.Property<DateTime>("DataHora");

				b.Property<string>("EntradaSaida")
                 .HasColumnType("char(1)");

				b.HasKey("IdPonto");

				b.HasIndex("CPF");

				b.ToTable("Ponto");
			});

			modelBuilder.Entity("Teletime.Models.Funcionario", b =>
			{
				b.HasOne("Teletime.Models.Cargo", "Cargo")
					.WithMany("Funcionarios")
					.HasForeignKey("IdCargo")
                 .OnDelete(DeleteBehavior.Restrict);

				b.HasOne("Teletime.Models.Departamento", "Departamento")
					.WithMany("Funcionarios")
					.HasForeignKey("IdDepartamento")
					.OnDelete(DeleteBehavior.Restrict);

				b.HasOne("Teletime.Models.Funcionario", "Responsavel")
					.WithMany("Subordinados")
					.HasForeignKey("CPFResponsavel");
			});

			modelBuilder.Entity("Teletime.Models.Ponto", b =>
			{
				b.HasOne("Teletime.Models.Funcionario", "Funcionario")
					.WithMany("Pontos")
					.HasForeignKey("CPF")
					.OnDelete(DeleteBehavior.Restrict);
			});


		}

	}
}
