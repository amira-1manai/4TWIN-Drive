using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examen.Domain.Entities
{
    public class Mannequin
    {
        
        public int Age { get; set; }
        [Key]
        public string CIN { get; set; }
        public int NumContact { get; set; }
        public float Poid { get; set; }

        [DataType(DataType.Currency)]
        public float PrixParHeure { get; set; }
        public float Taille { get; set; }
    }
}
