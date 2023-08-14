using Microsoft.Maui.ApplicationModel.Communication;

namespace SkillSharingAppMobile;

public partial class ForgotPasswordPage : ContentPage
{
    private string errorMessage;

    public ForgotPasswordPage()
	{
		InitializeComponent();
	}


    private async void OnSubmitButtonForgotClicked(object sender, EventArgs e)
	{
      


        try
        {
            string connectionString = "Data Source=DESKTOP-3MK273D;Initial Catalog=UserRegister;Integrated Security=True";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();

                string instructorCheckSql = "SELECT COUNT(*) FROM instructors WHERE instructoremail = @email;";
                string userCheckSql = "SELECT COUNT(*) FROM usersreg WHERE usersregemail = @email;";

                using (System.Data.SqlClient.SqlCommand instructorCheckCommand = new System.Data.SqlClient.SqlCommand(instructorCheckSql, connection))
                using (System.Data.SqlClient.SqlCommand userCheckCommand = new System.Data.SqlClient.SqlCommand(userCheckSql, connection))
                {
                    instructorCheckCommand.Parameters.AddWithValue("@email", ForgotEmailEntry.Text);
                    userCheckCommand.Parameters.AddWithValue("@email", ForgotEmailEntry.Text);

                    int instructorCount = (int)instructorCheckCommand.ExecuteScalar();
                    int userCount = (int)userCheckCommand.ExecuteScalar();

                    if (instructorCount > 0)
                    {
                        await DisplayAlert("Instructor email found", "Change your password", "OK");
                        await Navigation.PushAsync(new MainPage());

                    }
                    else if (userCount > 0)
                    {
                        await DisplayAlert("Participant email found", "Change your password", "OK");
                        RecaptchaPopup.IsVisible = !RecaptchaPopup.IsVisible;
                        await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Email not found", "The provided email does not exist.", "OK");
                        PasswordChangePopup.IsVisible = !PasswordChangePopup.IsVisible;

                        await Navigation.PushAsync(new MainPage());
                        return;
                    }

                    // Code to display pop-up for changing password and updating the password in the database
                    // ...
                }
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return;
        }
    }

    private async void OnVerifyRecaptchaClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgotPasswordPage());
    }

    private async void OnChangePasswordClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgotPasswordPage());
    }



}

