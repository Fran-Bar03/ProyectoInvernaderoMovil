using System.Text.RegularExpressions;
using Microsoft.Maui.Controls;
using ProyectoIntegradorMVVM.ViewModels;

namespace ProyectoIntegradorMVVM.Views;

public partial class CrearCuenta : ContentPage
{
    private bool isPasswordVisible = false;

    public CrearCuenta()
    {
        InitializeComponent();
        CrearCuentaViewModel viewModel = new CrearCuentaViewModel(Navigation);
        BindingContext = viewModel;
    }

    
}
