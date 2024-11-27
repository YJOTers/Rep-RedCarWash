using Acr.UserDialogs;
using Red_Car_Wash.Controlador;
using Red_Car_Wash.Modelo;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Red_Car_Wash.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorDeVehiculo : ContentPage
    {
        ColorDeVehiculoControlador ob = new ColorDeVehiculoControlador();
        List<ColorDeVehiculoModelo> Lista = null;
        UsuarioModelo obUsuario = null;
        int Posicion;

        public ColorDeVehiculo(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
        }

        public void BtnGuardar(object sender, EventArgs e)
        {
            InsertarColorDeVehiculo(Color.Text, VerificarId());
        }

        public void BtnEliminar(object sender, EventArgs e)
        {
            EliminarColorDeVehiculo();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                Color.Text = Lista[Posicion].nombreColor_color;
            }
        }

        public async void InsertarColorDeVehiculo(string color, long id_uc)
        { 
            try
            {
                if (string.IsNullOrEmpty(color))
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    var obUsuario = Lista.Find(x => x.nombreColor_color == color);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarColorDeVehiculo(color, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarColorDeVehiculo(Lista[Posicion].id_color, color, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                }
            }
            catch(Exception){}
        }

        public async void EliminarColorDeVehiculo()
        {
            if (Posicion > -1)
            {
                string mensaje = await ob.MetodoEliminarColorDeVehiculo(Lista[Posicion].id_color);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero un color de vehiculo", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var ColoresDeVehiculos = await ob.MetodoSeleccionarColorDeVehiculo(VerificarId());
            Lista = ColoresDeVehiculos;
            ListaColorDeVehiculo.ItemsSource = Lista;
        }

        public long VerificarId()
        {
            long ide;
            if (obUsuario.idEmpleado_uc == 0)
            {
                ide = obUsuario.id_uc;
            }
            else
            {
                ide = obUsuario.idEmpleado_uc;
            }
            return ide;
        }
    }
}