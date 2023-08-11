
namespace SkillSharingAppMobile;

using System.Data.SqlClient;
//using Microsoft.Data.SqlClient;
using System.Data.Sql;
public partial class CreateEventPage : ContentPage
{
    private List<string> existingEventCategories;

    private List<string> FetchEventCategoriesFromDatabase()
    {
        List<string> categories = new List<string>();

        try
        {
            string connectionString = "Data Source=DESKTOP-3MK273D;Initial Catalog=UserRegister;Integrated Security=True";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();

                string fetchCategoriesQuery = "SELECT DISTINCT eventcategory FROM events";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(fetchCategoriesQuery, connection))
                {
                    using (System.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader["eventcategory"].ToString();
                            categories.Add(category);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions if necessary
        }

        return categories;
    }





    public CreateEventPage()
    {
        InitializeComponent();

        existingEventCategories = FetchEventCategoriesFromDatabase();

        foreach (string category in existingEventCategories)
        {
            ExistingEventPicker.Items.Add(category);
        }
    }





    private void ExistingEventPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedCategory = ExistingEventPicker.SelectedItem as string;
        if (!string.IsNullOrEmpty(selectedCategory))
        {
            EventCategoryEntry.Text = selectedCategory;
        }
    }


    private async void CreateEventBtn_OnClicked(object sender, EventArgs e)
    {
        try
        {


            string connectionString = "Data Source=DESKTOP-3MK273D;Initial Catalog=UserRegister;Integrated Security=True";

            using (System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(connectionString))
            {
                connection.Open();

                // Get event information from UI controls
                string eventName = EventNameEntry.Text;
                string eventCategory = string.IsNullOrEmpty(EventCategoryEntry.Text) ? ExistingEventPicker.SelectedItem.ToString() : EventCategoryEntry.Text;
                DateTime eventDateTime = DatePicker.Date + TimePicker.Time;

                // Insert event information into the Events table
                string insertQuery = "INSERT INTO events (eventname, eventcategory, eventdateandtime) " +
                    "VALUES (@eventname, @eventcategory, @eventdateandtime)";

                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@eventname", eventName);
                    cmd.Parameters.AddWithValue("@eventcategory", eventCategory);
                    cmd.Parameters.AddWithValue("@eventdateandtime", eventDateTime);

                    cmd.ExecuteNonQuery();
                }

                await DisplayAlert("Success", "Event created and saved.", "OK");
                await Navigation.PushAsync(new MainPage());

            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
            await Navigation.PushAsync(new CreateEventPage());
        }
    }




}