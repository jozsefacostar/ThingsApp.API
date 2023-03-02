using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Things.DDD.API.TimerFeatures
{
    public class TimerManager
    {
        private Timer? _timer;
        private AutoResetEvent? _autoResetEvent;
        private Action? _action;
        public DateTime TimerStarted { get; set; }
        public bool IsTimerStarted { get; set; }

        public void PrepareTimer(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(false);
            _timer = new Timer(Execute, _autoResetEvent, 1000, 20000);
            TimerStarted = DateTime.Now;
            IsTimerStarted = true;
        }

        public void Execute(object? stateInfo)
        {
            _action();

            if ((DateTime.Now - TimerStarted).Hours > 100)
            {
                IsTimerStarted = false;
                _timer.Dispose();
            }
        }
    }
}
