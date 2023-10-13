﻿// <auto-generated />
using System;
using CashFlow.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CashFlow.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231011124236_OopsTransactionModels")]
    partial class OopsTransactionModels
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CashFlow.Persistence.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserBudgetProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserBudgetProfileId");

                    b.ToTable("Account");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Account");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.AccountTransferTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ScheduledTransactionInterval")
                        .HasColumnType("integer");

                    b.Property<int>("ToAccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("ToAccountId");

                    b.ToTable("AccountTransferTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.DebtTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("AssetAccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int>("DebtAccountId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Fees")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Interest")
                        .HasColumnType("numeric");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Principal")
                        .HasColumnType("numeric");

                    b.Property<int?>("ScheduledTransactionInterval")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AssetAccountId");

                    b.HasIndex("DebtAccountId");

                    b.ToTable("DebtTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.Envelope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ExpenseOrCreditTransactionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserBudgetProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseOrCreditTransactionId");

                    b.HasIndex("UserBudgetProfileId");

                    b.ToTable("Envelope");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Envelope");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.EnvelopeTransferTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FromEnvelopeId")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ScheduledTransactionInterval")
                        .HasColumnType("integer");

                    b.Property<int>("ToEnvelopeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromEnvelopeId");

                    b.HasIndex("ToEnvelopeId");

                    b.ToTable("EnvelopeTransferTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.ExpenseOrCreditTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int?>("AssetAccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreditCardAccountId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("EnvelopeId")
                        .HasColumnType("integer");

                    b.Property<int?>("GoalEnvelopeId")
                        .HasColumnType("integer");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("PrimaryEnvelopeId")
                        .HasColumnType("integer");

                    b.Property<int?>("ScheduledTransactionInterval")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AssetAccountId");

                    b.HasIndex("CreditCardAccountId");

                    b.HasIndex("GoalEnvelopeId");

                    b.HasIndex("PrimaryEnvelopeId");

                    b.ToTable("ExpenseOrCreditTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.IncomeTransaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int?>("AssetAccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("CreditCardAccountId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ScheduledTransactionInterval")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AssetAccountId");

                    b.HasIndex("CreditCardAccountId");

                    b.ToTable("IncomeTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.UserBudgetProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BudgetStartDayOfMonth")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId")
                        .IsUnique();

                    b.ToTable("UserBudgetProfiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.DebtAccount", b =>
                {
                    b.HasBaseType("CashFlow.Persistence.Models.Account");

                    b.Property<int>("DebtEnvelopeId")
                        .HasColumnType("integer");

                    b.Property<int>("DebtPaymentType")
                        .HasColumnType("integer");

                    b.Property<decimal>("InterestRate")
                        .HasColumnType("numeric");

                    b.HasIndex("DebtEnvelopeId")
                        .IsUnique();

                    b.ToTable("Account", t =>
                        {
                            t.Property("DebtPaymentType")
                                .HasColumnName("DebtAccount_DebtPaymentType");
                        });

                    b.HasDiscriminator().HasValue("DebtAccount");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.TransferableAccount", b =>
                {
                    b.HasBaseType("CashFlow.Persistence.Models.Account");

                    b.HasDiscriminator().HasValue("TransferableAccount");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.DebtEnvelope", b =>
                {
                    b.HasBaseType("CashFlow.Persistence.Models.Envelope");

                    b.Property<int?>("DueDayOfMonth")
                        .HasColumnType("integer");

                    b.Property<decimal>("MonthlyPayment")
                        .HasColumnType("numeric");

                    b.HasDiscriminator().HasValue("DebtEnvelope");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.GoalEnvelope", b =>
                {
                    b.HasBaseType("CashFlow.Persistence.Models.Envelope");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Goal")
                        .HasColumnType("numeric");

                    b.Property<int>("GoalEnvelopeInterval")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("GoalEnvelope");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.PrimaryEnvelope", b =>
                {
                    b.HasBaseType("CashFlow.Persistence.Models.Envelope");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<int?>("DueDayOfMonth")
                        .HasColumnType("integer");

                    b.ToTable("Envelope", t =>
                        {
                            t.Property("Balance")
                                .HasColumnName("PrimaryEnvelope_Balance");

                            t.Property("DueDayOfMonth")
                                .HasColumnName("PrimaryEnvelope_DueDayOfMonth");
                        });

                    b.HasDiscriminator().HasValue("PrimaryEnvelope");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.AssetAccount", b =>
                {
                    b.HasBaseType("CashFlow.Persistence.Models.TransferableAccount");

                    b.HasDiscriminator().HasValue("AssetAccount");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.CreditCardAccount", b =>
                {
                    b.HasBaseType("CashFlow.Persistence.Models.TransferableAccount");

                    b.Property<int>("DebtPaymentType")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("CreditCardAccount");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.Account", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.UserBudgetProfile", "UserBudgetProfile")
                        .WithMany("Accounts")
                        .HasForeignKey("UserBudgetProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserBudgetProfile");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.AccountTransferTransaction", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.TransferableAccount", "FromAccount")
                        .WithMany("FromAccountTransferTransactions")
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CashFlow.Persistence.Models.TransferableAccount", "ToAccount")
                        .WithMany("ToAccountTransferTransactions")
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.DebtTransaction", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.AssetAccount", "AssetAccount")
                        .WithMany("DebtTransactions")
                        .HasForeignKey("AssetAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashFlow.Persistence.Models.DebtAccount", "DebtAccount")
                        .WithMany("DebtTransactions")
                        .HasForeignKey("DebtAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssetAccount");

                    b.Navigation("DebtAccount");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.Envelope", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.ExpenseOrCreditTransaction", null)
                        .WithMany("Envelopes")
                        .HasForeignKey("ExpenseOrCreditTransactionId");

                    b.HasOne("CashFlow.Persistence.Models.UserBudgetProfile", "UserBudgetProfile")
                        .WithMany("Envelopes")
                        .HasForeignKey("UserBudgetProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserBudgetProfile");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.EnvelopeTransferTransaction", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.Envelope", "FromEnvelope")
                        .WithMany("FromEnvelopeTransferTransactions")
                        .HasForeignKey("FromEnvelopeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CashFlow.Persistence.Models.Envelope", "ToEnvelope")
                        .WithMany("ToEnvelopeTransferTransactions")
                        .HasForeignKey("ToEnvelopeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromEnvelope");

                    b.Navigation("ToEnvelope");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.ExpenseOrCreditTransaction", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashFlow.Persistence.Models.AssetAccount", null)
                        .WithMany("ExpenseOrCreditTransactions")
                        .HasForeignKey("AssetAccountId");

                    b.HasOne("CashFlow.Persistence.Models.CreditCardAccount", null)
                        .WithMany("ExpenseOrCreditTransactions")
                        .HasForeignKey("CreditCardAccountId");

                    b.HasOne("CashFlow.Persistence.Models.GoalEnvelope", null)
                        .WithMany("ExpenseOrCreditTransactions")
                        .HasForeignKey("GoalEnvelopeId");

                    b.HasOne("CashFlow.Persistence.Models.PrimaryEnvelope", null)
                        .WithMany("ExpenseOrCreditTransactions")
                        .HasForeignKey("PrimaryEnvelopeId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.IncomeTransaction", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashFlow.Persistence.Models.AssetAccount", null)
                        .WithMany("IncomeTransactions")
                        .HasForeignKey("AssetAccountId");

                    b.HasOne("CashFlow.Persistence.Models.CreditCardAccount", null)
                        .WithMany("IncomeTransactions")
                        .HasForeignKey("CreditCardAccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.UserBudgetProfile", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("UserBudgetProfile")
                        .HasForeignKey("CashFlow.Persistence.Models.UserBudgetProfile", "ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CashFlow.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.DebtAccount", b =>
                {
                    b.HasOne("CashFlow.Persistence.Models.DebtEnvelope", "DebtEnvelope")
                        .WithOne("DebtAccount")
                        .HasForeignKey("CashFlow.Persistence.Models.DebtAccount", "DebtEnvelopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DebtEnvelope");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.ApplicationUser", b =>
                {
                    b.Navigation("UserBudgetProfile")
                        .IsRequired();
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.Envelope", b =>
                {
                    b.Navigation("FromEnvelopeTransferTransactions");

                    b.Navigation("ToEnvelopeTransferTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.ExpenseOrCreditTransaction", b =>
                {
                    b.Navigation("Envelopes");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.UserBudgetProfile", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("Envelopes");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.DebtAccount", b =>
                {
                    b.Navigation("DebtTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.TransferableAccount", b =>
                {
                    b.Navigation("FromAccountTransferTransactions");

                    b.Navigation("ToAccountTransferTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.DebtEnvelope", b =>
                {
                    b.Navigation("DebtAccount")
                        .IsRequired();
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.GoalEnvelope", b =>
                {
                    b.Navigation("ExpenseOrCreditTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.PrimaryEnvelope", b =>
                {
                    b.Navigation("ExpenseOrCreditTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.AssetAccount", b =>
                {
                    b.Navigation("DebtTransactions");

                    b.Navigation("ExpenseOrCreditTransactions");

                    b.Navigation("IncomeTransactions");
                });

            modelBuilder.Entity("CashFlow.Persistence.Models.CreditCardAccount", b =>
                {
                    b.Navigation("ExpenseOrCreditTransactions");

                    b.Navigation("IncomeTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}