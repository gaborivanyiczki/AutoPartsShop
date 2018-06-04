using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPartsStore__License_App_.Dto
{
    public class CarTypeDTO
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int? Image { get; set; }

        public int? parent_ID { get; set; }

        public string Manufact_Year { get; set; }

        public int? KW { get; set; }

        public int? CMC { get; set; }

        public string Motor_Cod { get; set; }

        public int? body_id { get; set; }
        public virtual BodyDTO Body { get; set; }

        public string Slug { get; set; }

        public virtual CarTypeDTO CarType1 { get; set; }

    }
}