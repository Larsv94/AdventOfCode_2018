using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    class GraphReader
    {
        DirectionalGraph Graph;

        List<Step> Nodes = new List<Step>();

        Queue<Step> steps = new Queue<Step>();

        public GraphReader( DirectionalGraph graph) => (Graph, Nodes) = (graph, graph.Nodes);
        
        public string GetSteps()
        {
            ProcessGraph();
            string stepsString = "";
            while (steps.Count > 0)
            {
                stepsString += steps.Dequeue().Value;
            }
            return stepsString;
        }

        public List<Step> AvailableNodes//Returns an ordered list of all items that can be completed but are not yet completed or in progress
        {
            get => Nodes.Where(n => n.CanComplete() && !n.IsCompleted && !n.InProgress).OrderBy(n => n.Value).ToList();
        }

        private void ProcessGraph()
        {
            while (AvailableNodes.Count > 0)
            {
                var item = AvailableNodes[0];
                item.Complete();
                steps.Enqueue(item);
                //Since all steps are instantly completed we never set InProgress to True
            }
        }

        public int GetDurationWithWorkersAndTime(int workers,int defaultDuration)
        {
            (int workUntil, Step workingOn)[] workersArray = new (int workUntil, Step workingOn)[workers];//Create array with workers
            int time = -1;
            while (Nodes.Where(n => n.CanComplete() && !n.IsCompleted).ToList().Count > 0)//We work until all steps are completed
            {
                time++;
                for (int i = 0; i < workers; i++)
                {
                    //All workers that have worked until a time that is smaller than the current time are done working, lets assign them work
                    if (workersArray[i].workUntil - 1 < time)
                    {
                        if (workersArray[i].workingOn != null)
                        {   //if they just finished their work we mark their step as completed
                            workersArray[i].workingOn.Complete();
                            steps.Enqueue(workersArray[i].workingOn);
                            workersArray[i].workingOn = null;
                        }
                        if (AvailableNodes.Count > 0)
                        {
                            //if new work is available we assign it to the current worker
                            var item = AvailableNodes[0];
                            int duration = (char.ToUpper(item.Value[0]) - 64) + defaultDuration;
                            workersArray[i].workUntil = time + duration;
                            item.InProgress = true;//Item is marked as in progress and won't reappear for the next iteration
                            workersArray[i].workingOn = item;
                        }
                    }
                }
            }
            return time;
        }




    }
}
