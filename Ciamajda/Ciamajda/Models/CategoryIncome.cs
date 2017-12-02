using System;
using System.Collections.Generic;

namespace Ciamajda
{
    public partial class CategoryIncome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Microsoft.AspNetCore.Mvc.HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
    }
}
