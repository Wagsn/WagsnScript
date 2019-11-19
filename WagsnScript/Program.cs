using System;
using System.Reflection;
using System.Globalization;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text;
using System.Linq;
using Microsoft.CSharp;

namespace WagsnScript
{
    class Program
    {
        static void Main(string[] args)
        {
            WagsnScript.Runtime.Init(args);
            //Console.ReadKey();
        }
    }
}
