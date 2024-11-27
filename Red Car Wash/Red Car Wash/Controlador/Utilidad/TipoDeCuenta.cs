using MarcTron.Plugin;
using Red_Car_Wash.Modelo;
using System;

namespace Red_Car_Wash.Controlador
{
    public static class TipoDeCuenta
    {
        public static void MostrarAnuncios(long tipoCuenta_uc) 
        {
            if (tipoCuenta_uc == 1)
            {
                CrossMTAdmob.Current.LoadInterstitial("ca-app-pub-6065188311356970/3810681135");
                CrossMTAdmob.Current.ShowInterstitial();
            }
        }

        public static string ValidarSuscripcion(UsuarioModelo usuario)
        {
            string mensaje = "-1";
            if (usuario.fechaCaducidad_uc.Date != DateTimeOffset.Parse("2021-01-01"))
            {
                if ((DateTimeOffset.Now.Date.Year == usuario.fechaCaducidad_uc.Date.Year) &
                    (DateTimeOffset.Now.Date.Month == usuario.fechaCaducidad_uc.Date.Month) &
                    (DateTimeOffset.Now.Date.Day > usuario.fechaCaducidad_uc.Date.Day))
                {
                    CuentaGratis(usuario);
                    mensaje = "Su suscripción ha caducado";
                }
                if ((DateTimeOffset.Now.Date.Year == usuario.fechaCaducidad_uc.Date.Year) &
                    (DateTimeOffset.Now.Date.Month == usuario.fechaCaducidad_uc.Date.Month) &
                    (DateTimeOffset.Now.Date.Day < usuario.fechaCaducidad_uc.Date.Day))
                {
                    var dias = usuario.fechaCaducidad_uc.Date.Day - DateTimeOffset.Now.Date.Day;
                    if (dias <= 5) 
                    {
                        mensaje = $"Su suscripción caducará en {dias} días";
                    }
                }
                if ((DateTimeOffset.Now.Date.Year == usuario.fechaCaducidad_uc.Date.Year) &
                    (DateTimeOffset.Now.Date.Month == usuario.fechaCaducidad_uc.Date.Month) &
                    (DateTimeOffset.Now.Date.Day == usuario.fechaCaducidad_uc.Date.Day)) 
                {
                    mensaje = "Su suscripción caduca hoy";
                }
            }
            return mensaje;
        }

        public static async void CuentaGratis(UsuarioModelo usuario) 
        {
            UsuarioControlador ob = new UsuarioControlador();
            _ = await ob.MetodoActualizarUsuario(usuario.id_uc, usuario.usuario_uc, usuario.correo_uc, usuario.clave_uc, 1, DateTimeOffset.Parse("2021-01-01"), usuario.idEmpleado_uc);
        } 
    }
}
