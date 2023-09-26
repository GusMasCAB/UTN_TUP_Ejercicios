using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaCordobesaApp.Factory
{
    public abstract class AbstractFactoryDao
    {
        public abstract T CrearDao();
    }
}
