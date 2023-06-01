using System;
using Ex04.Menus.Inertfaces;

namespace Ex04.Menus.Test
{
	public class ShowDateListener: IMenuListener
	{
        public void Invoke()
        {
            InterfacesMenuTester.ShowDate();
        }
    }
}

