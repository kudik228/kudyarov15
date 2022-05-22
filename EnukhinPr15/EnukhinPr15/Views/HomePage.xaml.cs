using EnukhinPr15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EnukhinPr15.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        bool active = false;
        TimeSpan time = new TimeSpan(0, 0, 0);
        public HomePage()
        {
            InitializeComponent();
        }


        bool TimerTick()
        {
            if (active)
            {
                time += TimeSpan.FromSeconds(0.1);
                lableResult.Text = time.ToString(@"hh\:mm\:ss\:ff");
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void ButtonOnOff_Clicked(object sender, EventArgs e)
        {
            active = !active;
            if (active)
            {
                buttonOnOff.Text = "Выключить таймер";
                time = new TimeSpan(0, 0, 0);
                Device.StartTimer(TimeSpan.FromSeconds(0.1), TimerTick);

            }
            else
            {
                buttonOnOff.Text = "Включить таймер";
                lableResult.Text = entryTitle.Text + " / " + DateTime.Now + " / " + lableResult.Text;
                await App.DataBase.SaveTimeAsync(new Time() { Title = entryTitle.Text, Date = DateTime.Now, Interval = time });
            }

        }
    }
}