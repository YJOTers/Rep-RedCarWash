using System;

namespace Red_Car_Wash.Modelo
{
    public class RegEmpleadoModelo
    {
        public long id_re { get; set; }
        public DateTimeOffset fecha_re { get; set; }
        public string cedula_re { get; set; }
        public string nombres_re { get; set; }
        public string apellidos_re { get; set; }
        public float sueldoAcordado_re { get; set; }
        public long id_uc_re { get; set; }
    }
}
