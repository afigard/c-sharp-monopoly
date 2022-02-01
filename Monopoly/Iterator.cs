using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class Iterator
    {
        public abstract Player First();
        public abstract Player Next();
        public abstract bool IsDone();
        public abstract Player CurrentItem();
    }
}
