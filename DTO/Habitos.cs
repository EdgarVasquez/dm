
using System;

namespace prueba.DTO
{
    public class Habitos
    {
                 public int Id { get; set; }
        public bool Estatus { get; set; }
        public int Id_Usuario_crea { get; set; }
        public DateTime Fecha_Crea { get; set; }
        public DateTime Fecha_Modifica { get; set; }
        public int Id_Usuario_Modifica { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
    }
}