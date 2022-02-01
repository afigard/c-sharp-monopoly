using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class ConcretePlayerAggregate : PlayerAggregate
    {
        List<Player> items = new List<Player>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
        // Get item count
        public int Count
        {
            get { return items.Count; }
        }
        // Indexer
        public Player this[int index]
        {
            get { return items[index]; }
            set { items.Insert(index, value); }
        }
    }
}
