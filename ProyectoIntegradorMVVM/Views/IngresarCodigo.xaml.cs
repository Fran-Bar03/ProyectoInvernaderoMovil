namespace ProyectoIntegradorMVVM.Views;

public partial class IngresarCodigo : ContentPage
{
    public IngresarCodigo()
    {
        InitializeComponent();
        AsignarEventos();
    }

    private void AsignarEventos()
    {
        Code1.TextChanged += (s, e) => { ErrorLabel.IsVisible = false; MoverFoco(Code1, Code2); };
        Code2.TextChanged += (s, e) => { ErrorLabel.IsVisible = false; MoverFoco(Code2, Code3); };
        Code3.TextChanged += (s, e) => { ErrorLabel.IsVisible = false; MoverFoco(Code3, Code4); };
        Code4.TextChanged += (s, e) => { ErrorLabel.IsVisible = false; MoverFoco(Code4, Code5); };
        Code5.TextChanged += (s, e) => { ErrorLabel.IsVisible = false; MoverFoco(Code5, Code6); };
        Code6.TextChanged += (s, e) => { ErrorLabel.IsVisible = false; };
    }

    private void MoverFoco(Entry actual, Entry siguiente)
    {
        if (!string.IsNullOrEmpty(actual.Text))
        {
            siguiente.Focus();
        }
    }

    private void ValidarNumero(object sender, TextChangedEventArgs e)
    {
        Entry entry = sender as Entry;
        if (!string.IsNullOrEmpty(entry.Text) && !char.IsDigit(entry.Text.Last()))
        {
            entry.Text = "";
        }
    }

    private async void Ir_Login(object sender, TappedEventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private async void ConfirmarCodigo_Clicked(object sender, EventArgs e)
    {
        string codigoIngresado = (Code1.Text ?? "") + (Code2.Text ?? "") + (Code3.Text ?? "") +
                                 (Code4.Text ?? "") + (Code5.Text ?? "") + (Code6.Text ?? "");

        if (codigoIngresado.Length < 6)
        {
            ErrorLabel.Text = "Por favor, ingresa los 6 dígitos del código.";
            ErrorLabel.IsVisible = true;
            return;
        }

        if (codigoIngresado == "123456") // Reemplaza con tu validación real
        {
            ErrorLabel.IsVisible = false;
            await Navigation.PushAsync(new NuevaContrasena());
        }
        else
        {
            ErrorLabel.Text = "El código ingresado es incorrecto.";
            ErrorLabel.IsVisible = true;
        }
    }

    private void ReenviarCodigo_Clicked(object sender, TappedEventArgs e)
    {
        DisplayAlert("Código reenviado", "Se ha enviado un nuevo código a tu correo.", "OK");
    }
}
