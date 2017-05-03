using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivlab.Core.Models
{
    public class RootRefObject
    {
        public Tank1 tank1
        {
            get;
            set;
        }
        public Tank2 tank2 { get; set; }
        public Tank3 tank3 { get; set; }
        public Pumpe1 pumpe1 { get; set; }
        public Pumpe2 pumpe2 { get; set; }
        public Pumpe3 pumpe3 { get; set; }
        public Adg1 adg1 { get; set; }
        public Adg2 adg2 { get; set; }
        public Adg3 adg3 { get; set; }

        public Gas1 gas1 { get; set; }
        public Gas2 gas2 { get; set; }

        public RootRefObject()
        {
            tank1 = new Tank1();
            tank2 = new Tank2();
            tank3 = new Tank3();

            pumpe1 = new Pumpe1();
            pumpe2 = new Pumpe2();
            pumpe3 = new Pumpe3();

            adg1 = new Adg1();
            adg2 = new Adg2();
            adg3 = new Adg3();

            gas1 = new Gas1();
            gas2 = new Gas2();

        }

    }
}
