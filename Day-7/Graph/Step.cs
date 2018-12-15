using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class Step
    {
        private List<Step> _next = new List<Step>();
        public List<Step> Next
        {
            get => (_next = _next.OrderBy(n => n.Value).ToList());
        }

        private List<Step> _previous = new List<Step>();
        public List<Step> Previous
        {
            get => (_previous = _previous.OrderByDescending(n => n.Value).ToList());
        }

        public string Value { get; set; }

        public bool IsCompleted { get; set; } = false;
        public bool InProgress{ get; set; }  = false;


        public Step(string val) => Value = val;

        public void Complete() => IsCompleted = true;

        public bool CanComplete()
        {
            bool can = true;//If there are no previous items we can complete this node
            foreach (var item in Previous)
            {
                can = can && item.IsCompleted;
            }
            return can;
        }

        
    }
}
