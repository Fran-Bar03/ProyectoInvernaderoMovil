using ProyectoIntegradorMVVM.ViewModels;

namespace ProyectoIntegradorMVVM.Views;

public partial class AgregarInvernadero : ContentPage
{
	public AgregarInvernadero()
	{
		InitializeComponent();
		AgregarInvernaderoViewModel viewModel = new AgregarInvernaderoViewModel();
		BindingContext = viewModel;
	}
}