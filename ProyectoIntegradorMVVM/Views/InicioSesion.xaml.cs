using ProyectoIntegradorMVVM.ViewModels;
using System.Text.RegularExpressions;

namespace ProyectoIntegradorMVVM.Views;

public partial class InicioSesion : ContentPage {

  public InicioSesion () 
  {
    InitializeComponent ();
    InicioSesionViewModel viewModel = new InicioSesionViewModel (Navigation);
    BindingContext = viewModel;
  }
}
  