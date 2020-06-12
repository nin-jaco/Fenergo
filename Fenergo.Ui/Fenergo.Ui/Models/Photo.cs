using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fenergo.Ui.Models
{
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public Int64 FileSize { get; set; }
    }
}