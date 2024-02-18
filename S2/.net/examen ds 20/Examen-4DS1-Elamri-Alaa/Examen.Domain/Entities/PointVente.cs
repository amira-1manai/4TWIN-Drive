using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace Examen.Domain.Entities
{
    public class PointVente
    {
        public string Libelle { get; set; }
        public int NombrePieces { get; set; }
        public int PointVenteId { get; set; }
        [StringLength(8)]
        public int Telephone { get; set; }
        public virtual IList<EmployéCommercial> EmployéCommercials { get; set; }
    }
}
