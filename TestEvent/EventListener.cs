using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEvent
{
    class EventListener
    {
        private ListWithChangedEvent List;

        public EventListener(ListWithChangedEvent list, ChangedEventHandler eventHandler)
        {
            List = list;
            // Add "ListChanged" to the Changed event on "List".
            List.Changed += eventHandler;
        }

        // This will be called whenever the list changes.
        private void ListChanged(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
            Console.WriteLine(e);
            Console.WriteLine("This is called when the event fires.");
        }

        public void Detach()
        {
            // Detach the event and delete the list
            List.Changed -= new ChangedEventHandler(ListChanged);
            List = null;
        }
    }
}
