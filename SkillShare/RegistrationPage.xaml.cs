namespace SkillSharingAppMobile;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data.Sql;

public partial class RegistrationPage : ContentPage
{

    static bool isInstructorButtonClicked = false;
    static bool isParticipantButtonClicked = false;
    private string errorMessage;
    private string successMessage;
    public RegistrationPage()
    {
        InitializeComponent();
    }

    private async void SubmitBtnClicked(object sender, EventArgs e)
    {
        if (isInstructorButtonClicked)
        {
            await InsertDataIntoInstructorsTable();
        }
        else if (isParticipantButtonClicked)
        {
            await InsertDataIntoUsersRegTable();
        }
        else
        {
            // Handle the case where neither button was clicked before submitting
            // Display an error message or take appropriate action.
        }

        // Clear button clicked flags and entry fields
        isInstructorButtonClicked = false;
        isParticipantButtonClicked = false;
        NameEntry.Text = "";
        SurnameEntry.Text = "";
        EmailEntry.Text = "";
        PasswordEntry.Text = "";
    }

    private async Task InsertDataIntoInstructorsTable()
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-3MK273D;Initial Catalog=UserRegister;Integrated Security=True";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO instructors (instructorname, instructorsurname, instructoremail, instructorpassword) " +
                             "VALUES (@instructorname, @instructorsurname, @instructoremail, @instructorpassword);";

                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@instructorname", NameEntry.Text);
                    command.Parameters.AddWithValue("@instructorsurname", SurnameEntry.Text);
                    command.Parameters.AddWithValue("@instructoremail", EmailEntry.Text);
                    command.Parameters.AddWithValue("@instructorpassword", PasswordEntry.Text);

                    int rowsInserted = command.ExecuteNonQuery();

                    if (rowsInserted >= 0)
                    {
                        await DisplayAlert("Instructor registration processing", "Please enter the 4 digit code to verify you are a human.", "OK");
                        await Navigation.PushAsync(new NewUserVerification());
                        //await DisplayAlert("Instructor Registration Successful", "Your Instructor registration has been successful.", "OK");
                        //await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Registration failed.", "OK");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return;
        }

        successMessage = "New Instructor added";
    }


    private async Task InsertDataIntoUsersRegTable()
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-3MK273D;Initial Catalog=UserRegister;Integrated Security=True";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO usersreg (usersregname, usersregsurname, usersregemail, usersregpassword) " +
                             "VALUES (@usersregname, @usersregsurname, @usersregemail, @usersregpassword);";

                using (System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@usersregname", NameEntry.Text);
                    command.Parameters.AddWithValue("@usersregsurname", SurnameEntry.Text);
                    command.Parameters.AddWithValue("@usersregemail", EmailEntry.Text);
                    command.Parameters.AddWithValue("@usersregpassword", PasswordEntry.Text);

                    int rowsInserted = command.ExecuteNonQuery();

                    if (rowsInserted >= 0)
                    {
                        await DisplayAlert("Participant registration processing", "Please enter the 4 digit code to verify you are a human.", "OK");
                        await Navigation.PushAsync(new NewUserVerification());
                        //await DisplayAlert("Participant Registration Successful", "Your Participant registration has been successful.", "OK");
                        //await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        await DisplayAlert("Error", "Registration failed.", "OK");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
            return;
        }

        successMessage = "New Participant added";
    }



    private void OnInstructorBttnClicked(object sender, EventArgs e)
    {
        instrBttn.BackgroundColor = Color.FromRgb(50, 168, 82);
        partBttn.BackgroundColor = Color.FromRgb(224, 224, 224);
        partBttn.TextColor = Color.FromRgb(79, 79, 79);
        isInstructorButtonClicked = true;


    }

    private void OnParticipantBttnClicked(object sender, EventArgs e)
    {
        partBttn.BackgroundColor = Color.FromRgb(50, 168, 82);
        instrBttn.BackgroundColor = Color.FromRgb(224, 224, 224);
        instrBttn.TextColor = Color.FromRgb(79, 79, 79);
        isParticipantButtonClicked = true;



    }






}















