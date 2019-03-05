using MultiThreading_Assignment.Utils;
using MultiThreading_Assignment.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MultiThreading_Assignment.Business_Logic
{
    public static class TimerStopWatch
    {
        public static DispatcherTimer timer;
        public static int timeTick;

        public static UIView uIView = Mediator.getVar("UIView") as UIView;

        public static void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (object sender, EventArgs e) =>
            {
                timeTick++;
                uIView.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                            delegate ()
                            {
                                //uIView.TotalTime.Text = ConvertToHHMMSSmm(timeTick);
                            }));
            };
        }

        public static string ConvertToHHMMSSmm(int input)
        {
            TimeSpan t = TimeSpan.FromSeconds(input);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
        }

        public static void Start()
        {
            timeTick = 0;
            timer.Start();
        }

        public static void Stop()
        {
            timer.Stop();
            timer.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                            delegate ()
                            {
                                //uIView.TotalTime.Text = ConvertToHHMMSSmm(timeTick);
                            }));
        }

        public static void Reset()
        {
            timer.Stop();
            uIView.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                            delegate ()
                            {
                                //uIView.TotalTime.Text = "00:00:00";
                            }));
            timeTick = 0;
        }
    }{
    }
}
