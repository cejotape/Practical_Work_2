namespace MAUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Pages that are part of the app shell
		Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
		Routing.RegisterRoute(nameof(ConversorPage), typeof(ConversorPage));
		Routing.RegisterRoute(nameof(OperationsPage), typeof(OperationsPage));
		Routing.RegisterRoute(nameof(ForgotPasswordPage), typeof(ForgotPasswordPage));
	}
}
