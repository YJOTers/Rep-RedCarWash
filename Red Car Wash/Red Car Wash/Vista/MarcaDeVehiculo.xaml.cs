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
    public partial class MarcaDeVehiculo : ContentPage
    {
        MarcaDeVehiculoControlador ob = new MarcaDeVehiculoControlador();
        List<MarcaDeVehiculoModelo> Lista = null;
        UsuarioModelo obUsuario = null;
        int Posicion;

        public MarcaDeVehiculo(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarMarcaDeVehiculo(Marca.Text, VerificarId());
        }

        private void BtnEliminar(object sender, EventArgs e)
        {
            EliminarMarcaDeVehiculo();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                Marca.Text = Lista[Posicion].nombreMarca_marca;
            }
        }

        public async void InsertarMarcaDeVehiculo(string marca, long id_uc)
        {
            try 
            {
                if (string.IsNullOrEmpty(marca))
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    var obUsuario = Lista.Find(x => x.nombreMarca_marca == marca);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarMarcaDeVehiculo(marca, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarMarcaDeVehiculo(Lista[Posicion].id_marca, marca, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                }
            } catch (Exception) { }
        }

        public async void EliminarMarcaDeVehiculo()
        {
            if (Posicion > -1)
            {
                string mensaje = await ob.MetodoEliminarMarcaDeVehiculo(Lista[Posicion].id_marca);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero una marca de vehiculo", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var MarcasDeVehiculos = await ob.MetodoSeleccionarMarcaDeVehiculo(VerificarId());
            Lista = MarcasDeVehiculos;
            ListaMarcaDeVehiculo.ItemsSource = Lista;
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