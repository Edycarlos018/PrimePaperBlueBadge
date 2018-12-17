﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimePaper.Models
{
  public class CustomerEdit
    {
        [Display(Name = "Customer ID")]
        public int CustomerID { get; set; }
        [Display(Name = "Name of Business")]
        public string BusinessName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        public string CellPhoneNumber { get; set; }
    }
}
