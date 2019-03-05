using MultiThreading_Assignment.Model;
using MultiThreading_Assignment.Utils;
using MultiThreading_Assignment.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MultiThreading_Assignment.Business_Logic
{
    public static class CreateThreads
    {
        public static void CreateAndPerform(int NoOfThreads, int NoOfCustommers, List<Customer> customersList)
        {
            StartTimer();

            if (NoOfThreads == 1 && NoOfCustommers > 1)    //One thread for all customers
            {
                Create(customersList);
                CreateWatcherThread(NoOfThreads);
                DisplayPopup();
            }
            else if ((NoOfThreads == NoOfCustommers) || (NoOfThreads > NoOfCustommers))     //one thread per customer
            {
                customersList.ForEach(c => Create(new List<Customer>() { c }));
                CreateWatcherThread(NoOfThreads);
                DisplayPopup();
            }
            else  //divide the cust n assign threads
            {
                List<Customer>[] customersLists = new List<Customer>[NoOfThreads];                   //Array of lists for each (thread => one list)

                for (int i = 0; i < NoOfThreads; i++) customersLists[i] = new List<Customer>();      //initializing each list in lists[]

                int tmp = 0;
                foreach(Customer c in customersList)                  //Adding one customer to each thread like cards
                {
                    customersLists[tmp++].Add(c);
                    tmp %= NoOfThreads;
                }

                for (int i = 0; i < NoOfThreads; i++) Create(customersLists[i]);      //Creating threads for no of threads

                CreateWatcherThread(NoOfThreads);
                DisplayPopup();
            }
        }

        #region Thread creation

        public static int Threads = 0;
        public static int AcceptedCust = 0;
        public static int RejectedCust = 0;

        public static void ResetAll()
        {
            Threads = 0;
            AcceptedCust = 0;
            RejectedCust = 0;
            timeTick = 0;
        }

        public static void Create(List<Customer> listToPerform)   //Create one thread for list of customer/customers
        {
            Thread thread = new Thread(() =>
            {
                foreach (Customer customer in listToPerform)
                {
                    Thread.Sleep(customer.Time);

                    Predicate<int> criteria = (id) => (id % 2 == 0) ? true : false; 

                    if(criteria.Invoke(customer.ID))
                    { 
                        customer.Status = "Accepted";
                        InvokeAcceptAndPending(++AcceptedCust, RejectedCust);
                    }
                    else
                    {
                        customer.Status = "Rejected";
                        InvokeAcceptAndPending(AcceptedCust, ++RejectedCust);
                    }
                    Invoke(customer);
                }
                Invoke(++Threads);
            });
            thread.Start();
        }

        public static void CreateWatcherThread(int MaxThreads)   //Creating watcher thread to check all threads are completed or not & then stopping the stopwatch
        {
            Thread thread = new Thread(() =>
            {
                while (Threads != MaxThreads){}
                StopTimer();
            });
            thread.Start();
        }

        //Display OutputWindow as a Popup on UI
        public static MainWindow MainWindow = Mediator.getVar("MainWindow") as MainWindow;    //On which popup OutputWindow will be displaid
        public static OutputWindow_View OutputWindow_View;        //Popup to display
        public static void DisplayPopup()
        {
            MainWindow.Opacity = 0.5;
            OutputWindow_View = new OutputWindow_View
            {
                Owner = MainWindow
            };
            OutputWindow_View.ShowDialog();
        }

        //To change anything in Popup OutputWindow
        public static void Invoke<T>(T obj) //To update total no of threads completed & listview 
        {
            Type type = obj.GetType();
            switch (type.Name.ToString())
            {
                case "Int32":
                    OutputWindow_View.Dispatcher.BeginInvoke(DispatcherPriority.Normal,new Action(
                        delegate() 
                        {
                            OutputWindow_View.TotalThreads.Text = obj.ToString();
                        }));
                    break;
                case "Customer":
                    OutputWindow_View.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                        delegate ()
                        {
                            OutputWindow_View.listViewList.Add(obj as Customer);
                        }));
                    break;
                default:
                    MessageBox.Show("Unknown Datatype received in Invoke");
                    break;
            }
        }

        public static void InvokeAcceptAndPending(int acc, int rej)   //update total customers accepted n rejected
        {
            OutputWindow_View.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                        delegate ()
                        {
                            OutputWindow_View.Accepted.Text = acc.ToString();
                            OutputWindow_View.Rejected.Text = rej.ToString();
                        }));
        }

        #endregion

        #region StopWatch Timer

        private static DispatcherTimer timer;
        private static int timeTick;

        private static void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (object sender, EventArgs e) =>
            {
                timeTick++;
                OutputWindow_View.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                            delegate ()
                            {
                                OutputWindow_View.TotalTime.Text = ConvertToHHMMSSmm(timeTick);
                            }));
            };
        }

        private static string ConvertToHHMMSSmm(int input)
        {
            TimeSpan t = TimeSpan.FromSeconds(input);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds);
        }

        private static void StartTimer()
        {
            InitializeTimer();
            timeTick = 0;
            timer.Start();
        }

        private static void StopTimer()
        {
            timer.Stop();
            OutputWindow_View.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                           delegate ()
                           {
                               OutputWindow_View.TotalTime.Text = ConvertToHHMMSSmm(timeTick);
                           }));
        }
        #endregion
    }
}
