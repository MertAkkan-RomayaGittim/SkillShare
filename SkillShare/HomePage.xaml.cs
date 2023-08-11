using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SkillSharingAppMobile;

public partial class HomePage : ContentPage
{
    private bool isStarBttnClicked = false;
    public HomePage()
    {
        InitializeComponent();
        
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }

    private void StarButton_Clicked(object sender, EventArgs e)
    {
        if(isStarBttnClicked)
        {
            strBttn.Source = "star_icon.png";
            isStarBttnClicked = false;
        }
        else
        {
            strBttn.Source = "star_icon_filled.png";
            isStarBttnClicked = true;
        }
    }

    private async void GoToCreateEvent_OnClicked(Object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CreateEventPage());
    }


    private async void EventDetailBtnClicked(object sender , EventArgs e)
    {

        await Navigation.PushAsync(new MyAppointmentsPage());
    }

    private void eventRate_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
    }

    private Frame CreateFrame(string content)
    {
        var frame1 = new Frame
        {

        };
        



        return frame1;
    }
}
