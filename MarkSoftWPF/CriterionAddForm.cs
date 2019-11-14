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
    class CriterionAddForm
    {
        public Border border = new Border();
        public Button btn = new Button();
        public Button btn2 = new Button();
        public Button btn3 = new Button();
        public TextBox tb = new TextBox();
        public bool positive = true;
        public StackPanel betweenSP = new StackPanel();

        public int gradCount = 0;
        public CriterionAddForm(int formCount)
        {
            this.border.Style = (Style)Application.Current.Resources["addFormBorderStyle"];
            StackPanel mainSP = new StackPanel();
            StackPanel line = new StackPanel();
            line.Orientation = Orientation.Horizontal;
            Label label = new Label();
            label.Content = "Критерий:";
            label.Style = (Style)Application.Current.Resources["addFormLabelStyle"];
            line.Children.Add(label);

            tb.Name = "crit_" + formCount;
            line.Children.Add(tb);

            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"img/icon1.png", UriKind.RelativeOrAbsolute));
            img.Width = 15;
            btn.Content = img;
            btn.Margin = new Thickness(10, 0, 0, 0);
            btn.Name = "btn_" + formCount;

            line.Children.Add(btn);
            mainSP.Children.Add(line);
            mainSP.Children.Add(betweenSP);
            StackPanel line2 = new GraddAddForm().createGradLine(gradCount);
            gradCount++;

            Image img2 = new Image();
            img2.Source = new BitmapImage(new Uri(@"img/icon1.png", UriKind.RelativeOrAbsolute));
            img2.Width = 15;
            btn2.Content = img2;
            btn2.Margin = new Thickness(10, 0, 0, 0);
            btn2.Name = "btn_" + formCount;
            line2.Children.Add(btn2);
            mainSP.Children.Add(line2);

            StackPanel line3 = new StackPanel();
            
            Image img3 = new Image();
            img3.Height = 15;
            line3.Margin = new Thickness(15);
            img3.Source = new BitmapImage(new Uri(@"img/esc2.png", UriKind.RelativeOrAbsolute));
            line3.Children.Add(btn3);
            btn3.VerticalAlignment = VerticalAlignment.Bottom;
            btn3.Content = img3;
            btn3.Name = "btn_"+formCount;
            mainSP.Children.Add(line3);

            this.border.Child = mainSP;
        }
    }
}
