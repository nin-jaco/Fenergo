using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.Dtos
{
    public class HardwareDto
    {
        public int Id { get; set; }
        [Required]
        public byte IdHardwareType { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }
        public int IdPhoto { get; set; }
        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }

        public PhotoDto Photo { get; set; }
        public HardwareTypeDto HardwareType { get; set; }
    }
}