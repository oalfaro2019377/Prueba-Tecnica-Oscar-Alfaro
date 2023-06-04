using System;
using System.Collections.Generic;

#nullable disable

namespace OscarAlfaroPruebaTecnica.Models
{
    public partial class Marca
    {
        public Marca()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdMarca { get; set; }
        public string DescripcionMarca { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
