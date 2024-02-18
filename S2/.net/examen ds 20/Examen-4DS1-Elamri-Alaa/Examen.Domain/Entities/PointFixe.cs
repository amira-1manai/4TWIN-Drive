using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Examen.Domain.Entities
{
    public class PointFixe : PointVente
    {
        public DateTime DateMiseEnPlace { get; set; }
        [Required, Range(17, 21)]
        public float HeureFermeture { get; set; }
        [Required, Range(7, 9)]
        public float HeureOuverture { get; set; }
        public string Rue { get; set; }
        public string Ville { get; set; }
    }
}
