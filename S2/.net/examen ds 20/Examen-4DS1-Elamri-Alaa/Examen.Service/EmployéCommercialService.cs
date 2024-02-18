using Examen.Data.Infrastructures;
using Examen.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Examen.Service
{
    public class EmployéCommercialService :IEmployéCommercialService
    {
        public List<EmployéCommercial> myEmployes = new List<EmployéCommercial>();
        public EmployéCommercialService(List<EmployéCommercial> employés)
        {
            myEmployes = employés;
        }

        public float CalculSalaire(EmployéCommercial emp)
        {
            float Salaire = 0f;
            float SGrade = 0f;
            float SMission = 0f;
            float SEchlon = 0f;
            Salaire = emp.SalaireDeBase;
            if(emp.Grade == Grade.Stagiaire)
            {
                SGrade = 50;
            }else if(emp.Grade == Grade.Jenior)
            {
                SGrade = 100;
            }
            else if (emp.Grade == Grade.Senior)
            {
                SGrade = 150;
            }
            else if (emp.Grade == Grade.Expert)
            {
                SGrade = 200;
            }

            if (emp.Mission == Mission.LibreService)
            {
                SMission = 100;
            }
            else if (emp.Mission == Mission.Spécialiste)
            {
                SMission = 70;
            }
            
            if(emp.Echelon == Echelon.A)
            {
                SEchlon = 12;
            }
            else if (emp.Echelon == Echelon.B)
            {
                SEchlon = 24;
            }
            else if (emp.Echelon == Echelon.C)
            {
                SGrade = 36;
            }
            else if (emp.Echelon == Echelon.D)
            {
                SGrade = 48;
            }
            Salaire = SGrade + SMission + SEchlon;

            if(emp.Age > 50)
            {
                Salaire += (float)0.1 * Salaire;
            }
            return Salaire;

        }

        public int NombreEmployes(Mission m)
        {
            return myEmployes.Where(p => p.Mission == m).Count();
        }

        IGrouping<string, IEnumerable<EmployéCommercial>> IEmployéCommercialService.ListEmploye()
        {
            return (IGrouping<string, IEnumerable<EmployéCommercial>>)
               myEmployes.OrderBy(p => CalculSalaire(p)).GroupBy(p => p.Mission).AsEnumerable();
        }
    }
}
