﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Math;

namespace TeleprompterConsole
{
    class TelePrompterConfig
    {
        private object lockHandle = new object();
        public int DelayInMilliseconds { get; private set; } = 200;

        public void UpdateDelay(int increment) //negative to speed up
        {
            var newDelay = Min(DelayInMilliseconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            lock (lockHandle)
            {
                DelayInMilliseconds = newDelay;
            }
        }

        public bool Done => done;

        private bool done;

        public void SetDone()
        {
            done = true;
        }
    }
}
