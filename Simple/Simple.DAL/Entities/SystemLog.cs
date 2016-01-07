using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple.DAL.Entities
{
    [Table("Security.SystemLog")]
    public class SystemLog
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public String Level { get; set; }
        public String Logger { get; set; }
        public String Message { get; set; }
        public String Exception { get; set; }
    }
}
