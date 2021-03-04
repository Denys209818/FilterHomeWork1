using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilterHomeWork.Entities
{
    public class EFContext : DbContext
    {
        public DbSet<FilterName> FilterNames { get; set; }
        public DbSet<FilterValue> FilterValues { get; set; }
        public DbSet<FilterNameValue> FilterNameValues { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=91.238.103.51;Port=5743;Database=denysdb;Username=denys;Password=qwerty1*;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilterNameValue>(entityParam => {
                entityParam.HasKey(primaryKeys => new { primaryKeys.FilterNameId, primaryKeys.FilterValueId });

                entityParam.HasOne(virtualElementFromFilterName => virtualElementFromFilterName.FilterName)
                .WithMany(virtualCollectionFromNameValueWithEntityToVirtEl =>
                virtualCollectionFromNameValueWithEntityToVirtEl.NameValues)
                .HasForeignKey(intElementWithForeignKeySettings => intElementWithForeignKeySettings.FilterNameId)
                .IsRequired();

                entityParam.HasOne(virtualElementFromFilterValue => virtualElementFromFilterValue.FilterValue)
                .WithMany(virtualCollectionWithEntityToFilterValEl => virtualCollectionWithEntityToFilterValEl.NameValues)
                .HasForeignKey(intElementWithForeignKeySettings => intElementWithForeignKeySettings.FilterValueId)
                .IsRequired();
            });
        }
    }
}
