﻿using System;
using System.Collections.Generic;

namespace Klakier
{
    public partial class CategoryExpense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }
    }
}