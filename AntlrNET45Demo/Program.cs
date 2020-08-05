using Antlr4.Runtime;
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
            string input = System.IO.File.ReadAllText("test/statement.ws");
            Console.WriteLine(input);

            var stream = new AntlrInputStream(input);
            var lexer = new WSLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new WSParser(tokens);

            //new CommonTree()
            var tree = parser.prog();

            Console.WriteLine("tree.ToStringTree(parser)");
            Console.WriteLine(tree.ToStringTree(parser));

            var visitor = new SimpleWSVisitor();
            var result = visitor.Visit(tree);
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
