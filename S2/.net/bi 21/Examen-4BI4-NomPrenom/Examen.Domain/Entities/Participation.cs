using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Domain.Entities
{
    public class Participation
    {
        public int CagnotteFk { get; set; }
        public int Montant { get; set; }
        public int ParticipantFk { get; set; }
        
        public virtual Cagnotte Cagnotte { get; set; }
        public virtual Participant Participant { get; set; }

    }
}
