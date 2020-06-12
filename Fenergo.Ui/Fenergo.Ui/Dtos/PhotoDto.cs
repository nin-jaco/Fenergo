using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fenergo.Ui.Dtos
{
    public class PhotoDto
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        [Required]
        [Display(Name = "File Size")]
        public Int64 FileSize { get; set; }
    }
}