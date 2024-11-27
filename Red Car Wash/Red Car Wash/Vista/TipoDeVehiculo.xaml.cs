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
    public partial class TipoDeVehiculo : ContentPage
    {
        TipoDeVehiculoControlador ob = new TipoDeVehiculoControlador();
        List<TipoDeVehiculoModelo> Lista = null;
        UsuarioModelo obUsuario = null;
        int Posicion;

        public TipoDeVehiculo(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarTipoDeVehiculo(Tipo.Text, VerificarId());
        }

        private void BtnEliminar(object sender, EventArgs e)
        {
            EliminarTipoDeVehiculo();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                Tipo.Text = Lista[Posicion].tipoDeVehiculo_tdv;
            }
        }

        public async void InsertarTipoDeVehiculo(string tipo, long id_uc)
        {
            try 
            {
                if (string.IsNullOrEmpty(tipo))
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    var obUsuario = Lista.Find(x => x.tipoDeVehiculo_tdv == tipo);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarTipoDeVehiculo(tipo, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarTipoDeVehiculo(Lista[Posicion].id_tdv, tipo, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                }
            } catch (Exception) { }
        }

        public async void EliminarTipoDeVehiculo()
        {
            if (Posicion > -1)
            {
                string mensaje = await ob.MetodoEliminarTipoDeVehiculo(Lista[Posicion].id_tdv);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero un tipo de vehiculo", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var TiposDeVehiculos = await ob.MetodoSeleccionarTipoDeVehiculo(VerificarId());
            Lista = TiposDeVehiculos;
            ListaTipoDeVehiculo.ItemsSource = Lista;
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