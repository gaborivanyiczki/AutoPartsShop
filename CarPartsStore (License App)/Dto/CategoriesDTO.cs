using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPartsStore__License_App_.Dto
{
    public class CategoriesDTO
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public int? parent_ID { get; set; }
        public virtual CategoriesDTO Category1 { get; set; }

    }
}