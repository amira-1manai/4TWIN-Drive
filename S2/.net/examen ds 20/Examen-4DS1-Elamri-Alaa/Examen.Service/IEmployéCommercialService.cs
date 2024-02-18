using Examen.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen.Service
{
    public interface IEmployéCommercialService
    {
        public int NombreEmployes(Mission mission);
        public float CalculSalaire(EmployéCommercial emp);
        public IGrouping<string, IEnumerable<EmployéCommercial>> ListEmploye();
    }
}
