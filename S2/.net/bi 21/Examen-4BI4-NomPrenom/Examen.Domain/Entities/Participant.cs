using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Domain.Entities
{
    public class Participant
    {
        public String MailParticipant { get; set; }
        public string Nom { get; set; }
        public int ParticipantId { get; set; }
        public String Prenom { get; set; }
        
        public  virtual IList<Participation> Participations { get; set; }

    }
    
}
