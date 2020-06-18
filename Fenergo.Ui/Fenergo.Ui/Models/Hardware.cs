using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fenergo.Ui.Models
{
    public class Hardware
    {
        public int Id { get; set; }
        public HardwareType HardwareType { get; set; }
        [Required]
        public byte IdHardwareType { get; set; }
        [Required]
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public Photo Photo { get; set; }
        public int? IdPhoto { get; set; }
        public decimal PurchasePrice { get; set; }
    }
}