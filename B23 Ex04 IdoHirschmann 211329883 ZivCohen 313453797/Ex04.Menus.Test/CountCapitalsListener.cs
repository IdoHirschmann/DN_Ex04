using System;
using Ex04.Menus.Inertfaces;

namespace Ex04.Menus.Test
{
	public class CountCapitalsListener: IMenuListener
	{
        public void Invoke()
        {
            InterfacesMenuTester.CountCapitals();
        }
    }
}

