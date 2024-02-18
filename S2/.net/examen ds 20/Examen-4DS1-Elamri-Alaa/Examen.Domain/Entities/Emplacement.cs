using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Examen.Domain.Entities
{
    [Owned]
    [ComplexType]
    public class Emplacement
    {
        public string Langitude { get; set; }
        public string Lattitude { get; set; }
    }
}
