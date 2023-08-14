namespace SkillSharingAppMobile;
using System.Data.Sql;
using System.Data.SqlClient;

public partial class MyAppointmentsPage : ContentPage
{

    public MyAppointmentsPage()
    {
        InitializeComponent();
    }

    private async Task DisplayEventDetails(int eventid)
    {
        try
        {
            string connectionString = "Data Source=DESKTOP-3MK273D;Initial Catalog=UserRegister;Integrated Security=True";

            using ( SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT eventname, eventcategory, eventdateandtime FROM events WHERE eventid = {eventid}", connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string eventName = reader["eventname"].ToString();
                    string eventCategory = reader["eventcategory"].ToString();
                    string eventDateAndTime = reader["eventdateandtime"].ToString();

                    EventDetailedOverviewName.Text = eventName;
                    EventDetailedOverviewCategory.Text = eventCategory;

                    // Format the date and time here
                    DateTime parsedDateAndTime = DateTime.Parse(eventDateAndTime);
                    string formattedDateAndTime = parsedDateAndTime.ToString("dd-MM-yyyy HH:mm:ss");

                    EventDetailedOverviewDateAndTime.Text = formattedDateAndTime;
                }

                // Set Entry fields as non-editable
                EventDetailedOverviewName.IsEnabled = false;
                EventDetailedOverviewCategory.IsEnabled = false;
                EventDetailedOverviewDateAndTime.IsEnabled = false;

                reader.Close();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An error occurred while retrieving event details.", "OK");
            // Log or handle the exception as needed
        }
    }

    private async void DisplayEventDetailsButtonClicked(object sender, EventArgs e)
    {
        int eventId = 3; // The event ID you want to retrieve details for
        await DisplayEventDetails(eventId);
    }




    private async void JoinEventBtnConfirm_OnClicked(object sender, EventArgs e)
    {
        // Retrieve the values of the Entry controls using their x:Name attributes
        string cardCvcValue = CardCvc.Text;
        string cardExpirationDateValue = CardExpirationDate.Text;
        string cardNumberValue = CardNumber.Text;

        // Check if the values match the desired values
        if (cardCvcValue == "111" &&
            cardExpirationDateValue == "1/1/1111" &&
            cardNumberValue == "1111111111")
        {
            // Values match, display success message and navigate to HomePage
            await DisplayAlert("You have successfully joined the event", "Redirecting to main page", "OK");
            await Navigation.PushAsync(new HomePage());
        }
        else
        {
            // Values do not match, display an error message
            await DisplayAlert("Error", "Please provide valid card information.", "OK");
        }
    }


    private async void ImageButton_Clicked(object sender, EventArgs e)
    {


        await DisplayAlert("You will be sent to instructor page", "Redirecting to main page", "OK");
        await Navigation.PushAsync(new ProfilePageInstructor());


    }




}