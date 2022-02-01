using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class ConcreteIterator : Iterator
    {
        ConcretePlayerAggregate aggregate;
        public int current = 0;
        // Constructor
        public ConcreteIterator(ConcretePlayerAggregate aggregate)
        {
            this.aggregate = aggregate;
        }
        // Gets first iteration item
        public override Player First()
        {
            current = 0;
            return aggregate[0];
        }
        // Gets next iteration item
        public override Player Next()
        {
            Player ret = null;
            if (current < aggregate.Count - 1)
            {
                ret = aggregate[++current];
            }
            return ret;
        }
        // Gets current iteration item
        public override Player CurrentItem()
        {
            return aggregate[current];
        }
        // Gets whether iterations are complete
        public override bool IsDone()
        {
            return current >= aggregate.Count;
        }
    }
}
