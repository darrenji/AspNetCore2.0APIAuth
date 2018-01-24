using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ApplicationSettings
    {
        //需要借助 IOptions，这里才有值
        public string TestSetting { get; set; }
        public string SecurityKey { get; set; }
    }
}
