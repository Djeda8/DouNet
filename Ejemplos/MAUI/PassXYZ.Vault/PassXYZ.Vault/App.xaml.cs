using PassXYZ.Vault.Services;

namespace PassXYZ.Vault
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            return new PxWindow(MainPage);
        }
    }
}

