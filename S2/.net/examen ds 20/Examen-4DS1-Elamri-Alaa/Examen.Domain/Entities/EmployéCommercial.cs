using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Examen.Domain.Entities
{
    public class EmployéCommercial
    {
        [Required,Range(18, 60)]
        public int Age { get; set; }
        public Echelon Echelon { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int EmployéCommercialId { get; set; }
        public Grade Grade { get; set; }
        public Mission Mission { get; set; }
        public string Nom { get; set; }
        public int NombreAnnéesExpérience { get; set; }
        public int? PointVenteId { get; set; }
        [ForeignKey("PointVenteId")]
        public virtual PointVente PointVente { get; set; }
        public string Prenom { get; set; }
        [Required,Range(250,float.MaxValue)]
        public float SalaireDeBase { get; set; }



    }
}
