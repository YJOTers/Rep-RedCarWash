using System;

namespace Red_Car_Wash.Modelo
{
    public class PersonalModeloVista
    {
        public long id_personal { get; set; }

        public DateTimeOffset fecha_personal { get; set; }

        public string nombres_re { get; set; }

        public string apellidos_re { get; set; }

        public string cedula_re { get; set; }

        public string tipoDePago_tdp { get; set; }

        public float valor_personal { get; set; }

        public long id_uc_personal { get; set; }
    }

    public class PersonalModelo
    {
        public long id_personal { get; set; }
        public DateTimeOffset fecha_personal { get; set; }
        public long id_re_personal { get; set; }
        public long id_tdp_personal { get; set; }
        public float valor_personal { get; set; }
        public long id_uc_personal { get; set; }
    }
}