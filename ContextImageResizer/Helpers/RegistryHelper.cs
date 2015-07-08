// -----------------------------------------------------------------------
// <copyright file="RegistryHelper.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace ContextImageResizer.Helpers
{
    using Microsoft.Win32;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class RegistryHelper
    {
        private const string MENU_PATH = @"*\shell\ContextImageResizer";
        private const string MENU_COMMAND = @"*\shell\ContextImageResizer\command";

        public static void AddMenu(string menuCaption, string command)
        {
            using (var regMenu = Registry.ClassesRoot.CreateSubKey(MENU_PATH))
            {
                if (regMenu != null)
                {
                    regMenu.SetValue(string.Empty, menuCaption);
                }

                using (var regCommand = Registry.ClassesRoot.CreateSubKey(MENU_COMMAND))
                {
                    if (regCommand != null)
                    {
                        regCommand.SetValue(string.Empty, command);
                    }
                }
            }
        }
    }
}
