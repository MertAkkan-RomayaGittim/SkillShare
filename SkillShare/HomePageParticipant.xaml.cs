using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SkillSharingAppMobile;

public partial class HomePageParticipant : ContentPage
{


    private bool isStarBttnClicked = false;
    public HomePageParticipant()
	{
		InitializeComponent();
	}
    private void StarButtonParticipant_Clicked(object sender, EventArgs e)
    {
        if (isStarBttnClicked)
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


    private void ImageButtonParticipant_Clicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }

    private async void EventDetailParticipantBtnClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new MyAppointmentsPage());
    }


    private void eventRateParticipant_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
    }


    private Frame CreateFrameEvent(string content)
    {
        var frame1 = new Frame
        {

        };




        return frame1;
    }



}