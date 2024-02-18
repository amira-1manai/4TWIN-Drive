using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Domain.Entities
{
    public class PointMobile : PointVente
    {
        public string CIN_Chauffeur { get; set; }
        public virtual Emplacement Emplacement { get; set; }
    }
}
