using System;
using System.Collections.Generic;

#nullable disable

namespace OscarAlfaroPruebaTecnica.Models
{
    public partial class Zona
    {
        public Zona()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdZona { get; set; }
        public string DescripcionZona { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
