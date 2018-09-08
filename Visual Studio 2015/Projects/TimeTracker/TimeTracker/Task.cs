using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    public class Task
    {
        public int i;
        public string name;
        public int goaltime;
        public int spenttime;
        public Task(int i, string name, int goaltime, int spenttime)
        {
            this.i = i;
            this.name = name;
            this.goaltime = goaltime;
            this.spenttime = spenttime;
        }
    }
}
