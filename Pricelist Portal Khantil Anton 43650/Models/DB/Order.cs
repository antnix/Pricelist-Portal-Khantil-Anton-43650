using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pricelist_Portal_Khantil_Anton_43650.Models.DB
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Order entry number")]
        public long EntryNo { get; set; } = 0;

        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Customer Email")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        public string CustomerEmail { get; set; } = "Brak danych";

        [MaxLength(10)]
        [StringLength(10)]
        [Display(Name = "Customer phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^(\+[0-9]{9})$", ErrorMessage = "Please enter correct phone number")]
        public string CustomerPhoneNumber { get; set; } = "Brak danych";

        [MaxLength(100)]
        [StringLength(100)]
        [Display(Name = "Customer name")]
        [Required(ErrorMessage = "Customer name is required")]
        public string CustomerName { get; set; } = "Brak danych";

        [Display(Name = "Customer address")]
        [Required(ErrorMessage = "Customer address is required")]
        public string CustomerAddress { get; set; } = "Brak danych";

        [Display(Name = "Headphone")]
        public long? HeadphoneEntryNo { get; set; } = null;

        [Display(Name = "TV")]
        public long? TVEntryNo { get; set; } = null;
    }
}