using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        public float Price { get; set; }
        [ForeignKey("Category")]
        [Display(Name = "Category Name")]

        public int CategoryId { get; set; }

        [ForeignKey("Customer")]
        [Display(Name = "Customer Name")]

        public int CustomerId { get; set; }

        public Category Category { get; set; }

        public Customer Customer { get; set; }

        public int Qty { get; set; }
        public  float Total { get { return Qty * Price; } }

        public string InvoiceDate { get; set; }

        public float InvoiceNo { get; set; }

    }
}
