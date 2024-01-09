using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mkr2.Models
{
    public class Abiturient
    {
        public int Id { get; set; }
        public string surname { get; set; }
        public string sex { get; set; }
        public int graduation_year { get; set; }
        public int total_score { get; set; }
    }
}
