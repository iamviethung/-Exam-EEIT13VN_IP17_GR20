using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivlab.Core.Models
{
    public class RefTimestamp
    {
        public RootRefObject RootRefObject { get; set; }
        public string Timestamp { get; set; }

        public RefTimestamp()
        {
            RootRefObject = new RootRefObject();
        }
    }
}
