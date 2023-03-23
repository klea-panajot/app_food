namespace login.signup;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new RegisterPage();
	}
}
