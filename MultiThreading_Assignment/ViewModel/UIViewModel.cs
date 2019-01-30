using MultiThreading_Assignment.Business_Logic;
using MultiThreading_Assignment.Model;
using MultiThreading_Assignment.Utils;
using MultiThreading_Assignment.View;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace MultiThreading_Assignment.ViewModel
{
    public class UIViewModel : NotifyPropertyOnChanged
    {

        #region Properties

        private int noOfThreads;
        public int NoOfThreads
        {
            get { return noOfThreads; }
            set { noOfThreads = value; NotifyPropertyChanged("NoOfThreads"); }
        }

        private int noOfCustommers;
        public int NoOfCustommers
        {
            get { return noOfCustommers; }
            set { noOfCustommers = value; NotifyPropertyChanged("NoOfCustommers"); }
        }

        #endregion

        #region Command Properties

        public ICommand StartOP { get; set; }
        public ICommand ResetAll { get; set; }
        public ICommand ExitApp { get; set; }

        #endregion

        List<Customer> customersList;
        CreateCustomers CreateCustomers;

        public UIViewModel()
        {
            customersList = new List<Customer>();
            CreateCustomers = new CreateCustomers();
            //TotalTime = "00:00:00";

            InitializeCommands();
            
        }

        //#region StopWatch Timer

        //private DispatcherTimer timer;
        //private int timeTick;

        //private void InitializeTimer()
        //{
        //    timer = new DispatcherTimer();
        //    timer.Interval = TimeSpan.FromSeconds(1);
        //    timer.Tick += (object sender, EventArgs e) =>
        //    {
        //        timeTick++;
        //        TotalTime = ConvertToHHMMSSmm(timeTick);
        //    };
        //}

        //private string ConvertToHHMMSSmm(int input)
        //{
        //    TimeSpan t = TimeSpan.FromSeconds(input);
        //    return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
        //}
        //#endregion

        private void InitializeCommands()
        {
            StartOP = new Command(StartOPeration, CanPerform);
            ResetAll = new Command(Reset);
            ExitApp = new Command(ExitApplication);
        }
        
        #region AllCommand actions

        private void StartOPeration(object obj)
        {
            if (NoOfCustommers > 0 && NoOfThreads > 0)
            {
                customersList = CreateCustomers.CustomerCreation(noOfCustommers);

                TimerStopWatch.InitializeTimer();
                TimerStopWatch.Reset();
                TimerStopWatch.Start();

                CreateThreads.ResetAll();

                CreateThreads.CreateAndPerform(NoOfThreads, NoOfCustommers, customersList);

                TimerStopWatch.Stop();
            }
            else
            {
                MessageBox.Show("No of threads & no of customers should be greater than zero.");
            }

        }

        private bool CanPerform(object arg)
        {
            //return !(NoOfThreads == 0) && !(NoOfCustommers == 0);
            return true;
        }

        private void Reset(object obj)
        {
            NoOfThreads = 0; NotifyPropertyChanged("NoOfThreads");
            NoOfCustommers = 0; NotifyPropertyChanged("NoOfCustommers");

            TimerStopWatch.Reset();

            customersList.Clear();

            CreateThreads.ResetAll();
        }

        private void ExitApplication(object obj)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
