using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvp.BusinessLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public void Save()
        {
            throw new ApplicationException();
        }
    }
}
