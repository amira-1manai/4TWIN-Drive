using Examen.Data.Infrastructures;
using Examen.Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Service
{
    public class ExempleService:Service<Mannequin>,IExempleService
    {
        public ExempleService(IUnitOfWork utk):base(utk)
        {

        }
    }
}
