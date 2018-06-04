using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarPartsStore__License_App_.Dto
{
    public class AttributeValueDTO
    {
        public int ID { get; set; }

        public int Attribute_ID { get; set; }
        public virtual AttributeDTO Attribute { get; set; }

        public string AttributeValueName { get; set; }
        public string AttributeValueDesc { get; set; }

    }
}