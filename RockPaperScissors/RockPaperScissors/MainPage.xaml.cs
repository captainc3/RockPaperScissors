using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace RockPaperScissors
{
    public partial class MainPage : ContentPage
    {
        const string ROCK_ACTION = "Rock";
        const string PAPER_ACTION = "Paper";
        const string SCISSORS_ACTION = "Scissors";
        const string STARTING_TEXT = "Welcome to Rock, Paper, Scissors! " +
            "\n      Make your choice:";
        const string ACTION_CHOSEN_TEXT = "Ready? \n";
        const string LOSS_TEXT = "You just lost — surely it can't happen again?\n";
        const string WIN_TEXT = "You just won! ...feels good doesn't it?\n";
        const string TIE_TEXT = "You just tied — better try again.\n";
        const string GO_TEXT = "Shoot!";

        GameButton SelectedButton;

        public MainPage()
        {
            InitializeComponent();

            //Sets text
            Title.Text = STARTING_TEXT;
            RockButton.Text = ROCK_ACTION;
            PaperButton.Text = PAPER_ACTION;
            ScissorsButton.Text = SCISSORS_ACTION;
            ShootButton.Text = GO_TEXT;

            // Event handlers
            RockButton.Clicked += OnChoiceClicked;
            PaperButton.Clicked += OnChoiceClicked;
            ScissorsButton.Clicked += OnChoiceClicked;
            ShootButton.Clicked += OnShootClicked;

            //to set the initial colors for buttons
            foreach (GameButton child in ButtonsGrid.Children)
            {
                child.MarkInactive();
            }
        }

        public void OnChoiceClicked(object sender, EventArgs args)
        {
            GameButton clicked = (GameButton)sender;
            
            //deselects a currently selected button
            if (SelectedButton == clicked)
            {
                Title.Text = STARTING_TEXT;
                clicked.MarkInactive();
                SelectedButton = null;
                return;
            }

            //resets children's colors
            foreach (GameButton child in ButtonsGrid.Children)
            {
                child.MarkInactive();
            }

            clicked.MarkActive();
            Title.Text = ACTION_CHOSEN_TEXT;

            //to use in later references
            SelectedButton = clicked;
        }

        public void OnShootClicked(object sender, EventArgs args)
        {
            //doesn't let the button go if nothing is selected
            if (SelectedButton == null) return;

            string compChoice = GetRandCompChoice();

            bool didCompTie = SelectedButton.Text == compChoice;
            bool didCompWin = DidYouLose(SelectedButton.Text, compChoice);

            if (didCompTie)
            {
                Title.Text = TIE_TEXT;
                DisplayAlert("Tie!", $"The computer chose {compChoice} too.", "Play again");
                SelectedButton.MarkTie();
            } 
            else if (didCompWin)
            {
                Title.Text = LOSS_TEXT;
                DisplayAlert("You lost!", $"The computer chose {compChoice}. :'(", "Play again");
                SelectedButton.MarkLost();
            }
            else
            {
                Title.Text = WIN_TEXT;
                DisplayAlert("You won!", $"The computer chose {compChoice}. :D", "Play again");
                SelectedButton.MarkWon();
            }
            SelectedButton = null;
        }

        private string GetRandCompChoice()
        {
            Random random = new Random();
            var choice = random.Next(0, 3);

            if (choice == 0)
            {
                return ROCK_ACTION;
            } else if (choice == 1)
            {
                return PAPER_ACTION;
            } else
            {
                return SCISSORS_ACTION;
            }
        }

        private bool DidYouLose(string playerChoice, string compChoice)
        {
            if (playerChoice == ROCK_ACTION && compChoice == PAPER_ACTION) return true;
            if (playerChoice == PAPER_ACTION && compChoice == SCISSORS_ACTION) return true;
            if (playerChoice == SCISSORS_ACTION && compChoice == ROCK_ACTION) return true;

            //otherwise this happens
            return false;
        }
    }
}
