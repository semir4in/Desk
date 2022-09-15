using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R4iny.Desk.Library.Data
{
    public class Entry : JsonSerializable
    {
        public string Name { get; set; }

        public Entry() { }

        public Entry(string name) : base()
        {
            this.Name = name;
        }
    }
}
