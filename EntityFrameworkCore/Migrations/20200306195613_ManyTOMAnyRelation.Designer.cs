﻿// <auto-generated />
using System;
using EntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCore.Migrations
{
    [DbContext(typeof(Testcontext))]
    [Migration("20200306195613_ManyTOMAnyRelation")]
    partial class ManyTOMAnyRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkCore.Data.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("HumanId");

                    b.Property<string>("Name");

                    b.HasKey("CarId");

                    b.HasIndex("HumanId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Human", b =>
                {
                    b.Property<int>("HumanId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("HumanId");

                    b.ToTable("Humans");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("students");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.StudentAddress", b =>
                {
                    b.Property<int>("StudentAddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("Address2");

                    b.Property<string>("State");

                    b.Property<int>("StudentIdPK");

                    b.Property<int>("city");

                    b.HasKey("StudentAddressId");

                    b.HasIndex("StudentIdPK")
                        .IsUnique();

                    b.ToTable("StudentAddresses");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.Car", b =>
                {
                    b.HasOne("EntityFrameworkCore.Data.Human", "human")
                        .WithMany("cars")
                        .HasForeignKey("HumanId");
                });

            modelBuilder.Entity("EntityFrameworkCore.Data.StudentAddress", b =>
                {
                    b.HasOne("EntityFrameworkCore.Data.Student", "Student")
                        .WithOne("StudentAddress")
                        .HasForeignKey("EntityFrameworkCore.Data.StudentAddress", "StudentIdPK")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
