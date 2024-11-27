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
    public partial class UsuarioListaEmpleados : ContentPage
    {
        UsuarioControlador ob = new UsuarioControlador();
        List<UsuarioModelo> Lista = null;
        UsuarioModelo Cliente = null;
        int Posicion;

        public UsuarioListaEmpleados(UsuarioModelo Cliente)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(Cliente.tipoCuenta_uc);
            this.Cliente = Cliente;
            RefrescarLista();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarEmpleado(Usuario.Text, Correo.Text, Clave.Text);
        }

        private void BtnEliminar(object sender, EventArgs e)
        {
            EliminarEmpleado();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                Usuario.Text = Lista[Posicion].usuario_uc;
                Correo.Text = Lista[Posicion].correo_uc;
                Clave.Text = Lista[Posicion].clave_uc;
            }
        }

        public async void InsertarEmpleado(string usuario, string correo, string clave) 
        {
            try 
            {
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    var obUsuario = Lista.Find(x => x.correo_uc == correo);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarUsuario(usuario, correo, clave, Cliente.tipoCuenta_uc, Cliente.fechaCaducidad_uc, Cliente.id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        _ = UserDialogs.Instance.Alert("El obUsuario ya existe", "ADVERTENCIA", "ENTENDIDO");
                    }
                }
            } catch (Exception) { }
        }

        public async void EliminarEmpleado() 
        {
            if (Posicion > -1) 
            {
                string mensaje = await ob.MetodoEliminarUsuario(Lista[Posicion].id_uc);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero un empleado", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista() 
        {
            Posicion = -1;
            var ListaEmpleado = await ob.MetodoSeleccionarListaUsuarios(Cliente.id_uc);
            Lista = ListaEmpleado;
            ListaEmpleados.ItemsSource = Lista;
        }
    }
}