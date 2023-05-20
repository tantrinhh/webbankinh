using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webbankinh.Context;
namespace webbankinh.Models
{
    public class HomeModel
    {
        public List<product> products { get; set; }
        public List<category> categories { get; set; }
    }
}