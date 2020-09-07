using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba2.Models.TableViewModel
{
    public class expensesAndIncomeViewModel
    {
        public int concept { get; set; }
        public double? amount { get; set; }

        public DateTime? date { get; set; }
    
        public string type { get; set; }
    }
}