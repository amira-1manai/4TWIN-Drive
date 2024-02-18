using System;
using System.Collections.Generic;
using System.Text;

namespace Examen.Data.Infrastructures
{
    public class DataBaseFactory:Disposable,IDatabaseFactory
    {
        private ExamContext dataContext;
        public ExamContext DataContext
        {
            get { return dataContext; }
        }
        public DataBaseFactory() { dataContext = new ExamContext(); }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
