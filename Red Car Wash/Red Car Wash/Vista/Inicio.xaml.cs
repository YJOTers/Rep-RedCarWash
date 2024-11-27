using Red_Car_Wash.Controlador;
using Red_Car_Wash.Modelo;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Red_Car_Wash.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : FlyoutPage
    {
        UsuarioModelo obUsuario = null;

        public Inicio(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            Usuario.Text = this.obUsuario.usuario_uc;
            Correo.Text = this.obUsuario.correo_uc;
        }

        private void BtnNegocio(object sender, EventArgs e)
        {
            Detalle(1);
        }

        private void BtnUsuario(object sender, EventArgs e)
        {
            Detalle(2);
        }

        private void BtnCerrarSesion(object sender, EventArgs e)
        {
            DatosPersistentes.EliminarDatos();
            _ = Navigation.PushAsync(new IniciarSesion());
            Navigation.RemovePage(this);
        }

        public void Detalle(int indice)
        {
            switch (indice)
            {
                case 1:
                    Detail = new NavigationPage(new Negocio(obUsuario));
                    break;
                case 2:
                    if (obUsuario.idEmpleado_uc == 0)
                    {
                        Detail = new NavigationPage(new UsuarioCliente(obUsuario)); //Es cliente
                    }
                    else
                    {
                        Detail = new NavigationPage(new UsuarioEmpleado(obUsuario)); //Es empleado
                    }
                    break;
            }
        }
    }
}