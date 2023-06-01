using System;
namespace Ex04.Menus.Inertfaces
{
	public class MenuItemInterface : MainMenuInterface
	{
        private IMenuListener? m_MenuListener = null;

        public IMenuListener? MenuListener
        {
            get
            {
                return m_MenuListener;
            }
            set
            {
                m_MenuListener = value;
            }
        }
        public bool IsLeaf()
        {
            return (m_MenuListener != null);
        }
        internal void NotifyListener()
        {
            if (m_MenuListener != null)
            {
                m_MenuListener.Invoke();
            }
        }
        public void RemoveMenuListener()
        {
            m_MenuListener = null;
        }
    }
}

