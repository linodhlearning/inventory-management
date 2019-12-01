using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Helpers
{
    public interface ILogger
    {
        void Log(string message);
    }
    public class Logger: ILogger
    {
        public void Log(string message)
        {
            //todo: Log the data to persistence;
        }
    }
}
