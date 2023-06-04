using System;
using System.Collections.Generic;

#nullable disable

namespace OscarAlfaroPruebaTecnica.Models
{
    public partial class Presentacion
    {
        public Presentacion()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdPresentacion { get; set; }
        public string DescripcionPresentacion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
