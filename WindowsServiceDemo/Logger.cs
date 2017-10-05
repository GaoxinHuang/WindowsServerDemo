using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsServiceDemo
{
    public static class Logger
    {
        public static void Log(string message)
        {
            string _message = String.Format("{0} {1}", message, Environment.NewLine);
            try
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "logfile.txt", _message);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
