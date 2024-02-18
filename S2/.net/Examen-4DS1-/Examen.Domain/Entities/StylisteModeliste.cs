using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examen.Domain.Entities
{
    public class StylisteModeliste
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [Key]
        public int StylistCode { get; set; }
        public int Telephone { get; set; }
        public virtual IList<Defile> Defiles { get; set; }

    }
}
