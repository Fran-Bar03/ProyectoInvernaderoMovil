﻿using ProyectoIntegradorMVVM.Views;

namespace ProyectoIntegradorMVVM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InicioSesion());
        }
    }
}
