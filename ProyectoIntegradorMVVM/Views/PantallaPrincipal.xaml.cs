namespace ProyectoIntegradorMVVM.Views;

public partial class PantallaPrincipal : ContentPage
{
	public PantallaPrincipal()
	{
		InitializeComponent();
	}


  protected override bool OnBackButtonPressed () {
    // Evita que el botón "atrás" cierre la app o navegue a otra pantalla.
    return true;
  }
  private async void Ir_AgregarInvernadero(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgregarInvernadero());
    }

    private async void Ir_Detalle(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DetalleInvernadero());
    }
}