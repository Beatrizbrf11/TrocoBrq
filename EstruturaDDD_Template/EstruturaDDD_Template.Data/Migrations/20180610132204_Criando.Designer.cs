﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrocoBrq.Data.Context;

namespace TrocoBrq.Data.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20180610132204_Criando")]
    partial class Criando
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrocoBrq.Domain.Entities.Moeda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("CriadoPor");

                    b.Property<DateTime?>("DataCriadao");

                    b.Property<int>("NotasRetornadas");

                    b.Property<int>("Quantidade");

                    b.Property<decimal>("Valor");

                    b.HasKey("Id");

                    b.ToTable("Moeda");
                });
#pragma warning restore 612, 618
        }
    }
}