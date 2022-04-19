﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WanderLost.Server.Controllers;

#nullable disable

namespace WanderLost.Server.Migrations
{
    [DbContext(typeof(MerchantsDbContext))]
    [Migration("20220419040343_BanCreationTimestamp")]
    partial class BanCreationTimestamp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WanderLost.Server.Data.Ban", b =>
                {
                    b.Property<string>("ClientId")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTimeOffset>("ExpiresAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("ClientId", "ExpiresAt");

                    b.ToTable("Bans");
                });

            modelBuilder.Entity("WanderLost.Shared.Data.ActiveMerchant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ActiveMerchantGroupId")
                        .HasColumnType("int");

                    b.Property<bool>("Hidden")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("RapportRarity")
                        .HasColumnType("int");

                    b.Property<string>("UploadedBy")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("Votes")
                        .HasColumnType("int");

                    b.Property<string>("Zone")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("ActiveMerchantGroupId");

                    b.ToTable("ActiveMerchants");
                });

            modelBuilder.Entity("WanderLost.Shared.Data.ActiveMerchantGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("AppearanceExpires")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MerchantName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTimeOffset>("NextAppearance")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Server")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Server", "MerchantName", "AppearanceExpires");

                    b.ToTable("MerchantGroups");
                });

            modelBuilder.Entity("WanderLost.Shared.Data.Vote", b =>
                {
                    b.Property<Guid>("ActiveMerchantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClientId")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("VoteType")
                        .HasColumnType("int");

                    b.HasKey("ActiveMerchantId", "ClientId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("WanderLost.Shared.Data.ActiveMerchant", b =>
                {
                    b.HasOne("WanderLost.Shared.Data.ActiveMerchantGroup", null)
                        .WithMany("ActiveMerchants")
                        .HasForeignKey("ActiveMerchantGroupId");

                    b.OwnsOne("WanderLost.Shared.Data.Item", "Card", b1 =>
                        {
                            b1.Property<Guid>("ActiveMerchantId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("nvarchar(40)");

                            b1.Property<int>("Rarity")
                                .HasColumnType("int");

                            b1.HasKey("ActiveMerchantId");

                            b1.ToTable("ActiveMerchants");

                            b1.WithOwner()
                                .HasForeignKey("ActiveMerchantId");
                        });

                    b.Navigation("Card")
                        .IsRequired();
                });

            modelBuilder.Entity("WanderLost.Shared.Data.Vote", b =>
                {
                    b.HasOne("WanderLost.Shared.Data.ActiveMerchant", "ActiveMerchant")
                        .WithMany("ClientVotes")
                        .HasForeignKey("ActiveMerchantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActiveMerchant");
                });

            modelBuilder.Entity("WanderLost.Shared.Data.ActiveMerchant", b =>
                {
                    b.Navigation("ClientVotes");
                });

            modelBuilder.Entity("WanderLost.Shared.Data.ActiveMerchantGroup", b =>
                {
                    b.Navigation("ActiveMerchants");
                });
#pragma warning restore 612, 618
        }
    }
}
