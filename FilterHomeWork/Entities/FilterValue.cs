using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FilterHomeWork.Entities
{
    [Table("tblFilterValuesHW1")]
    public class FilterValue
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        public virtual ICollection<FilterNameValue> NameValues { get; set; }

    }
}
