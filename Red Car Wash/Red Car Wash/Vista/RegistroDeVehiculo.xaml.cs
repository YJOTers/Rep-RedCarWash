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
    public partial class RegistroDeVehiculo : ContentPage
    {
        RegDeVehiculoControlador ob = new RegDeVehiculoControlador();
        List<RegDeVehiculoModeloVista> Lista = null;
        List<TipoDeVehiculoModelo> Lista2 = null;
        List<ColorDeVehiculoModelo> Lista3 = null;
        List<MarcaDeVehiculoModelo> Lista4 = null;
        UsuarioModelo obUsuario = null;
        long id_tdv, id_color, id_marca;
        int Posicion;

        public RegistroDeVehiculo(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
            RefrescarListaColorDeVehiculo();
            RefrescarListaMarcaDeVehiculo();
            RefrescarListaTipoDeVehiculo();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarRegDeVehiculo(Cliente.Text, Placa.Text, id_color, id_marca, id_tdv, VerificarId());
        }

        private void BtnEliminar(object sender, EventArgs e)
        {
            EliminarRegDeVehiculo();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                Placa.Text = Lista[Posicion].placa_rv;
                Cliente.Text = Lista[Posicion].cliente_rv;
                ListaTipoDeVehiculo.SelectedItem = Lista[Posicion].tipoDeVehiculo_tdv;
                ListaColorDeVehiculo.SelectedItem = Lista[Posicion].nombreColor_color;
                ListaMarcaDeVehiculo.SelectedItem = Lista[Posicion].nombreMarca_marca;
            }
        }

        private void BtnSeleccionarTipoDeVehiculo(object sender, EventArgs e)
        {
            int Pos = ListaTipoDeVehiculo.SelectedIndex;
            if (Pos > -1)
            {
                id_tdv = Lista2[Pos].id_tdv;
            }
        }

        private void BtnSeleccionarColorDeVehiculo(object sender, EventArgs e)
        {
            int Pos = ListaColorDeVehiculo.SelectedIndex;
            if (Pos > -1)
            {
                id_color = Lista3[Pos].id_color;
            }
        }

        private void BtnSeleccionarMarcaDeVehiculo(object sender, EventArgs e)
        {
            int Pos = ListaMarcaDeVehiculo.SelectedIndex;
            if (Pos > -1)
            {
                id_marca = Lista4[Pos].id_marca;
            }
        }

        private void BtnListaTipoDeVehiculo(object sender, EventArgs e) 
        {
            _ = Navigation.PushAsync(new TipoDeVehiculo(obUsuario));
        }

        private void BtnListaColorDeVehiculo(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new ColorDeVehiculo(obUsuario));
        }

        private void BtnListaMarcaDeVehiculo(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new MarcaDeVehiculo(obUsuario));
        }

        public async void InsertarRegDeVehiculo(string nombre, string placa, long id_color, long id_marca, long id_tdv, long id_uc)
        {
            try 
            {
                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(placa) || ListaTipoDeVehiculo.SelectedIndex == -1 ||
                ListaColorDeVehiculo.SelectedIndex == -1 || ListaMarcaDeVehiculo.SelectedIndex == -1)
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios o sin elegir", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    var obUsuario = Lista.Find(x => x.cliente_rv == nombre && x.placa_rv == placa);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarRegDeVehiculo(nombre, placa, id_color, id_marca, id_tdv, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarRegDeVehiculo(Lista[Posicion].id_rv, nombre, placa, id_color, id_marca, id_tdv, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                }
            } catch (Exception) { }
        }

        public async void EliminarRegDeVehiculo()
        {
            if (Posicion > -1)
            {
                string mensaje = await ob.MetodoEliminarRegDeVehiculo(Lista[Posicion].id_rv);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero un vehiculo", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var RegDeVehiculos = await ob.MetodoSeleccionarRegDeVehiculo(VerificarId());
            Lista = RegDeVehiculos;
            ListaRegDeVehiculo.ItemsSource = Lista;
            Placa.Text = "";
            Cliente.Text = "";
        }

        public async void RefrescarListaTipoDeVehiculo()
        {
            TipoDeVehiculoControlador ob = new TipoDeVehiculoControlador();
            var Lista2TipoDeVehiculo = await ob.MetodoSeleccionarTipoDeVehiculo(VerificarId());
            Lista2 = Lista2TipoDeVehiculo;
            List<string> datos = new List<string>();
            foreach (var items in Lista2)
            {
                datos.Add(items.tipoDeVehiculo_tdv);
            }
            ListaTipoDeVehiculo.ItemsSource = datos;
        }

        public async void RefrescarListaColorDeVehiculo()
        {
            ColorDeVehiculoControlador ob = new ColorDeVehiculoControlador();
            var Lista3ColorDeVehiculo = await ob.MetodoSeleccionarColorDeVehiculo(VerificarId());
            Lista3 = Lista3ColorDeVehiculo;
            List<string> datos = new List<string>();
            foreach (var items in Lista3)
            {
                datos.Add(items.nombreColor_color);
            }
            ListaColorDeVehiculo.ItemsSource = datos;
        }

        public async void RefrescarListaMarcaDeVehiculo()
        {
            MarcaDeVehiculoControlador ob = new MarcaDeVehiculoControlador();
            var Lista4MarcaDeVehiculo = await ob.MetodoSeleccionarMarcaDeVehiculo(VerificarId());
            Lista4 = Lista4MarcaDeVehiculo;
            List<string> datos = new List<string>();
            foreach (var items in Lista4)
            {
                datos.Add(items.nombreMarca_marca);
            }
            ListaMarcaDeVehiculo.ItemsSource = datos;
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