using System;
using Ex04.Menus.Inertfaces;
using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
	public static class InterfacesMenuTester
	{
		public static MainMenuInterface CreateInterfaceMenu()
		{
            MainMenuInterface v_MainMenu = new MainMenuInterface();
            MenuItemInterface v_ShowDateAndTime = new MenuItemInterface();
            MenuItemInterface v_VersionAndCapitals = new MenuItemInterface();
            MenuItemInterface v_ShowTime = new MenuItemInterface();
            MenuItemInterface v_ShowDate = new MenuItemInterface();
            MenuItemInterface v_ShowVersion = new MenuItemInterface();
            MenuItemInterface v_CountCapitals = new MenuItemInterface();

			v_MainMenu.Title = "Interfaces Main Menu";
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

			ShowTimeListener v_ShowTimeListener = new ShowTimeListener();
			ShowDateListener v_ShowDateListener = new ShowDateListener();
			ShowVersionListener v_ShowVersionListener = new ShowVersionListener();
			CountCapitalsListener v_CountCapitalsListener = new CountCapitalsListener();

			v_ShowDate.MenuListener = v_ShowDateListener;
			v_ShowTime.MenuListener = v_ShowTimeListener;
			v_ShowVersion.MenuListener = v_ShowVersionListener;
			v_CountCapitals.MenuListener = v_CountCapitalsListener;

			return v_MainMenu;
        }
		
		public static void ShowDate()
		{
            DateTime currentDate = DateTime.Now;
            string v_FormattedDate = currentDate.ToString("dd-MM-yyyy");
            Console.WriteLine(string.Format("The date is: {0}", v_FormattedDate));
        }
		public static void ShowTime()
		{
            DateTime currentTime = DateTime.Now;
            string v_FormattedTime = currentTime.ToString("HH:mm:ss");
            Console.WriteLine(string.Format("The time is: {0}",v_FormattedTime));
        }
		public static void ShowVersion()
		{
			Console.WriteLine("Version: 23.2.4.9805");
		}
		public static void CountCapitals()
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

