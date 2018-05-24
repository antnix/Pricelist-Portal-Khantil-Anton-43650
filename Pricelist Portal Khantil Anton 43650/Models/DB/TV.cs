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

        [StringLength(60)]
        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Brand name is required")]
        public string Brand { get; set; }

        [StringLength(60)]
        [Display(Name = "Product code")]
        [Required(ErrorMessage = "Product code is required")]
        public string ProductCode { get; set; }

        [Display(Name = "Price")]
        [Required]
        [Range(0, 10000000, ErrorMessage = "Price must be between 0 and 10000000")]
        public decimal Price { get; set; }

        [Display(Name = "Amount")]
        [Required]
        [Range(0, 1000, ErrorMessage = "Amount must be between 0 and 10000000")]
        public int Amount { get; set; }

        [StringLength(50)]
        [Display(Name = "Energy class")]
        public string EnergyClass { get; set; } = "Brak danych";

        [StringLength(50)]
        [Display(Name = "Screen diagonal")]
        public string ScreenDiagonal { get; set; } = "Brak danych";

        [StringLength(50)]
        [Display(Name = "SmartTV")]
        public string SmartTV { get; set; } = "Brak danych";

        [StringLength(50)]
        [Display(Name = "WiFi")]
        public string WiFi { get; set; } = "Brak danych";

        [StringLength(1024)]
        [Display(Name = "Details")]
        public string Details { get; set; } = "Brak danych";

        public TV()
        {
            Brand = null;
            ProductCode = null;
            Price = 0;
            Amount = 0;
            EnergyClass = null;
            ScreenDiagonal = null;
            SmartTV = null;
            WiFi = null;
            Details = null;
        }

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
