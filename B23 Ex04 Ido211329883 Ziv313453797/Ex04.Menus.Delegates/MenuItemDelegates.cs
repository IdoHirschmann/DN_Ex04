using System;
namespace Ex04.Menus.Delegates
{
	public class MenuItemDelegates : MainMenuDelegates
	{
        public event Action? Chosen = null;

        public bool IsLeaf()
        {
            return (Chosen != null);
        }
        internal void OnChosen()
        {
            if(Chosen != null)
            {
                Chosen.Invoke();
            }            
        }
    }
}

