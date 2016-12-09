using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatos.Models;

namespace SuperZapatos.ViewModels
{
    public class ArticleFormViewModel
    {
        public IEnumerable<Store> Stores { get; set; }
        public Article Article { get; set; }
    }
}