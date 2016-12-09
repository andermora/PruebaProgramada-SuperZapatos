using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperZapatos.Models
{
    public class Article
    {
        public int  Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(254)]
        public string Description { get; set; }

        public float Price { get; set; }

        [Display(Name = "Total in shelf")]
        public int TotalInShelf { get; set; }

        [Display(Name = "Total in vault")]
        public int TotalInVault { get; set; }

        public Store Store { get; set; }

        [Required]
        [Display(Name = "Store Name")]
        public int StoreId { get; set; }

    }
}