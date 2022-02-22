using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Entidades
{
    public abstract class EntidadeBase
    {
        public string ID { get; set; }

        public EntidadeBase()
        {
            ID = Guid.NewGuid().ToString();
        }
    }
}
