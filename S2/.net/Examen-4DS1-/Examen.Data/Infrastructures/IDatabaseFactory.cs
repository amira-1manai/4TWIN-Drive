using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Infrastructures
{
    public interface IDatabaseFactory:IDisposable
    {
        ExamContext DataContext { get; }
    }
}
