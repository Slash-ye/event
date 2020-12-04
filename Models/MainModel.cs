using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Event.Models
{
    public class MainModel
    {
        public long id { get; set; }
        public DateTime? createDate { get; set; }
        public string createBy { get; set; }
        public bool status { get; set; }
    }
}