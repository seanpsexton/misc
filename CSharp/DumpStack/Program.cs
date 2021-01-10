using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DumpStack
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        private static string DumpFrames()
        {
            StackTrace st = new StackTrace(1, true);
            StackFrame[] stFrames = st.GetFrames();
            StringBuilder sbOut = new StringBuilder();

            sbOut.AppendLine("##");
            sbOut.AppendLine($"## ===== STACK =====)");
            foreach (StackFrame sf in stFrames)
            {
                var mi = (MethodInfo)sf.GetMethod();
                var methodSig = mi.GetSignature();

                sbOut.AppendLine($"## {methodSig} ({mi.DeclaringType.FullName})");
            }

            var info = sbOut.ToString();

            return info;
        }

    }
}
