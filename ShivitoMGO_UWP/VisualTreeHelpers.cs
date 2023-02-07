using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace ShivitoMGO_UWP
{
    public static class VisualTreeHelpers
    {
        public static T FindDescendant<T>(DependencyObject parent) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                {
                    return typedChild;
                }

                var result = FindDescendant<T>(child);
                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
