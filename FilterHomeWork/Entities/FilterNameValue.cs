using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FilterHomeWork.Entities
{
    [Table("tblFilterNameValuesHW1")]
    public class FilterNameValue
    {
        [Key, Column(Order = 0), ForeignKey("FilterName.Id")]
        public int FilterNameId { get; set; }
        public virtual FilterName FilterName { get; set; }
        [Key, ForeignKey("FilterValue.Id"), Column(Order = 1)]
        public int FilterValueId { get; set; }
        public virtual FilterValue FilterValue { get; set; }
    }
}
