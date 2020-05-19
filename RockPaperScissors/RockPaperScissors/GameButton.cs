using System;
using Xamarin.Forms;

namespace RockPaperScissors
{
    class GameButton : Button
    {
        public GameButton()
        {
            TextColor = Color.Black;
            Margin = 5;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            BorderWidth = 1;
            BorderColor = Color.DarkGray;
        }

        // Helper method to change the color of the button to an 'Active' state
        public void MarkActive()
        {
            BackgroundColor = Color.SlateGray;
            TextColor = Color.White;
        }

        // Helper method to change the color of the button to an 'Inactive' state
        public void MarkInactive()
        {
            BorderColor = Color.SlateGray;
            BackgroundColor = Color.White;
            TextColor = Color.DarkBlue;
        }

        public void MarkTie()
        {
            BorderColor = Color.SlateGray;
            BackgroundColor = Color.Wheat;
            TextColor = Color.SaddleBrown;
        }

        public void MarkWon()
        {
            BorderColor = Color.SeaGreen;
            BackgroundColor = Color.SeaGreen;
            TextColor = Color.White;
        }

        public void MarkLost()
        {
            BorderColor = Color.IndianRed;
            BackgroundColor = Color.Red;
            TextColor = Color.White;
        }
    }
}
