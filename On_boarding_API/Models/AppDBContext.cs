using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_boarding_API.Models
{
    public class AppDBContext :DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<AccountInfo> AccountInfo { get; set; }
        public DbSet<BillingAddress> BillingAddress { get; set; }
        public DbSet<ShippingAddress> ShippingAddress { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Account info
            modelBuilder.Entity<AccountInfo>(entity =>
            {
                entity.HasKey(e => e.CustRegistrationId);

                entity.ToTable("Account_Info");

                entity.Property(e => e.CustRegistrationId)
                .HasColumnName("custRegistrationId");
                //.ValueGeneratedOnAdd();

                //.UseSqlServerIdentityColumn();
                // .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
                //.ValueGeneratedOnAdd();

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("contactPerson")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessName)
                    .HasColumnName("businessName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .HasColumnName("contactNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress1)
                    .HasColumnName("streetAddress1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress2)
                    .HasColumnName("streetAddress2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.District)
                    .HasColumnName("district")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.Property(e => e.StratDate)
                //    .HasColumnName("startDate")
                //    .HasMaxLength(20)
                //    .IsUnicode(false);

                entity.Property(e => e.StratDate).HasColumnName("startDate").HasMaxLength(20).IsUnicode(false);

            });
            
            //Billing Address
            modelBuilder.Entity<BillingAddress>(entity =>
            {
                entity.HasKey(e => e.BillingID);

                entity.ToTable("Billing_Address");

                entity.Property(e => e.BillingID)
                    .HasColumnName("billingID");
                    

                entity.Property(e => e.CustRegistrationId)
                    .HasColumnName("custRegistrationId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress1)
                   .HasColumnName("streetAddress1")
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.StreetAddress2)
                   .HasColumnName("streetAddress2")
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.City)
                   .HasColumnName("city")
                   .HasMaxLength(20)
                   .IsUnicode(false);

                entity.Property(e => e.District)
                   .HasColumnName("district")
                   .HasMaxLength(20)
                   .IsUnicode(false);

            });

            //Shipping Address
            modelBuilder.Entity<ShippingAddress>(entity =>
            {
                entity.HasKey(e => e.ShippingId);

                entity.ToTable("Shipping_Address");

                entity.Property(e => e.ShippingId)
                    .HasColumnName("shippingId");
                   

                entity.Property(e => e.CustRegistrationId)
                    .HasColumnName("custRegistrationId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress1)
                   .HasColumnName("streetAddress1")
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.StreetAddress2)
                   .HasColumnName("streetAddress2")
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.City)
                   .HasColumnName("city")
                   .HasMaxLength(20)
                   .IsUnicode(false);

                entity.Property(e => e.District)
                   .HasColumnName("district")
                   .HasMaxLength(20)
                   .IsUnicode(false);

                entity.Property(e => e.SpecificRegistrationRequest)
                   .HasColumnName("specificRegistrationRequest")
                   .HasMaxLength(20)
                   .IsUnicode(false);

                entity.Property(e => e.Email)
                   .HasColumnName("email")
                   .HasMaxLength(20)
                   .IsUnicode(false);

            });

        }
    }
}
