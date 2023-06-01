using System;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
	public static class DelegatesMenuTester
	{
        public static MainMenuDelegates CreateDelegetsMenu()
        {
            MainMenuDelegates v_MainMenu = new MainMenuDelegates();
            MenuItemDelegates v_ShowDateAndTime = new MenuItemDelegates();
            MenuItemDelegates v_VersionAndCapitals = new MenuItemDelegates();
            MenuItemDelegates v_ShowTime = new MenuItemDelegates();
            MenuItemDelegates v_ShowDate = new MenuItemDelegates();
            MenuItemDelegates v_ShowVersion = new MenuItemDelegates();
            MenuItemDelegates v_CountCapitals = new MenuItemDelegates();

            v_MainMenu.Title = "Delegates Main Menu";
            v_ShowDateAndTime.Title = "Show Date/Time";
            v_VersionAndCapitals.Title = "Version and Capitals";
            v_ShowDate.Title = "Show Date";
            v_ShowTime.Title = "Show Time";
            v_ShowVersion.Title = "Show Version";
            v_CountCapitals.Title = "Count Captials";

            v_MainMenu.AddSubMenu(v_ShowDateAndTime);
            v_MainMenu.AddSubMenu(v_VersionAndCapitals);

            v_ShowDateAndTime.AddSubMenu(v_ShowDate);
            v_ShowDateAndTime.AddSubMenu(v_ShowTime);
            v_VersionAndCapitals.AddSubMenu(v_ShowVersion);
            v_VersionAndCapitals.AddSubMenu(v_CountCapitals);

            v_ShowDate.Chosen += show_Date;
            v_ShowTime.Chosen += show_Time;
            v_ShowVersion.Chosen += show_Version;
            v_CountCapitals.Chosen += count_Capitals;

            return v_MainMenu;
        }
        private static void show_Date()
        {
            DateTime currentDate = DateTime.Now;
            string v_FormattedDate = currentDate.ToString("dd-MM-yyyy");
            Console.WriteLine(string.Format("The date is: {0}", v_FormattedDate));
        }
        private static void show_Time()
        {
            DateTime currentTime = DateTime.Now;
            string v_FormattedTime = currentTime.ToString("HH:mm:ss");
            Console.WriteLine(string.Format("The time is: {0}", v_FormattedTime));
        }
        private static void show_Version()
        {
            Console.WriteLine("Version: 23.2.4.9805");
        }
        private static void count_Capitals()
        {
            Console.WriteLine("Please enter your sentence:");

            string v_UserSentence = Console.ReadLine();
            int v_CapitalCount = 0;

            foreach (char c in v_UserSentence)
            {
                if (char.IsUpper(c))
                {
                    v_CapitalCount++;
                }
            }

            Console.WriteLine(string.Format("There are {0} capitals in your sentence.", v_CapitalCount));
        }
    }
}

