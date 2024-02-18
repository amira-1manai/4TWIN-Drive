using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Examen.Domain.Entities
{
    public class Defile
    {
        public DateTime DateEvennement { get; set; }
        [Key]
        public int DefileCode { get; set; }
        public int Duree { get; set; }
        public string Lieu { get; set; }
        
        public int StylistFk { get; set; }
        [ForeignKey("StylistFk")]
        public virtual StylisteModeliste StylisteModeliste { get; set; }
    }
}
