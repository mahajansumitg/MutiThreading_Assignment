using MultiThreading_Assignment.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreading_Assignment.Model
{
    public class Customer : NotifyPropertyOnChanged
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; NotifyPropertyChanged("ID"); }
        }

        private int time;
        public int Time
        {
            get { return time; }
            set { time = value; NotifyPropertyChanged("Time"); }
        }

        private string status;
        public string Status
        {
            get { return status == "" ? status = "Pending" : status; }
            set { status = value; NotifyPropertyChanged("Status"); }
        }

        public Customer() { }
        public Customer(int id, int time)
        {
            ID = id;
            Time = time;
            Status = "Pending";
        }

    }
}
