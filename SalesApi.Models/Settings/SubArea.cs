﻿using Infrastructure.Features.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SalesApi.Models.Settings
{
    public class SubArea : EntityBase
    {
        public int DeliveryVehicleId { get; set; }
        public string LegacySubAreaId { get; set; }
        public string Name { get; set; }

        public DeliveryVehicle DeliveryVehicle { get; set; }
    }

    public class SubAreaConfiguration : EntityBaseConfiguration<SubArea>
    {
        public override void ConfigureDerived(EntityTypeBuilder<SubArea> b)
        {
            b.Property(x => x.LegacySubAreaId).HasMaxLength(10);
            b.Property(x => x.Name).IsRequired().HasMaxLength(20);
            b.HasOne(x => x.DeliveryVehicle).WithMany(x => x.SubAreas).HasForeignKey(x => x.DeliveryVehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
