namespace ProyectoIntegradorMVVM.Views
{
    public partial class DetalleInvernadero : ContentPage
    {
        public DetalleInvernadero()
        {
            InitializeComponent();
        }

        // Método para cambiar el color de fondo de los controles
        private void OnControlToggled(object sender, ToggledEventArgs e)
        {
            var activo = Color.FromRgba(90, 112, 61, 230);  // Verde con 90% opacidad
            var apagado = Color.FromRgba(90, 112, 61, 191); // Verde con 75% opacidad

            // Cambio de color de fondo para Lighting
            if (sender == LightingSwitch)
                WateringSwitch.BackgroundColor = LightingSwitch.IsToggled ? activo : apagado;

            // Cambio de color de fondo para Temperature
            if (sender == TemperatureSwitch)
                WateringSwitch.BackgroundColor = TemperatureSwitch.IsToggled ? activo : apagado;

            // Cambio de color de fondo para Watering
            if (sender == WateringSwitch)
                WateringSwitch.BackgroundColor = WateringSwitch.IsToggled ? activo : apagado;

            // Cambio de color de fondo para Ventilation
            if (sender == VentilationSwitch)
                VentilationSwitch.BackgroundColor = VentilationSwitch.IsToggled ? activo : apagado;
        }

        private void LightingSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void TemperatureSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }

        private void VentilationSwitch_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}
