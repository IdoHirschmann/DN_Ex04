using Ex04.Menus.Inertfaces;
using Ex04.Menus.Delegates;
using Ex04.Menus.Test;

public class Program        
{
    public static void Main()
    {
        MainMenuInterface m_InterfaceMenu = InterfacesMenuTester.CreateInterfaceMenu();
        MainMenuDelegates m_DelegatesMenu = DelegatesMenuTester.CreateDelegetsMenu();
        
        m_InterfaceMenu.Show();
        m_DelegatesMenu.Show();
    }
}


