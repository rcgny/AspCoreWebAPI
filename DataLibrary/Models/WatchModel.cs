using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLibrary.Models
{  // Normally this is a DTO model, and should not be decorated. The decoration is normally done in the front-end code. Done here for
   // simplicity.
    public class WatchModel
    {
        public int Id { get; set; }

       
        [MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters")]
        [MinLength(3, ErrorMessage = "You need to enter at least 3 characters for an order name")]
        [DisplayName("Name of Bird")]
        public string Category { get; set; }

        [Required]
        [DisplayName("Bird")]
        [Range(1, int.MaxValue, ErrorMessage = "You need to select a bird from the list")]
        public int BirdId { get; set; }

        public string Location { get; set; }

        public string Map { get; set; }
    }
}
