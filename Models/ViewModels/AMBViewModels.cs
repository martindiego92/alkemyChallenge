using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Prueba2.Models.ViewModels
{
    public class AMBViewModels
    {
        [Required]
        [Display(Name = "Amount")]
        public float amount { get; set; }
       [Required]
       [Display(Name ="Date")]
        public DateTime date { get; set; }
        [Required]
        [Display(Name ="Type")]
        public string type { get; set; }


    }

    public class EditAMBViewModels
    {
        public int concept { get; set; }
        [Required]
        [Display(Name = "Amount")]
        public float amount { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime date { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string type { get; set; }


    }
}