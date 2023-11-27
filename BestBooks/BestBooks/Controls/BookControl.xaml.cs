using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace BestBooks.Controls
{
    /// <summary>
    /// Interaction logic for BookControl.xaml
    /// </summary>
    public partial class BookControl : UserControl
    {
        public BookControl()
        {
            InitializeComponent();
        }

        public Book Book
        {
            get
            {
                return (Book)GetValue(BookProperty);
            }
            set
            {
                SetValue(BookProperty, value);
            }
        }

        public static readonly DependencyProperty BookProperty = DependencyProperty.Register("Book", typeof(Book), typeof(BookControl), new PropertyMetadata(null, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BookControl control)
            {
                control.title.Text += (e.NewValue as Book).Title;
                control.author.Text += (e.NewValue as Book).Author;
            }
        }
    }
}
