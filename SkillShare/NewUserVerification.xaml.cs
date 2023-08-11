namespace SkillSharingAppMobile;

public partial class NewUserVerification : ContentPage
{

    private int randomNumber;
    public NewUserVerification()
    {
        InitializeComponent();
        randomNumber = GenerateCode(); // Store the generated number
                                       // Display the generated number on the screen
        Label randomLabel = new Label
        {
            Text = "Generated Number: " + randomNumber,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };


        CodeEntry = new Entry
        {
            Placeholder = "Enter 4-digit code",
            MaxLength = 4,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };

        Button submitButton = new Button
        {
            Text = "Submit",
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand
        };
        submitButton.Clicked += OnSubmitButtonClicked;

        Content = new StackLayout
        {
            Children = { randomLabel, CodeEntry, submitButton }
        };

    }
    private int GenerateCode()
    {
        Random random = new Random();
        int generatedNumber = random.Next(1000, 10000); // Store the generated number



        return generatedNumber;
    }


    private async void OnSubmitButtonClicked(object sender, EventArgs e)
    {
        string enteredCode = CodeEntry.Text;

        if (int.TryParse(enteredCode, out int parsedCode) && parsedCode == randomNumber)
        {

            await DisplayAlert("Correct code", "Registration Successful!", "OK");
            await Navigation.PushAsync(new MainPage());
            // Perform further actions for successful registration
        }
        else
        {
            await DisplayAlert("Error", "Invalid code. Please try again.", "OK");
            CodeEntry.Text = "";
        }




    }
}