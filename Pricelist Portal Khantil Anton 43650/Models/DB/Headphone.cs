namespace Pricelist_Portal_Khantil_Anton_43650.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Headphone
    {
        [Key]
        [Display(Name = "Headphone ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(60)]
        [Display(Name = "Brand")]
        public string Brand { get; set; }

        [StringLength(60)]
        [Display(Name = "Product code")]
        public string ProductCode { get; set; }

        [Display(Name = "Price")]
        [Range(0, 10000000, ErrorMessage = "Price must be between 0 and 10000000")]
        public decimal Price { get; set; }

        [Display(Name = "Amount")]
        [Range(0, 1000, ErrorMessage = "Amount must be between 0 and 1000")]
        public int Amount { get; set; }

        [StringLength(50)]
        [Display(Name = "Max working time")]
        public string MaxWorkingTime { get; set; }

        [StringLength(50)]
        [Display(Name = "Transmission type")]
        public string TransmissionType { get; set; }

        [StringLength(50)]
        [Display(Name = "Microphone")]
        public string HaveMicrophone { get; set; }

        [StringLength(50)]
        [Display(Name = "Range")]
        public string Range { get; set; }

        [StringLength(1024)]
        [Display(Name = "Details")]
        public string Details { get; set; }

        public Headphone() { }

        public Headphone(string brand, 
            string productCode, 
            decimal price, 
            int amount, 
            string maxWorkingTime, 
            string transmissionType,
            string haveMicrophone, 
            string range, 
            string details)
        {
            Brand = brand;
            ProductCode = productCode;
            Price = price;
            Amount = amount;
            MaxWorkingTime = maxWorkingTime;
            TransmissionType = transmissionType;
            HaveMicrophone = haveMicrophone;
            Range = range;
            Details = details;
        }
    }
}
