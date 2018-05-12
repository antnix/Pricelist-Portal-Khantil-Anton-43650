namespace Pricelist_Portal_Khantil_Anton_43650.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TVs")]
    public partial class TV
    {
        [Key]
        [Display(Name = "TV ID")]
        public int TV_ID { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [StringLength(60)]
        [Display(Name = "Product code")]
        public string ProductCode { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Amount")]
        public int Amount { get; set; }

        [StringLength(50)]
        [Display(Name = "Energy class")]
        public string EnergyClass { get; set; }

        [StringLength(50)]
        [Display(Name = "Screen diagonal")]
        public string ScreenDiagonal { get; set; }

        [StringLength(50)]
        [Display(Name = "SmartTV")]
        public string SmartTV { get; set; }

        [StringLength(50)]
        [Display(Name = "WiFi")]
        public string WiFi { get; set; }

        [StringLength(1024)]
        [Display(Name = "Details")]
        public string Details { get; set; }

        public TV() { }

        public TV(string brand,
            string productCode,
            decimal price,
            int amount,
            string energyClass,
            string screenDiagonal,
            string smartTV,
            string wiFi,
            string details)
        {
            Brand = brand;
            ProductCode = productCode;
            Price = price;
            Amount = amount;
            EnergyClass = energyClass;
            ScreenDiagonal = screenDiagonal;
            SmartTV = smartTV;
            WiFi = wiFi;
            Details = details;
        }
    }
}
