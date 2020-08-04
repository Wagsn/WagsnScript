﻿using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrNET45Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"1 + (2 - 3) * 4";

            var stream = new AntlrInputStream(input);
            var lexer = new WSLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new WSParser(tokens);
            var tree = parser.program();

            var visitor = new SimpleWSVisitor();
            var result = visitor.Visit(tree);

            Console.WriteLine(tree.ToStringTree(parser));
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
