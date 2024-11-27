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
    public partial class Personal : ContentPage
    {
        PersonalControlador ob = new PersonalControlador();
        InformeControlador ob2 = new InformeControlador();
        List<PersonalModeloVista> Lista = null;
        List<RegEmpleadoModelo> Lista2 = null;
        List<TipoDePagoModelo> Lista3 = null;
        UsuarioModelo obUsuario = null;
        long id_re, id_tdp;
        int Posicion, Posicion2;
        string usuario = "";

        public Personal(UsuarioModelo obUsuario)
        {
            InitializeComponent();
            TipoDeCuenta.MostrarAnuncios(obUsuario.tipoCuenta_uc);
            this.obUsuario = obUsuario;
            RefrescarLista();
            RefrescarListaEmpleados();
            RefrescarListaTipoDePago();
        }

        private void BtnGuardar(object sender, EventArgs e)
        {
            InsertarPersonal(Cedula.Text, Fecha.Date, id_re, id_tdp, float.Parse(Valor.Text), VerificarId());
        }

        private void BtnEliminar(object sender, EventArgs e)
        {
            EliminarPersonal();
        }

        private void BtnEditar(object sender, SelectedItemChangedEventArgs e)
        {
            Posicion = e.SelectedItemIndex;
            if (Posicion > -1)
            {
                Fecha.Date = Lista[Posicion].fecha_personal.Date;
                ListaEmpleados.SelectedItem = $"{Lista[Posicion].nombres_re} {Lista[Posicion].apellidos_re}";
                Cedula.Text = Lista[Posicion].cedula_re;
                ListaTipoDePago.SelectedItem = Lista[Posicion].tipoDePago_tdp;
                Valor.Text = Lista[Posicion].valor_personal.ToString();
            }
        }

        private void BtnSeleccionarEmpleado(object sender, EventArgs e)
        {
            Posicion2 = ListaEmpleados.SelectedIndex;
            if (Posicion2 > -1)
            {
                id_re = Lista2[Posicion2].id_re;
                Cedula.Text = Lista2[Posicion2].cedula_re;
            }
        }

        private void BtnSeleccionarTipoDePago(object sender, EventArgs e)
        {
            int Pos = ListaTipoDePago.SelectedIndex;
            if (Pos > -1)
            {
                id_tdp = Lista3[Pos].id_tdp;
            }
        }

        private void BtnListaEmpleados(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new RegistroDeEmpleado(obUsuario));
        }

        private void BtnListaTipoDePago(object sender, EventArgs e)
        {
            _ = Navigation.PushAsync(new TipoDePago(obUsuario));
        }

        public async void InsertarPersonal(string cedula, DateTimeOffset fecha, long id_re, long id_tdp, float valor, long id_uc)
        {
            try 
            {
                if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(fecha.ToString()) || string.IsNullOrEmpty(valor.ToString()) ||
                ListaEmpleados.SelectedIndex == -1 || ListaTipoDePago.SelectedIndex == -1)
                {
                    _ = UserDialogs.Instance.Alert("Existen campos vacios o sin elegir", "ADVERTENCIA", "ENTENDIDO");
                }
                else
                {
                    if (valor == Lista2[Posicion2].sueldoAcordado_re)
                    {
                        _ = await ob2.MetodoInsertarInforme(fecha, "Pago de sueldo", "Completo", usuario, valor, id_uc);
                    }
                    else
                    {
                        _ = await ob2.MetodoInsertarInforme(fecha, "Pago de sueldo", "Anticipo", usuario, valor, id_uc);
                    }
                    var obUsuario = Lista.Find(x => x.cedula_re == cedula);
                    if (obUsuario == null)
                    {
                        string mensaje = await ob.MetodoInsertarPersonal(fecha, id_re, id_tdp, valor, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                    else
                    {
                        string mensaje = await ob.MetodoActualizarPersonal(Lista[Posicion].id_personal, fecha, id_re, id_tdp, valor, id_uc);
                        if (mensaje != "-1")
                        {
                            RefrescarLista();
                            _ = UserDialogs.Instance.Toast(mensaje);
                        }
                    }
                }
            } catch (Exception) { }
        }

        public async void EliminarPersonal()
        {
            if (Posicion > -1)
            {
                string mensaje = await ob.MetodoEliminarPersonal(Lista[Posicion].id_personal);
                if (mensaje != "-1")
                {
                    RefrescarLista();
                    _ = UserDialogs.Instance.Toast(mensaje);
                }
            }
            else
            {
                _ = UserDialogs.Instance.Alert("Seleccione primero una persona", "ADVERTENCIA", "ENTENDIDO");
            }
        }

        public async void RefrescarLista()
        {
            Posicion = -1;
            var Lista1Personal = await ob.MetodoSeleccionarPersonal(VerificarId());
            Lista = Lista1Personal;
            ListaPersonal.ItemsSource = Lista;
            Fecha.Date = DateTime.Today.Date;
            Cedula.Text = "";
            Valor.Text = "";
        }

        public async void RefrescarListaEmpleados() 
        {
            RegDeEmpleadoControlador ob = new RegDeEmpleadoControlador();
            var Lista2Empleados = await ob.MetodoSeleccionarRegEmpleado(VerificarId());
            Lista2 = Lista2Empleados;
            List<string> datos = new List<string>();
            foreach (var items in Lista2) 
            {
                datos.Add($"{items.nombres_re} {items.apellidos_re}");
            }
            ListaEmpleados.ItemsSource = datos;
        }

        public async void RefrescarListaTipoDePago()
        {
            TipoDePagoControlador ob = new TipoDePagoControlador();
            var Lista3TipoDePago = await ob.MetodoSeleccionarTipoDePago(VerificarId());
            Lista3 = Lista3TipoDePago;
            List<string> datos = new List<string>();
            foreach (var items in Lista3)
            {
                datos.Add(items.tipoDePago_tdp);
            }
            ListaTipoDePago.ItemsSource = datos;
        }

        public long VerificarId()
        {
            long ide;
            if (obUsuario.idEmpleado_uc == 0)
            {
                usuario = "Cliente";
                ide = obUsuario.id_uc;
            }
            else
            {
                usuario = "Empleado";
                ide = obUsuario.idEmpleado_uc;
            }
            return ide;
        }
    }
}