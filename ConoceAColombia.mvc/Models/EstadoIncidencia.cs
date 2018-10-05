using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConoceAColombia.mvc.Models
{
    public class EstadoIncidencia
    {
        public int inId { set; get; }

        [Required]
        [DisplayName("Descripción")]
        public string stDescripcion { set; get; }
    }
}