using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Fenergo.Ui.Dtos;
using Fenergo.Ui.Models;

namespace Fenergo.Ui.ViewModels
{
    public class HardwareFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public byte IdHardwareType { get; set; }
        [Required]
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public Photo Photo { get; set; }
        public int IdPhoto { get; set; }
        public decimal PurchasePrice { get; set; }
        public IEnumerable<HardwareTypeDto> HardwareTypes { get; set; }
    }
}