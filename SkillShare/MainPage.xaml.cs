namespace SkillSharingAppMobile;
using System.Data.SqlClient;
using System.Data.Sql;
public partial class MainPage : ContentPage
{
    int count = 0;

    public string[] emails = { "a", "user2@example.com", "user3@example.com" };
    public string[] passwords = { "a", "password2", "password3" };
    private string errorMessage;
    public MainPage()
    {
        InitializeComponent();
    }

    private void RegisterBtnClicked(object sender, EventArgs e)
    {

        Navigation.PushAsync(new RegistrationPage());

    }

    private void LabelTapped(object sender, EventArgs e)
    {
        // Navigate to the next page
        Navigation.PushAsync(new RegistrationPage());
    }

    

    private async void LoginBtnClicked(object sender, EventArgs e)
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-3MK273D;Initial Catalog=UserRegister;Integrated Security=True";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();

                string emailToCheck = EmailLoginEntry.Text;
                string passwordToCheck = PasswordLoginEntry.Text;

                string sqlParticipant = "SELECT COUNT(*) FROM usersreg WHERE usersregemail = @useremail AND usersregpassword = @userpassword;";
                string sqlInstructor = "SELECT COUNT(*) FROM instructors WHERE instructoremail = @instructoremail AND instructorpassword = @instructorpassword;";

                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sqlParticipant, connection))
                {
                    command.Parameters.AddWithValue("@useremail", emailToCheck);
                    command.Parameters.AddWithValue("@userpassword", passwordToCheck);

                    int matchingRowsCountParticipant = (int)command.ExecuteScalar();

                    if (matchingRowsCountParticipant > 0)
                    {
                        await DisplayAlert("Login Successful", "Login as Participant is successful.", "OK");
                        // Navigate to the appropriate page after successful login
                        await Navigation.PushAsync(new HomePage());
                    }

                }


                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sqlInstructor, connection))
                {
                    command.Parameters.AddWithValue("@instructoremail", emailToCheck);
                    command.Parameters.AddWithValue("@instructorpassword", passwordToCheck);

                    int matchingRowsCountInstructors = (int)command.ExecuteScalar();

                    if (matchingRowsCountInstructors > 0)
                    {
                        await DisplayAlert("Login Successful", "Login as Instructor is successful.", "OK");
                        // Navigate to the appropriate page after successful login
                        await Navigation.PushAsync(new HomePage());
                    }



                }



            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return;
        }
    }




    /*
	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
	*/
}

