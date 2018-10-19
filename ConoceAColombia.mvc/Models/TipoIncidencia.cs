using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConoceAColombia.mvc.Models
{
    public class TipoIncidencia
    {
        public int inId { set; get; }

        [Required]
        [DisplayName("Descripción")]
        public string stDescripcion { set; get; }
    }
}