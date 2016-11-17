using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Publisher
    {
        static void Main(string[] args)
        {
            Observable publisher = new Observable();
            Observer newSubscriber = new Observer(publisher, "Sub1");

            publisher.NewCarName = "Accent 2017";
            publisher.NewCarName = "Tucsan 2017";

            Observer newSubscriber1 = new Observer(publisher, "Sub2");

            Observer newSubscriber2 = new Observer(publisher, "Sub3");

            publisher.NewCarName = "Audi Q5";
        }
    }

    class Observable
    {
        private string _NewCarName;
        public string NewCarName
        {
            get
            {
                return _NewCarName;
            }
            set
            {
                _NewCarName = value;
                OnValueChanged();
            }
        }
        public event EventHandler NewCarArrived;

        protected void OnValueChanged()
        {
            if (NewCarArrived != null)
                NewCarArrived(this, EventArgs.Empty);
        }
    }

    class Observer
    {
        private string ObserverName { get; set; }
        public Observer(Observable observable, string Name)
        {
            ObserverName = Name;
            observable.NewCarArrived += NewCar;
        }

        private void NewCar(object sender, EventArgs e)
        {
            Console.WriteLine($"New car arrived {((Observable)sender).NewCarName} notify for {this.ObserverName}");
        }
    }
}
