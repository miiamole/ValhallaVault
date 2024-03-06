﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ValhallaVault.Data;

#nullable disable

namespace ValhallaVault.Migrations.ProgramDb
{
    [DbContext(typeof(ProgramDbContext))]
    partial class ProgramDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ValhallaVault.Data.Models.AnswerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionModelId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegmentIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.QuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnswerIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubcategoryModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubcategoryModelId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SegmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryModelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubcategoryIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryModelId");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SubcategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionIds")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SegmentModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SegmentModelId");

                    b.ToTable("Subcategories");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.UserQuestionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("UserQuestions");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.AnswerModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.QuestionModel", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.QuestionModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.SubcategoryModel", "Subcategory")
                        .WithMany("Questions")
                        .HasForeignKey("SubcategoryModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subcategory");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SegmentModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.CategoryModel", "Category")
                        .WithMany("Segments")
                        .HasForeignKey("CategoryModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SubcategoryModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.SegmentModel", "Segment")
                        .WithMany("Subcategories")
                        .HasForeignKey("SegmentModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.UserQuestionModel", b =>
                {
                    b.HasOne("ValhallaVault.Data.Models.QuestionModel", null)
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.CategoryModel", b =>
                {
                    b.Navigation("Segments");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.QuestionModel", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SegmentModel", b =>
                {
                    b.Navigation("Subcategories");
                });

            modelBuilder.Entity("ValhallaVault.Data.Models.SubcategoryModel", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
