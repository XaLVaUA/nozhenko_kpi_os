using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    public class SampleWork
    {
        public long AddedTime { get; set; }

        public long DoneTime { get; set; }

        public int Weight { get; set; }

        public int CurWeightProgress { get; set; }

        public bool IsDone => CurWeightProgress >= Weight;

        public SampleWork(int weight, long addedTime)
        {
            CurWeightProgress = 0;
            Weight = weight;
            AddedTime = addedTime;
        }

        public void WorkOut()
        {
            ++CurWeightProgress;
        }
    }
}