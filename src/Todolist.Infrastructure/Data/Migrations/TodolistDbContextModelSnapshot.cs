﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todolist.Infrastructure.Data.Context;

#nullable disable

namespace Todolist.Infrastructure.Data.Migrations
{
    [DbContext(typeof(TodolistDbContext))]
    partial class TodolistDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Todolist.Domain.Aggregates.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.ToTable("Projetos", (string)null);
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)");

                    b.Property<int>("PrioridadeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int?>("ResponsavelId")
                        .HasColumnType("int");

                    b.Property<int>("StatusTarefa")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("PrioridadeId");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("ResponsavelId");

                    b.HasIndex("StatusTarefa");

                    b.ToTable("Tarefas", (string)null);
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Usuario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<int?>("FuncaoUsuarioId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("FuncaoUsuarioId");

                    b.ToTable("Usuarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNascimento = new DateTime(1998, 10, 8, 2, 3, 11, 159, DateTimeKind.Local).AddTicks(7017),
                            FuncaoUsuarioId = 1,
                            Nome = "Felipe",
                            Sobrenome = "Souza"
                        },
                        new
                        {
                            Id = 2,
                            DataNascimento = new DateTime(1970, 10, 8, 2, 3, 11, 159, DateTimeKind.Local).AddTicks(7039),
                            FuncaoUsuarioId = 2,
                            Nome = "Linus",
                            Sobrenome = "Towards"
                        });
                });

            modelBuilder.Entity("Todolist.Domain.Entities.Comentario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AutorId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("TarefaId");

                    b.ToTable("Comentarios", (string)null);
                });

            modelBuilder.Entity("Todolist.Domain.Entities.FuncaoUsuario", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FuncaoUsuarios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Colaborador"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Gerente"
                        });
                });

            modelBuilder.Entity("Todolist.Domain.Entities.HistoricoTarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataModificacao")
                        .HasColumnType("datetime");

                    b.Property<string>("Modificacoes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TarefaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("HistoricoTarefas", (string)null);
                });

            modelBuilder.Entity("Todolist.Domain.Entities.StatusTarefa", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("StatusTarefa", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 0,
                            Descricao = "Pendente"
                        },
                        new
                        {
                            Id = 1,
                            Descricao = "Concluida"
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Cancelada"
                        },
                        new
                        {
                            Id = 3,
                            Descricao = "Arquivada"
                        });
                });

            modelBuilder.Entity("Todolist.Domain.Entities.TipoPrioridade", b =>
                {
                    b.Property<int?>("PrioridadeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("PrioridadeId"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("PrioridadeId");

                    b.ToTable("TiposPrioridade", (string)null);

                    b.HasData(
                        new
                        {
                            PrioridadeId = 1,
                            Descricao = "Alta"
                        },
                        new
                        {
                            PrioridadeId = 2,
                            Descricao = "Media"
                        },
                        new
                        {
                            PrioridadeId = 3,
                            Descricao = "Baixa"
                        });
                });

            modelBuilder.Entity("Todolist.Domain.View.RelatorioTarefasConcluidasView", b =>
                {
                    b.Property<int>("MediaDiasConclusao")
                        .HasColumnType("int");

                    b.Property<int>("ResponsavelId")
                        .HasColumnType("int");

                    b.Property<string>("ResponsavelNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalTarefasConcluidas")
                        .HasColumnType("int");

                    b.ToTable((string)null);

                    b.ToView("vwRelatorioDesempenho", (string)null);
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Projeto", b =>
                {
                    b.HasOne("Todolist.Domain.Aggregates.Usuario", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Todolist.Domain.ValueObjects.StatusProjeto", "Status", b1 =>
                        {
                            b1.Property<int>("ProjetoId")
                                .HasColumnType("int");

                            b1.Property<bool>("Ativo")
                                .HasColumnType("bit")
                                .HasColumnName("Ativo");

                            b1.Property<bool>("Favorito")
                                .HasColumnType("bit")
                                .HasColumnName("Favorito");

                            b1.HasKey("ProjetoId");

                            b1.ToTable("Projetos");

                            b1.WithOwner()
                                .HasForeignKey("ProjetoId");
                        });

                    b.Navigation("Autor");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Tarefa", b =>
                {
                    b.HasOne("Todolist.Domain.Aggregates.Usuario", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Todolist.Domain.Entities.TipoPrioridade", "Prioridade")
                        .WithMany()
                        .HasForeignKey("PrioridadeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Todolist.Domain.Aggregates.Projeto", "Projeto")
                        .WithMany("Tarefas")
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Todolist.Domain.Aggregates.Usuario", "Responsavel")
                        .WithMany()
                        .HasForeignKey("ResponsavelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Todolist.Domain.Entities.StatusTarefa", null)
                        .WithMany()
                        .HasForeignKey("StatusTarefa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Todolist.Domain.ValueObjects.TimelineTarefa", "TimelineTarefa", b1 =>
                        {
                            b1.Property<int>("TarefaId")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("DataFinal")
                                .HasColumnType("datetime2")
                                .HasColumnName("DataFinal");

                            b1.Property<DateTime?>("DataInicial")
                                .IsRequired()
                                .HasColumnType("datetime2")
                                .HasColumnName("DataInicial");

                            b1.HasKey("TarefaId");

                            b1.ToTable("Tarefas");

                            b1.WithOwner()
                                .HasForeignKey("TarefaId");
                        });

                    b.Navigation("Autor");

                    b.Navigation("Prioridade");

                    b.Navigation("Projeto");

                    b.Navigation("Responsavel");

                    b.Navigation("TimelineTarefa");
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Usuario", b =>
                {
                    b.HasOne("Todolist.Domain.Entities.FuncaoUsuario", "FuncaoUsuario")
                        .WithMany("Usuarios")
                        .HasForeignKey("FuncaoUsuarioId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FuncaoUsuario");
                });

            modelBuilder.Entity("Todolist.Domain.Entities.Comentario", b =>
                {
                    b.HasOne("Todolist.Domain.Aggregates.Usuario", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Todolist.Domain.Aggregates.Tarefa", "Tarefa")
                        .WithMany("Comentarios")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("Todolist.Domain.Entities.HistoricoTarefa", b =>
                {
                    b.HasOne("Todolist.Domain.Aggregates.Tarefa", "Tarefa")
                        .WithMany()
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Todolist.Domain.Aggregates.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tarefa");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Projeto", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Tarefa", b =>
                {
                    b.Navigation("Comentarios");
                });

            modelBuilder.Entity("Todolist.Domain.Entities.FuncaoUsuario", b =>
                {
                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
