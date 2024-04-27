using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class tblSRS
    {
        public int c_sid {set; get;}
        public string c_name {set; get;}
        public string c_gender {set; get;}
        public string c_photo {set; get;}
        public string c_area {set; get;}
        public DateTime c_admission_date {set; get;} 
        public string c_hobby {set; get;}
        public IFormFile photo {set; get;}
    }
}