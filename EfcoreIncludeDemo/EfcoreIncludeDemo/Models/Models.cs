using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfcoreIncludeDemo.Models
{
    public class Model1
    {
        public int Id { get; set; }
        public virtual List<Model2> Model2 {get;set;}
    }

    public class Model2
    {
        public int Id { get; set; }
        public Model3 Model3 { get; set; }
    }

    public class Model3
    {
        public int Id { get; set; }
        public Model4 Model4 { get; set; }
    }

    public class Model4
    {
        public int Id { get; set; }

    }
}
