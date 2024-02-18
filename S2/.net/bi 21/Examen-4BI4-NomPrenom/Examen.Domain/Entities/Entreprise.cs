using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Domain.Entities
{
    public class Entreprise
    {
        public String AdresseEntreprise { get; set; }
        public int EntrepriseId { get; set; }
        public String MailEntreprise { get; set; }
        public String NomEntreprise { get; set; }
        public virtual IList<Cagnotte> Cagnottes { get; set; }
    }
}
