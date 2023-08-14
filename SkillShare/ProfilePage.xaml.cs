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

    private void SkillsButtonParticipant_Clicked(object sender, EventArgs e)
    {
        skillsStackLayout.IsVisible = !skillsStackLayout.IsVisible;

    }

    private void CoursesButtonParticipant_Clicked(object sender, EventArgs e)
    {
       
    }

    private void WorkshopsButtonParticipant_Clicked(object sender, EventArgs e)
    {
        
    }
    private void EditButtonParticipant_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditProfile());
    }
    private void DetailsButtonParticipant_Clicked(object sender, EventArgs e)
    {

    }
    
    private async void EventImageParticipantCliked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyAppointmentsOnlyDetails());
    }


}