namespace SkillSharingAppMobile;

public partial class ProfilePageInstructor : ContentPage
{
	public ProfilePageInstructor()
	{
		InitializeComponent();
	}

    private void EditButtonInstructor_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditProfileInstructor());
    }


    private async void EventImageInstructorClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new MyAppointmentsOnlyDetails());

    }

    private void SkillsButtonInstructor_Clicked(object sender, EventArgs e)
    {
        skillsInstructorStackLayout.IsVisible = !skillsInstructorStackLayout.IsVisible;

    }

    private void CoursesInstructorButton_Clicked(object sender, EventArgs e)
    {
        coursesInstructorStackLayout.IsVisible = !coursesInstructorStackLayout.IsVisible;

    }

    private void WorkshopsInstructorButton_Clicked(object sender, EventArgs e)
    {
        workshopsInstructorStackLayout.IsVisible = !workshopsInstructorStackLayout.IsVisible;

    }

    private void DetailsButtonInstructor_Clicked(object sender, EventArgs e)
    {

    }

}