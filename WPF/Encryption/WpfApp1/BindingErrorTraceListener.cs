using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class BindingErrorTraceListener : TraceListener
    {
        public override void Write(string s) { }

        public override void WriteLine(string message)
        {
            throw new Exception(message);
        }
    }
}
