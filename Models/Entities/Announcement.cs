using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboAzORM.Enums;
using TurboAzORM.Models.Commons;

namespace TurboAzORM.Models.Entities
{
    public class Announcement :IAuditableEntity
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public int BrandId { get; set; }
        public Categories Category { get; set; }
        public Gear Gear { get; set; }
        public FuelType FuelType { get; set; }
        public Transmissions Transmissions { get; set; }
        public decimal March { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public override string ToString()
        {
            return $"---- Announcement {Id} ----\nBrand: {BrandId}\nModel: {ModelId}\nYear: {Year}\nMarch: {March}\nFuel type: {Enum.GetName(typeof(FuelType), FuelType)}\nGear: {Enum.GetName(typeof(Gear), Gear)}\nCategory: {Enum.GetName(typeof(Categories), Category)}\nTransmission: {Enum.GetName(typeof(Transmissions), Transmissions)}\n----------";
        }
    }
    
}
