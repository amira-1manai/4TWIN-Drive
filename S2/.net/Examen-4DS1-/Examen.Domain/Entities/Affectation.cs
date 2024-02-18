using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Examen.Domain.Entities
{
    public class Affectation
    {
        public DateTime DateEnvoi { get; set; }
        public Etat Etat { get; set; }
        public string MannequinFK { get; set; }
        public int DefileFK { get; set; }

        [ForeignKey("MannequinFK")]
        public virtual Mannequin Mannequin { get; set; }
        [ForeignKey("DefileFK")]
        public virtual Defile Defile { get; set; }

    }
}
