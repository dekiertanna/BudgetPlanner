using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ciamajda
{
    public partial class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }

        [Microsoft.AspNetCore.Mvc.HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
    }
}
