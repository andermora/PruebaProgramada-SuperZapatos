using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperZapatos.Models;

namespace SuperZapatos.ViewModels
{
    public class StoreFormViewModel
    {
        public Store Store { get; set; }
        public List<Article> Articles { get; set; }
    }
}