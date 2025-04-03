namespace ProyectoIntegradorMVVM.Views;

public partial class NuevaContrasena : ContentPage
{
    private bool esVisibleNuevaClave = false;
    private bool esVisibleConfirmarClave = false;

    public NuevaContrasena()
    {
        InitializeComponent();
    }

    private async void GuardarContrasena_Clicked(object sender, EventArgs e)
    {
        string nuevaClave = NuevaClave.Text?.Trim();
        string confirmarClave = ConfirmarClave.Text?.Trim();

        if (string.IsNullOrEmpty(nuevaClave) || string.IsNullOrEmpty(confirmarClave))
        {
            ErrorLabel.Text = "Por favor, completa ambos campos.";
            return;
        }

        if (nuevaClave != confirmarClave)
        {
            ErrorLabel.Text = "Las contrase�as no coinciden.";
            return;
        }

        string claveCifrada = ConvertirSHA256(nuevaClave);

        // Mostrar mensaje de �xito
        await DisplayAlert("�xito", "Tu contrase�a ha sido actualizada correctamente.", "OK");

        // Navegar a la pantalla de InicioSesion despu�s de hacer clic en "OK"
        await Navigation.PushAsync(new InicioSesion());
    }

    private async void Ir_Login(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InicioSesion());
    }

    private string ConvertirSHA256(string texto)
    {
        using (var sha256 = System.Security.Cryptography.SHA256.Create())
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha256.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }

    // Funci�n para alternar visibilidad de la nueva contrase�a
    private void ToggleNuevaClaveVisibility(object sender, EventArgs e)
    {
        esVisibleNuevaClave = !esVisibleNuevaClave;
        NuevaClave.IsPassword = !esVisibleNuevaClave;
        BtnVerClave.Source = esVisibleNuevaClave ? "eye_off_icon.png" : "eye_icon.png";
    }

    // Funci�n para alternar visibilidad de la confirmaci�n de contrase�a
    private void ToggleConfirmarClaveVisibility(object sender, EventArgs e)
    {
        esVisibleConfirmarClave = !esVisibleConfirmarClave;
        ConfirmarClave.IsPassword = !esVisibleConfirmarClave;
        BtnVerConfirmarClave.Source = esVisibleConfirmarClave ? "eye_off_icon.png" : "eye_icon.png";
    }
}
