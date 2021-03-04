using System;
using System.Collections.Generic;
using System.Text;

namespace FilterHomeWork.Models
{
    public class FilterNameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<FilterValueModel> Children { get; set; }
        public bool IsCollapsed { get; set; } = true;
    }
}
