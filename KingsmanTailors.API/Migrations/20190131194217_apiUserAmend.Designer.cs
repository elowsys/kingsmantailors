﻿// <auto-generated />
using System;
using KingsmanTailors.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KingsmanTailors.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190131194217_apiUserAmend")]
    partial class apiUserAmend
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KingsmanTailors.API.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("appointmentId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnName("appointmentDate");

                    b.Property<string>("CustomerEmail")
                        .HasColumnName("custEmail");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnName("custName");

                    b.Property<string>("CustomerPhone")
                        .HasColumnName("custPhone");

                    b.Property<bool>("IsConfirmed")
                        .HasColumnName("isConfirmed");

                    b.Property<string>("SalesRepId")
                        .HasColumnName("salesRep");

                    b.HasKey("AppointmentId");

                    b.ToTable("datAppointment");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.AppointmentDetail", b =>
                {
                    b.Property<int>("AppointmentDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("appointmentDetailId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppointmentId")
                        .HasColumnName("appointmentId");

                    b.Property<int>("DetailId")
                        .HasColumnName("detailId");

                    b.HasKey("AppointmentDetailId");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("DetailId");

                    b.ToTable("datAppointmentDetail");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.Fabric", b =>
                {
                    b.Property<int>("FabricId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("fabricId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("fabricDesc");

                    b.Property<string>("FabricName")
                        .HasColumnName("fabricName");

                    b.HasKey("FabricId");

                    b.ToTable("infFabric");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.FrontStyle", b =>
                {
                    b.Property<int>("FrontId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("frontId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FrontName")
                        .HasColumnName("frontName");

                    b.HasKey("FrontId");

                    b.ToTable("infFrontStyle");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.LapelStyle", b =>
                {
                    b.Property<int>("LapelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("lapelId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LapelName")
                        .HasColumnName("lapelName");

                    b.HasKey("LapelId");

                    b.ToTable("infLapelStyle");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.OccasionFit", b =>
                {
                    b.Property<int>("FitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("fitId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("fitDesc");

                    b.Property<string>("FitName")
                        .HasColumnName("fitName");

                    b.HasKey("FitId");

                    b.ToTable("infOccasionFit");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.OccasionLabel", b =>
                {
                    b.Property<int>("LabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("labelId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("labelDesc");

                    b.Property<int>("LabelName")
                        .HasColumnName("labelName");

                    b.HasKey("LabelId");

                    b.ToTable("infOccasionLabel");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.OccasionStyle", b =>
                {
                    b.Property<int>("StyleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("styleId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StyleName")
                        .HasColumnName("styleName");

                    b.HasKey("StyleId");

                    b.ToTable("infOccasionStyle");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.OccasionType", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("typeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ColorName")
                        .HasColumnName("colorName");

                    b.Property<string>("ColorValue")
                        .HasColumnName("colorValue");

                    b.Property<int>("LabelId")
                        .HasColumnName("labelId");

                    b.HasKey("TypeId");

                    b.HasIndex("LabelId");

                    b.ToTable("infOccasionType");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleId")
                        .HasColumnName("roleId");

                    b.Property<string>("RoleName")
                        .HasColumnName("roleName");

                    b.HasKey("Id");

                    b.ToTable("datRole");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.SalesTag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("tagId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ApplyPriceAdjust")
                        .HasColumnName("applyAdjust");

                    b.Property<double>("PriceAdjust")
                        .HasColumnName("priceAdjust");

                    b.Property<string>("TagName")
                        .HasColumnName("tagName");

                    b.HasKey("TagId");

                    b.ToTable("infSalesTag");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.Suit", b =>
                {
                    b.Property<int>("SuitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("suitId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("suitDesc");

                    b.Property<int>("FitId")
                        .HasColumnName("fitId");

                    b.Property<int>("FrontId")
                        .HasColumnName("frontId");

                    b.Property<string>("Image")
                        .HasColumnName("suitImg");

                    b.Property<int>("LapelId")
                        .HasColumnName("lapelId");

                    b.Property<int>("StyleId")
                        .HasColumnName("styleId");

                    b.Property<int>("SuitTypeId")
                        .HasColumnName("suitTypeId");

                    b.Property<int>("TypeId")
                        .HasColumnName("typeId");

                    b.Property<int>("VentId")
                        .HasColumnName("ventId");

                    b.HasKey("SuitId");

                    b.HasIndex("FitId");

                    b.HasIndex("FrontId");

                    b.HasIndex("LapelId");

                    b.HasIndex("StyleId");

                    b.HasIndex("SuitTypeId");

                    b.HasIndex("TypeId");

                    b.HasIndex("VentId");

                    b.ToTable("datSuit");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.SuitDetail", b =>
                {
                    b.Property<int>("DetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("detailId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("InStock")
                        .HasColumnName("inStock");

                    b.Property<double>("Price")
                        .HasColumnName("price");

                    b.Property<int>("Qty")
                        .HasColumnName("qty");

                    b.Property<int>("SuitId")
                        .HasColumnName("suitId");

                    b.Property<int>("TagId")
                        .HasColumnName("tagId");

                    b.HasKey("DetailId");

                    b.HasIndex("SuitId");

                    b.ToTable("datSuitDetail");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.SuitSize", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("sizeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("PriceAdjustIndex")
                        .HasColumnName("adjustIndex");

                    b.Property<string>("SizeName")
                        .HasColumnName("sizeName");

                    b.HasKey("SizeId");

                    b.ToTable("infSuitSize");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.SuitType", b =>
                {
                    b.Property<int>("SuitTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("suitTypeId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnName("typeDesc");

                    b.Property<string>("SuitTypeName")
                        .HasColumnName("typeName");

                    b.HasKey("SuitTypeId");

                    b.ToTable("infSuitType");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("accessFailedCount");

                    b.Property<bool>("AccountConfirmed")
                        .HasColumnName("accountConfirmed");

                    b.Property<string>("DisplayName")
                        .HasColumnName("displayName");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<string>("Gender")
                        .HasColumnName("gender");

                    b.Property<bool>("LockedOutEnabled")
                        .HasColumnName("lockoutEnabled");

                    b.Property<DateTime>("LockedOutEnd")
                        .HasColumnName("lockOutEnd");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnName("passwordHash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phoneNumber");

                    b.Property<byte[]>("SecurityStamp")
                        .HasColumnName("securityStamp");

                    b.Property<string>("UserId")
                        .HasColumnName("userId");

                    b.Property<string>("Username")
                        .HasColumnName("userName");

                    b.HasKey("Id");

                    b.ToTable("datUser");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("userRoleId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleId")
                        .HasColumnName("roleId");

                    b.Property<string>("UserId")
                        .HasColumnName("userId");

                    b.HasKey("Id");

                    b.ToTable("datUserRole");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.VentStyle", b =>
                {
                    b.Property<int>("VentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ventId")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("VentName")
                        .HasColumnName("ventName");

                    b.HasKey("VentId");

                    b.ToTable("infVentStyle");
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.AppointmentDetail", b =>
                {
                    b.HasOne("KingsmanTailors.API.Models.Appointment", "Appointment")
                        .WithMany()
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingsmanTailors.API.Models.SuitDetail", "SuitDetail")
                        .WithMany()
                        .HasForeignKey("DetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.OccasionType", b =>
                {
                    b.HasOne("KingsmanTailors.API.Models.OccasionLabel", "OccasionLabel")
                        .WithMany()
                        .HasForeignKey("LabelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.Suit", b =>
                {
                    b.HasOne("KingsmanTailors.API.Models.OccasionFit", "OccasionFit")
                        .WithMany()
                        .HasForeignKey("FitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingsmanTailors.API.Models.FrontStyle", "FrontStyle")
                        .WithMany()
                        .HasForeignKey("FrontId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingsmanTailors.API.Models.LapelStyle", "LapelStyle")
                        .WithMany()
                        .HasForeignKey("LapelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingsmanTailors.API.Models.OccasionStyle", "OccasionStyle")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingsmanTailors.API.Models.SuitType", "SuitType")
                        .WithMany()
                        .HasForeignKey("SuitTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingsmanTailors.API.Models.OccasionType", "OccasionType")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KingsmanTailors.API.Models.VentStyle", "VentStyle")
                        .WithMany()
                        .HasForeignKey("VentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KingsmanTailors.API.Models.SuitDetail", b =>
                {
                    b.HasOne("KingsmanTailors.API.Models.Suit", "Suit")
                        .WithMany()
                        .HasForeignKey("SuitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
