using System.ComponentModel.DataAnnotations;

namespace Bakend_Nani.Models
{
    public class Revista
    {
        public int numero { get; set; }
       
        public string titulo { get; set; }
        [Required, StringLength (150) ]

        public string ayo { get; set;}
        

        public string inss { get; set; }
        [Required, StringLength(30)]

        public string precio { get; set; }

        public string Horaventa { get; set; }
        



        }






    }
