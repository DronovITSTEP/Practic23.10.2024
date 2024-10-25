using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Practic23._10._2024
{
    internal class LogicUser : Logic
    {
        public LogicUser(List<List<Button>> buttons, 
            int turnToMove,
            string imageSource) : 
            base(buttons, turnToMove, imageSource) { }

        public override int Move()
        {
            return new Random().Next(range);
        }
    }
}
