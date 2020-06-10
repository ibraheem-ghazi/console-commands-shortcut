using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCommandsShortcut.Structs
{
    public class ConsoleCommand
    {
        public String Shortcut { get; set; }
        public String Command { get; set; }
        public bool Enable { get; set; } = true;
    }
}
