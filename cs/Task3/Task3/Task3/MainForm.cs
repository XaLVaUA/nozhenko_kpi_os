using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Task3
{
    public partial class MainForm : Form
    {
        private Random _random;

        public MainForm()
        {
            InitializeComponent();
            _random = new Random();
        }

        private void WorkOutButton_Click(object sender, EventArgs e)
        {
            waitingTimeIntensityChart.Series["Series1"].Points.Clear();
            downtimePercentIntensityChart.Series["Series1"].Points.Clear();
            countWaitTimeChart.Series["Series1"].Points.Clear();

            const int maxTick = 100;
            
            var leftWeight = int.Parse(leftWeightTextBox.Text);
            var rightWeight = int.Parse(rightWeightTextBox.Text);

            var leftInterval = int.Parse(leftIntervalTextBox.Text);
            var rightInterval = int.Parse(rightIntervalTextBox.Text);

            for (var interval = rightInterval; interval >= leftInterval; --interval)
            {
                var workPoints = DoTask(maxTick, interval, leftWeight, rightWeight);
                VisualizeWaitingTimeIntensity(workPoints, interval);
            }
        }

        private void VisualizeWaitingTimeIntensity(List<WorkPoint> workPoints, int intensity)
        {
            if (workPoints.Count <= 0) return;

            var waitingTimeIntensitySeries = waitingTimeIntensityChart.Series["Series1"];
            waitingTimeIntensitySeries.Points.Add(
                new DataPoint(workPoints.Where(x => !x.IsDownTime).Average(x => x.WaitingTime), intensity));

            var downtimePercentIntensitySeries = downtimePercentIntensityChart.Series["Series1"];
            downtimePercentIntensitySeries.Points.Add(
                new DataPoint((workPoints.Where(x => x.IsDownTime).Sum(x => x.WaitingTime) / workPoints.Where(x => !x.IsDownTime).Sum(x => x.WaitingTime)) * 100, intensity));

            var countWaitTimeSeries = countWaitTimeChart.Series["Series1"];
            countWaitTimeSeries.Points.Add(
                new DataPoint(workPoints.Count, workPoints.Where(x => !x.IsDownTime).Average(x => x.WaitingTime)));
        }

        private List<WorkPoint> DoTask(int maxTick, int interval, int leftWeight, int rightWeight)
        {
            var random = new Random();
            var stack = new Stack<SampleWork>();
            var workPoints = new List<WorkPoint>();

            var curTick = (long) 0;
            var lastTick = curTick;

            var state = State.Waiting;
            SampleWork curWork = null;
            var waitingTick = 0;
            stack.Push(new SampleWork(random.Next(leftWeight, rightWeight), curTick));

            while (curTick < maxTick)
            {
                if (stack.Count > 0)
                {
                    if (state == State.Waiting)
                    {
                        if (stack.Count > 0)
                        {
                            curWork = stack.Pop();
                            state = State.Working;

                            if (waitingTick != 0)
                            {
                                workPoints.Add(new WorkPoint(waitingTick, curTick, true));
                                waitingTick = 0;
                            }
                        }
                        else
                        {
                            ++waitingTick;
                        }
                    }

                    if (state == State.Working && curWork != null)
                    {
                        curWork.WorkOut();

                        if (curWork.IsDone)
                        {
                            curWork.DoneTime = curTick;
                            workPoints.Add(new WorkPoint(curTick - curWork.AddedTime, curTick, false));
                            state = State.Waiting;
                        }
                    }
                }

                if (curTick - lastTick >= interval)
                {
                    lastTick = curTick;

                    var weight = random.Next(leftWeight, rightWeight);
                    stack.Push(new SampleWork(weight, curTick));
                }

                ++curTick;
            }

            return workPoints;
        }
    }
}
