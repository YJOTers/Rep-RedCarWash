using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Red_Car_Wash.Modelo;

namespace Red_Car_Wash.Vista
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InformeMes : ContentPage
	{
		public InformeMes(List<InformeModelo> Lista, string titulo)
		{
			InitializeComponent();
			TablaDeInforme.ItemsSource = Lista;
			Title = titulo;
		}
	}
}