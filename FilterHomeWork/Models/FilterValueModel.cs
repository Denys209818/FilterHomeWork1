using System;
using System.Collections.Generic;
using System.Text;

namespace FilterHomeWork.Models
{
    public class FilterValueModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; } = false;

        public override string ToString()
        {
            return this.Name;
        }
    }
}
