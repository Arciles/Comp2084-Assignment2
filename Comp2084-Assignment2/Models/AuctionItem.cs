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
        public String user_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Item Title")]
        public String title { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description")]
        public String description { get; set; }

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? time_created { get; set; }

        [Display(Name = "Sold At")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime? time_sold { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Picture")]
        public String pic { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
