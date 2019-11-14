using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MarkSoftWPF
{
    public class GraddAddForm
    {
        public StackPanel line = new StackPanel();
        public TextBox tb = new TextBox();

        public StackPanel createGradLine(int gradCount)
        {
           
            line.Orientation = Orientation.Horizontal;
            line.Margin = new Thickness(0, 20, 0, 0);
            Label label = new Label();
            label.Content = "Градация:";
            label.Style = (Style)Application.Current.Resources["addFormLabelStyle"];
            line.Children.Add(label);
           
            line.Children.Add(tb);
            Button btn = new Button();

            return line;
        }
    }
}
