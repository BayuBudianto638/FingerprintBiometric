using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace FingerprintBiometric.Views;

public partial class BlankPage : ContentPage
{
    public BlankPage(BlankViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    async void OnButtonClicked(object sender, EventArgs args)
    {
        var isAvailable = await CrossFingerprint.Current.IsAvailableAsync();

        if (isAvailable)
        {
            var request = new AuthenticationRequestConfiguration
            ("Login using biometrics", "Confirm login with your biometrics");

            var result = await CrossFingerprint.Current.AuthenticateAsync(request);

            if (result.Authenticated)
            {
                await DisplayAlert("Authenticated!", "Access granted", "OK");
            }
            else
            {
                await DisplayAlert("Not authenticated!", "Access denied", "OK");
            }
        }
    }
}
