namespace PatientDetails.Patients_Data
{
    public class Arrow
    {
        public int HandleArrowKey(ConsoleKey key, string[] menuItems, int currentIndex)
        {
            int selectedIndex = currentIndex;

            if (key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
            }
            
                return selectedIndex;
        }
    }
}