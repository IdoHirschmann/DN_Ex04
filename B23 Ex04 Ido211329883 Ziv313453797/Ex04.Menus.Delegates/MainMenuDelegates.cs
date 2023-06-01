using System;

namespace Ex04.Menus.Delegates
{

    public class MainMenuDelegates
    {
        protected string? m_Title = null;
        protected List<MenuItemDelegates> m_SubMenus = new List<MenuItemDelegates>();

        const int k_ExitOrBack = 0;

        public string? Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        public void Show()
        {
            int? v_UsersChoice = null;

            while (v_UsersChoice != k_ExitOrBack)
            {                
                PrintMenu();
                v_UsersChoice = GetUsersChoice();
                Console.Clear();

                if (v_UsersChoice != k_ExitOrBack)
                {
                    if (m_SubMenus[(int)v_UsersChoice - 1].IsLeaf())
                    {
                        m_SubMenus[(int)v_UsersChoice - 1].OnChosen();
                        Console.WriteLine();
                    }
                    else
                    {
                        m_SubMenus[(int)v_UsersChoice - 1].Show();
                    }
                }
            }
        }
        protected void PrintMenu()
        {
            int v_Index = 1;

            Console.WriteLine(string.Format("**{0}**", m_Title));
            Console.WriteLine("------------------------");

            foreach (MenuItemDelegates menu in m_SubMenus)
            {
                Console.WriteLine(string.Format("{0} -> {1}", v_Index++, menu.m_Title));
            }

            if (this is MenuItemDelegates)
            {
                Console.WriteLine(string.Format("{0} -> Back", k_ExitOrBack));
            }
            else
            {
                Console.WriteLine(string.Format("{0} -> Exit", k_ExitOrBack));
            }
            Console.WriteLine("------------------------");
        }
        protected int GetUsersChoice()
        {
            string v_ChoiceStr;
            int v_ValidChoice;

            if (this is MenuItemDelegates)
            {
                Console.WriteLine(string.Format("Enter your request: (1 to {0} or press '{1}' to Back)", m_SubMenus.Count, k_ExitOrBack));
            }
            else
            {
                Console.WriteLine(string.Format("Enter your request: (1 to {0} or press '{1}' to Exit)", m_SubMenus.Count, k_ExitOrBack));
            }

            v_ChoiceStr = Console.ReadLine();

            while (!IsChoiceValid(v_ChoiceStr, out v_ValidChoice))
            {
                Console.WriteLine("Invalid input, re-enter your request:");
                v_ChoiceStr = Console.ReadLine();
            }

            return v_ValidChoice;
        }
        protected bool IsChoiceValid(string i_ChoiceStr, out int o_ChoiceInt)
        {
            bool v_Res = int.TryParse(i_ChoiceStr, out o_ChoiceInt);

            if (v_Res)
            {
                v_Res = (o_ChoiceInt >= 0 && o_ChoiceInt <= m_SubMenus.Count);
            }

            return v_Res;
        }        
        public void AddSubMenu(MenuItemDelegates i_SubMenu)
        {
            m_SubMenus.Add(i_SubMenu);
        }
        public void RemoveSubMenu(MenuItemDelegates i_Item)
        {
            m_SubMenus.Remove(i_Item);
        }
    }
}

