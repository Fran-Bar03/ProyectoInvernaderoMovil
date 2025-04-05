using ProyectoIntegradorMVVM.ViewModels;

namespace ProyectoIntegradorMVVM.Views;

public partial class AgregarInvernadero : ContentPage
{
	public AgregarInvernadero(PantallaPrincipalViewModel pantallaPrincipalViewModel )
	{
		InitializeComponent();
		AgregarInvernaderoViewModel viewModel = new AgregarInvernaderoViewModel(pantallaPrincipalViewModel);
		BindingContext = viewModel;
	}
}