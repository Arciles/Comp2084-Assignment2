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
        public string title { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public decimal? price_expected { get; set; }

        public decimal? price_sold { get; set; }

        public decimal? profit { get; set; }

        public DateTime? time_created { get; set; }

        public DateTime? time_sold { get; set; }

        [Column(TypeName = "text")]
        public string pic { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
