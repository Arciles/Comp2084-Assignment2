namespace Comp2084_Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AuctionItem
    {
        [Key]
        public int item_id { get; set; }

        [StringLength(128)]
        public string user_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Item Title")]
        public string title { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Expected Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? price_expected { get; set; }

        [Display(Name = "Final Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? price_sold { get; set; }

        [Display(Name = "Profit")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? profit { get; set; }

        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime? time_created { get; set; }

        [Display(Name = "Sold At")]
        [DisplayFormat(DataFormatString = "{0:f}")]
        public DateTime? time_sold { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Picture")]
        public string pic { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
