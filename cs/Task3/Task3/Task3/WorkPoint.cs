namespace Task3
{
    public class WorkPoint
    {
        public long WaitingTime { get; set; }

        public long Tick { get; set; }

        public bool IsDownTime { get; set; }

        public WorkPoint(long waitingTime, long tick, bool isDownTime)
        {
            WaitingTime = waitingTime;
            Tick = tick;
            IsDownTime = isDownTime;
        }
    }
}