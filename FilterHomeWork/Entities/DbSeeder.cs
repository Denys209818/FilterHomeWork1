using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilterHomeWork.Entities
{
    public static class DbSeeder
    {
        public static void SeedAll(EFContext context) 
        {
            SeedFilter(context);
        }

        private static void SeedFilter(EFContext context)
        {
            string[] filterNames = { "Програмування", "Дизайн" };

            foreach (var filterName in filterNames) 
            {
                if (context.FilterNames.SingleOrDefault(x => x.Name == filterName) == null) 
                {
                    context.FilterNames.Add(new FilterName { 
                        Name = filterName
                    });

                    context.SaveChanges();
                }
            }

            List<string[]> filterValue = new List<string[]> 
            {
                new string[] { "C#", "Java", "PHP", "JavaScript" },
                new string[] { "Photoshop", "Ilustrator", "Paint3D" }
            };

            foreach (var vymirFilters in filterValue) 
            {
                foreach (var item in vymirFilters) 
                {
                    if (context.FilterValues.SingleOrDefault(x => x.Name == item) == null) 
                    {
                        context.FilterValues.Add(new FilterValue { 
                        Name = item
                        });

                        context.SaveChanges();
                    }
                }
            }

            for (int i = 0; i < filterNames.Count(); i++) 
            {
                var FilterNameId = context.FilterNames.SingleOrDefault(x => x.Name == filterNames[i]).Id;
                foreach (var item in filterValue[i]) 
                {
                    var FilterValueId = context.FilterValues.SingleOrDefault(x => x.Name == item).Id;
                    if (context.FilterNameValues.SingleOrDefault(x => x.FilterNameId == FilterNameId 
                    && x.FilterValueId == FilterValueId) == null) 
                    {
                        context.FilterNameValues.Add(new FilterNameValue { 
                            FilterNameId = FilterNameId,
                            FilterValueId = FilterValueId
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
