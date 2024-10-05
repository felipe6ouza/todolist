﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Todolist.Infrastructure.Context;

#nullable disable

namespace Todolist.Infrastructure.Migrations
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

                    b.Property<int>("AutorId")
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

                    b.HasKey("Id");

                    b.HasIndex("AutorId");

                    b.HasIndex("PrioridadeId");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("ResponsavelId");

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

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
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
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Projeto", b =>
                {
                    b.HasOne("Todolist.Domain.Aggregates.Usuario", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("Todolist.Domain.ValueObjects.CorHexadecimal", "Cor", b1 =>
                        {
                            b1.Property<int>("ProjetoId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasMaxLength(7)
                                .HasColumnType("nvarchar(7)")
                                .HasColumnName("CorHexadecimal");

                            b1.HasKey("ProjetoId");

                            b1.ToTable("Projetos");

                            b1.WithOwner()
                                .HasForeignKey("ProjetoId");
                        });

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

                    b.Navigation("Cor");

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

                    b.OwnsOne("Todolist.Domain.ValueObjects.TemposDaTarefa", "TemposdaTarefa", b1 =>
                        {
                            b1.Property<int>("TarefaId")
                                .HasColumnType("int");

                            b1.Property<DateTime?>("DataInicial")
                                .IsRequired()
                                .HasColumnType("datetime2")
                                .HasColumnName("DataInicial");

                            b1.Property<DateTime?>("Prazo")
                                .HasColumnType("datetime2")
                                .HasColumnName("Prazo");

                            b1.HasKey("TarefaId");

                            b1.ToTable("Tarefas");

                            b1.WithOwner()
                                .HasForeignKey("TarefaId");
                        });

                    b.Navigation("Autor");

                    b.Navigation("Prioridade");

                    b.Navigation("Projeto");

                    b.Navigation("Responsavel");

                    b.Navigation("TemposdaTarefa");
                });

            modelBuilder.Entity("Todolist.Domain.Entities.Comentario", b =>
                {
                    b.HasOne("Todolist.Domain.Aggregates.Usuario", "Autor")
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Todolist.Domain.Aggregates.Tarefa", "Tarefa")
                        .WithMany("Comentarios")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Tarefa");
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Projeto", b =>
                {
                    b.Navigation("Tarefas");
                });

            modelBuilder.Entity("Todolist.Domain.Aggregates.Tarefa", b =>
                {
                    b.Navigation("Comentarios");
                });
#pragma warning restore 612, 618
        }
    }
}
