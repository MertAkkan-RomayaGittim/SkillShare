namespace SkillSharingAppMobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}

	private void AppShell_OnAppearing(object sender, EventArgs e)
	{
		Navigation.PushAsync(new MainPage());
	}
    private async void LogoutImageButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());

    }

    

}
