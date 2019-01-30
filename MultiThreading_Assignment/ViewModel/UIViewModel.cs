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

            InitializeCommands();
            
        }

        private void InitializeCommands()
        {
            StartOP = new Command(StartOPeration, CanPerform);
            ResetAll = new Command(Reset);
            ExitApp = new Command(ExitApplication);
        }
        
        #region AllCommand actions

        private void StartOPeration(object obj)
        {
            if (noOfCustommers > 0 && noOfThreads > 0)
            {
                customersList = CreateCustomers.CustomerCreation(noOfCustommers);

                TimerStopWatch.InitializeTimer();
                TimerStopWatch.Reset();
                TimerStopWatch.Start();

                CreateThreads.ResetAll();

                CreateThreads.CreateAndPerform(noOfThreads, noOfCustommers, customersList);

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
            if (noOfCustommers > 0 && noOfThreads > 0)
            {
                noOfThreads = 0; NotifyPropertyChanged("NoOfThreads");
                noOfCustommers = 0; NotifyPropertyChanged("NoOfCustommers");

                TimerStopWatch.Reset();

                customersList.Clear();

                CreateThreads.ResetAll();
            }
            else
            {
                noOfThreads = 0; NotifyPropertyChanged("NoOfThreads");
                noOfCustommers = 0; NotifyPropertyChanged("NoOfCustommers");
            }
        }

        private void ExitApplication(object obj)
        {
            Application.Current.Shutdown();
        }

        #endregion
    }
}
