using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace cslabs
{
    class Journal
    {
        private List<JournalEntry> entries;
        public void StudentsChanged(object obj, StudentsChangedEventArgs<string> eventArgs)
        {
            entries.Add(new JournalEntry(eventArgs.Name, eventArgs.Action, eventArgs.PropertyName, eventArgs.Index));
        }

        public Journal()
        {
            entries = new List<JournalEntry>(0);
        }

        class JournalEntry
        {
            public string Name { get; set; }
            public Action Action { get; set; }

            public string PropertyName { get; set; }

            public string Key { get; set; }

            public JournalEntry(string name, Action action, string propertyName, string key)
            {
                Name = name;
                Action = action;
                PropertyName = propertyName;
                Key = key;
            }
            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3}", this.Name, this.Action, this.PropertyName, this.Key);
            }
        }

        public override string ToString()
        {
            return entries.Aggregate("Journal:\n", (str, next) => str += next.ToString() + '\n');
        }

    }
}
