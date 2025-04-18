﻿namespace FitnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            var goalManager = new GoalManager();
            var settingsManager = new SettingsManager();

            bool loggedIn = false;

            while (!loggedIn)
            {
                string[] loginOptions = { "Login", "Create New Account" };
                int loginSelection = MenuHelper.DisplayMenu("Welcome to Get Moving! Please select an option:", loginOptions);

                if (loginSelection == 0)
                    loggedIn = userService.Login();
                else
                    userService.CreateAccount();
            }

            bool running = true;

            while (running)
            {
                string[] mainOptions = {
                    "View Current Goals/Challenges",
                    "Input New Goal/Challenge",
                    "Settings",
                    "Exit"
                };

                int mainSelection = MenuHelper.DisplayMenu("Welcome to Get Moving!", main

