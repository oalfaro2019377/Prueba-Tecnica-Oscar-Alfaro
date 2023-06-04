using System;
using System.Collections.Generic;

#nullable disable

namespace OscarAlfaroPruebaTecnica.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string DescripcionProveedor { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
