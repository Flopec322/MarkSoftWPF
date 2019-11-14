using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarkSoftWPF{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int countNeg = 0;
        public int countPos = 0;
        void layoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public MainWindow()
        {
            InitializeComponent();

         
            titleBorder.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
            mainMenuBorder.MouseLeftButtonDown += new MouseButtonEventHandler(layoutRoot_MouseLeftButtonDown);
          
        }

        public void Button_Click_Menu_1(object sender, RoutedEventArgs e)
        {
            if (workSpaceTab.Visibility != Visibility.Visible)
            {
                createForm(true);
                createForm(true);
                createForm(false);
                createForm(false);
            }
            workSpaceTab.Visibility = Visibility.Visible;
            workSpaceTab.IsSelected = IsActive;
        }

        private void Button_Click_Menu_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Menu_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Minimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public int formsCount = 0;
        List<CriterionAddForm> criterionList = new List<CriterionAddForm>();
        List<List<GraddAddForm>> gradMatrix = new List<List<GraddAddForm>>();

        private void createForm(bool positive)
        {
            gradMatrix.Add(new List<GraddAddForm>());
            criterionList.Add(new CriterionAddForm(formsCount));
            criterionList[formsCount].btn.Click += Button_Click_Add_Critrrian;
            criterionList[formsCount].btn2.Click += Button_Click_Add_Grad;
            criterionList[formsCount].btn3.Click += Button_Click_Remove_Form;
            if (positive)
            {
                addCritPanel.Children.Add(criterionList[formsCount].border);
                countPos++;
            }
            else
            {
                addCritPanelNeg.Children.Add(criterionList[formsCount].border);
                criterionList[formsCount].positive = false;
                countNeg++;
            }
            formsCount++;
        }

        private void Button_Click_Add_Critrrian(object sender, RoutedEventArgs e)
        {
            string name;
            name = (sender as Button).Name;
            string[] words = name.Split('_');
            int formNumber = Int32.Parse(words[1]);
            Console.WriteLine(formNumber);
            createForm(criterionList[formNumber].positive);
        }

        private void Button_Click_Add_Grad(object sender, RoutedEventArgs e)
        {

            //GraddAddForm grad = new GraddAddForm();
            string name;
            name = (sender as Button).Name;
            string[] words = name.Split('_');
            int formNumber = Int32.Parse(words[1]);
            StackPanel grad;
            Console.WriteLine(words[1]);
            gradMatrix[formNumber].Add(new GraddAddForm());
            if (criterionList[formNumber].gradCount > 0)
            {
                Image img = new Image();
                Button btn = new Button();
                img.Source = new BitmapImage(new Uri(@"img/esc2.png", UriKind.RelativeOrAbsolute));
                btn.Content = img;
                btn.Margin = new Thickness(10, 0, 0, 0);
                btn.Height = 15;
                btn.Name = "close_"+(formNumber + 1) + "_" + criterionList[formNumber].gradCount;
                btn.Click += Button_Click_Remove_Grad;
                grad =  gradMatrix[formNumber][criterionList[formNumber].gradCount - 1].createGradLine(criterionList[formNumber].gradCount);
                grad.Children.Add(btn);
                criterionList[formNumber].gradCount++;
            }
            else
            {
                criterionList[formNumber].gradCount++;
                grad = gradMatrix[formNumber][criterionList[formNumber].gradCount].createGradLine(criterionList[formNumber].gradCount);
               
            }
            criterionList[formNumber].betweenSP.Children.Add(grad);

        }

        private void Button_Click_Remove_Form(object sender, RoutedEventArgs e)
        {
           
            string name;
            name = (sender as Button).Name;
            string[] words = name.Split('_');
            int formNumber = Int32.Parse(words[1]);
            if(criterionList[formNumber].positive)
                if (countPos > 1)
                {
                    addCritPanel.Children.Remove(criterionList[formNumber].border);
                    countPos--;
                }
            if (!criterionList[formNumber].positive)
                if (countNeg > 1)
                {
                    addCritPanelNeg.Children.Remove(criterionList[formNumber].border);
                    countNeg--;
                }
        }
        private void Button_Click_Remove_Grad(object sender, RoutedEventArgs e)
        {

            string name;
            name = (sender as Button).Name;
            string[] words = name.Split('_');
            int formNumber = Int32.Parse(words[1]);
            int critNumber = Int32.Parse(words[2]);
            Console.WriteLine("Form: " + words[1] + "Grad: " + words[2]);
            criterionList[formNumber - 1].betweenSP.Children.Remove(gradMatrix[formNumber - 1][critNumber - 1].line);
        }

        private void Button_Click_Submit(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(criterionList.Count);
        }
    }
}
