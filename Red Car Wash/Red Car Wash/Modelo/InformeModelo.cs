using System;
using System.Collections.Generic;
using System.Text;

namespace Red_Car_Wash.Modelo
{
    public class InformeModelo
    {
        public long id_inf { get; set; }
        public DateTimeOffset fecha_inf { get; set; }
        public string actividad_inf { get; set; }
        public string tipo_inf { get; set; }
        public string usuario_inf { get; set; }
        public float total_inf { get; set; }
        public long id_uc_inf { get; set; }
    }
}
