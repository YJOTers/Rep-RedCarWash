using System;

namespace Red_Car_Wash.Modelo
{
    public class UsuarioModelo
    {
        public long id_uc { get; set; }

        public string usuario_uc { get; set; }

        public string correo_uc { get; set; }

        public string clave_uc { get; set; }

        public long tipoCuenta_uc { get; set; }

        public DateTimeOffset fechaCaducidad_uc { get; set; }

        public long idEmpleado_uc { get; set; }
    }
}