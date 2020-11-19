using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRESOTEL
{
    public static class Log
    {
        public static void Error(Type orginClass, string message)
        {
            // get call stack
            StackTrace stackTrace = new StackTrace();

            // get calling method name
            var CallingMethodeName = stackTrace.GetFrame(1).GetMethod().Name;
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                w.Write("[" + DateTime.Now.ToLongTimeString() + "]");
                w.Write("[Error] IN ");
                w.Write("[" + orginClass.Name + "] AT ");
                w.Write("[" + CallingMethodeName + "] : ");
                w.WriteLine(message);
            }
        }
    }
}
