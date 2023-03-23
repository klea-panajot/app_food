
namespace login.signup.Pages
{
    public partial class LoginPage : ContentPage
    {
        private ICallbackManager callbackManager;

        // Declare FacebookSdk as a new instance of FacebookSdk class
        private FacebookSdk FacebookSdk = new FacebookSdk();

        public LoginPage()
        {
            InitializeComponent();

            // Initialize the Facebook SDK and the callback manager
            FacebookSdk.ApplicationId = "your_app_id"; //put your app id
            FacebookSdk.SdkInitialize(this);
            callbackManager = CallbackManagerFactory.Create();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            // Your email login authentication code here
        }

        private async void BtnFacebookLogin_Clicked(object sender, EventArgs e)
        {
            // Set the permissions to request from the user
            var permissions = new List<string> { "public_profile", "email" };

            // Start the Facebook login process
            LoginResult result = await LoginManager.Instance.LogInWithReadPermissionsAsync(this, permissions);

            // Handle the result of the login process
            if (result?.AccessToken != null)
            {
                // The user is logged in with Facebook
                var fbToken = result.AccessToken.Token;
                // Do something with the access token
            }
            else
            {
                // The user canceled the login or an error occurred
            }
        }

        private void TapJoinNow_Tapped(object sender, EventArgs e)
        {
            // Navigate to the signup page
            Navigation.PushAsync(new RegisterPage());
        }

        private async void BtnRegister_Clicked(System.Object sender, System.EventArgs e)
        {
            var response = await ApiService.RegisterUser(EntFullName.Text, EntEmail.Text, EntPassword.Text, EntPhone.Text);
            if (response)
            {
                await DisplayAlert("", "Your account has been created", "Alright");
                await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("", "Oops something went wrong", "Cancel");
            }
        }

        private async void TapLogin_Tapped(System.Object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}