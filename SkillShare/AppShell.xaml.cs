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
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine("Merhaba");
    }
}
