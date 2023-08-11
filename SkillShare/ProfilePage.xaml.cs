using Microsoft.Extensions.Logging;

namespace SkillSharingAppMobile;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
       

        InitializeComponent();
    }


    public ProfilePage(Participant p)
	{
        BindingContext = p;

       InitializeComponent();
	}

    private void SkillsButton_Clicked(object sender, EventArgs e)
    {
        skillsStackLayout.IsVisible = !skillsStackLayout.IsVisible;

    }

    private void CoursesButton_Clicked(object sender, EventArgs e)
    {
       
    }

    private void WorkshopsButton_Clicked(object sender, EventArgs e)
    {
        
    }
    private void EditButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditProfile());
    }
    private void DetailsButton_Clicked(object sender, EventArgs e)
    {

    }
    
}