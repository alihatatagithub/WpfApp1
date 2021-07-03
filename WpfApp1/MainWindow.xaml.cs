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
using WpfApp1.Models;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationDbContext _Context;

        public MainWindow()
        {
            InitializeComponent();
            _Context = new ApplicationDbContext();
            InvoiceDate.Text = DateTime.Now.ToString();
        }

   

      

        private void Qty_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Price.ToString())
               && !string.IsNullOrWhiteSpace(Price.ToString()))
                {
                    TotalPrice.Text = (float.Parse(Price.Text.ToString()) * float.Parse(Qty.Text.ToString())).ToString();
        }
    }
            catch (Exception)
            {

                MessageBox.Show("Please Enter Correct Data");
            }
        }

        private void  Button_Click(object sender, RoutedEventArgs e)
        {
            Category category = new Category()
            {
                CategoryName = CategoryName.Text.ToString()
            };
            _Context.Categories.Add(category);
            Customer customer = new Customer()
            {
                Name = CustomerName.Text.ToString()
            };
            _Context.Customers.Add(customer);
             _Context.SaveChanges();
            Product product = new Product()
            {
                ProductName = ProductName.Text.ToString(),
                Price = float.Parse(Price.Text.ToString()),
                InvoiceDate = DateTime.UtcNow.ToString(),
                Qty = int.Parse(Qty.Text.ToString()),
                InvoiceNo = float.Parse(InvoiceNo.Text.ToString()),
                CustomerId = customer.Id,
                CategoryId = category.Id,



            };
            _Context.Products.Add(product);
             _Context.SaveChanges();
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(print, "invoice");
            }
        }

      
    }
}
