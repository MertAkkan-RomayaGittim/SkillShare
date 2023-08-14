using System.Data.SqlClient;
namespace SkillSharingAppMobile;
using System.Data.Sql;



public partial class MyAppointmentsOnlyDetails : ContentPage
{
	public MyAppointmentsOnlyDetails()
	{
		InitializeComponent();
	}


    private async Task OnlyDisplayEventDetails(int eventid)
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-3MK273D;Initial Catalog=UserRegister;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT eventname, eventcategory, eventdateandtime FROM events WHERE eventid = {eventid}", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string eventName = reader["eventname"].ToString();
                    string eventCategory = reader["eventcategory"].ToString();
                    string eventDateAndTime = reader["eventdateandtime"].ToString();

                    EventOnlyDetailedOverviewName.Text = eventName;
                    EventOnlyDetailedOverviewCategory.Text = eventCategory;

                    // Format the date and time here
                    DateTime parsedDateAndTime = DateTime.Parse(eventDateAndTime);
                    string formattedDateAndTime = parsedDateAndTime.ToString("dd-MM-yyyy HH:mm:ss");

                    EventOnlyDetailedOverviewDateAndTime.Text = formattedDateAndTime;
                }

                // Set Entry fields as non-editable
                EventOnlyDetailedOverviewName.IsEnabled = false;
                EventOnlyDetailedOverviewCategory.IsEnabled = false;
                EventOnlyDetailedOverviewDateAndTime.IsEnabled = false;

                reader.Close();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An error occurred while retrieving event details.", "OK");
            // Log or handle the exception as needed
        }
    }



    private async void DisplayOnlyEventDetailsButtonClicked(object sender, EventArgs e)
    {
        int eventId = 3; // The event ID you want to retrieve details for
        await OnlyDisplayEventDetails(eventId);
    }


    private async void ImageButtonOnlyEvent_Clicked(object sender, EventArgs e)
    {


        await DisplayAlert("You will be sent to instructor page", "Redirecting to main page", "OK");
        await Navigation.PushAsync(new ProfilePageInstructor());


    }

}