using System;
using System.Threading;

namespace DigitalClock
{
     public class ClockPublisher
     {
        private object dateTime;

        //Create Delegate 
        public delegate void SecondChangeHandler(ClockPublisher clockPublisher,Clock time );
          //Create Envent based on delegate
          public event SecondChangeHandler SecondChange;
          // Create method to fire Event
          public void OnSecondChange(ClockPublisher clockPublisher, Clock time)
          {
               SecondChange(clockPublisher , time); 
          }

          // Setup Clock Running
          // On each secon it will raise an event to display clock
          public void Run()
          {
               while (true)
               {
                   Thread.Sleep(1000);
                   var dateTime = DateTime.Now;
                   Clock time = new Clock(dateTime.Hour, dateTime.Minute, dateTime.Second);
                   OnSecondChange(this, time);
               }
          }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}