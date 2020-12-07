using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTestForLog4Net.TestClasses.FindTheShortestWay
{
    public class DicLagosSearch
    {
        //definition: the min id is the begin node; the max id is the end node. others is not important.
        public List<StationNeighborCost> Nodes { get; set; }
        public List<PathWay> GoThroughWays { get; set; }
        public List<PathWay> ShortWays { get; set; }

        public DicLagosSearch()
        {
            Nodes = new List<StationNeighborCost>();
            GoThroughWays = new List<PathWay>();
            ShortWays = new List<PathWay>();
        }

        public void FindWays()
        {
            PathWay pw;

            pw = new PathWay();
            pw.AddStationNeighborCost(Nodes[0]);
            GoThroughWays.Add(pw);

            var list = GoThroughWays.FindAll(x => x.LastStation.ChildNodes != null && !x.IsSearch && x.LastStation.ChildNodes.Count > 0);
            while (list!=null&&list.Count>0)
            {
                foreach (var itm in list)
                {
                    itm.IsSearch = true;
                    for (int j = 0; j < itm.LastStation.ChildNodes.Count; j++)
                    {
                        var tmp = itm.GetNewObject();
                        tmp.AddStationNeighborCost(Nodes.First(x => x.ID == itm.LastStation.ChildNodes[j].Key.ID));
                        GoThroughWays.Add(tmp);
                    }
                }
                list = GoThroughWays.FindAll(x => x.LastStation.ChildNodes != null && !x.IsSearch && x.LastStation.ChildNodes.Count > 0);
            }
        }
    }

    public class PathWay
    {
        public bool IsSearch { get; set; }
        private List<StationNeighborCost> Ways;
        public StationNeighborCost LastStation
        {
            get
            {
                StationNeighborCost tmp;
                if (Ways != null && Ways.Count > 0)
                {
                    tmp = Ways[Ways.Count - 1];
                }
                else
                {
                    tmp = null;
                }
                return tmp;
            }
        }

        private int pathWeight;
        public int PathWeight { get { return pathWeight; } }
        public string PathDisplay { get {
                return string.Concat(Ways.Select(x => (x.Name + " --> ")));
            } }

        public int AddStationNeighborCost(StationNeighborCost station)
        {
            if (LastStation != null)
            {
                var child = LastStation.ChildNodes.Find(x => x.Key.ID == station.ID);
                pathWeight += child.Value;
            }
            Ways.Add(station);

            return PathWeight;
        }

        public PathWay()
        {
            IsSearch = false;
            pathWeight = 0;
            Ways = new List<FindTheShortestWay.StationNeighborCost>();
        }
        public List<StationNeighborCost> GetWays()
        {
            return Ways;
        }

        private PathWay(List<StationNeighborCost> Ways, int pathWeight)
        {
            this.Ways = (from x in Ways select x).ToList();
            this.pathWeight = pathWeight;
            IsSearch = false;
        }

        public PathWay GetNewObject()
        {
            return new PathWay(Ways, pathWeight);
        }
    }

    public class StationNeighborCost
    {
        public bool IsSearch { get; set; }
        private StationNode StatNode;
        public List<KeyValuePair<StationNode, int>> ChildNodes { get; set; }

        public int ID { get { return StatNode.ID; } }
        public string Name { get { return StatNode.Name; } }

        public StationNeighborCost(StationNode StatNode)
        {
            this.StatNode = StatNode;
            ChildNodes = new List<KeyValuePair<FindTheShortestWay.StationNode, int>>();
            IsSearch = false;
        }

        public void ResetStatNode(StationNode StatNode)
        {
            this.StatNode = StatNode;
        }
    }

    public class StationNode
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
