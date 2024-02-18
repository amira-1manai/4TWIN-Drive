using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Examen.Domain.Entities
{
    public enum Type
    {
        CadeauCommun,DépenseaPlusieurs,ProjetSolidaire,Autres
    }
    public class Cagnotte
    {
        public int CagnotteId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateLimite { get; set; }
        [DataType(DataType.MultilineText)]
        public String Description { get; set; }
        public String Photo { get; set; }
        [Range(0, int.MaxValue)]
        public int SommeDemandée { get; set; }
        [Required(ErrorMessage = "Titre Obligatoire")]
        public String Titre { get; set; }
        public Type Type { get; set; }
        public virtual Entreprise Entreprise { get; set; }
        public virtual IList<Participation> Participations { get; set; }

    }
}
