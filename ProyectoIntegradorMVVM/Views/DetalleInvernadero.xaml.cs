using ProyectoIntegradorMVVM.ViewModels;

namespace ProyectoIntegradorMVVM.Views
{
    public partial class DetalleInvernadero : ContentPage
    {
        public DetalleInvernadero(string nombreInvernadero)
        {
            InitializeComponent();
            BindingContext = new DetalleInvernaderoViewModel(nombreInvernadero);
        }
    }
}
