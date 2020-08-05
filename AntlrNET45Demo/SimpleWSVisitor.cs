using Antlr4.Runtime.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AntlrNET45Demo
{
    public class SimpleWSVisitor : WSBaseVisitor<object>
    {
        Dictionary<string, object> memory = new Dictionary<string, object>();

        public override object VisitProg([NotNull] WSParser.ProgContext context)
        {
            Console.WriteLine("------ VisitProg " + context.GetText());
            return base.VisitProg(context);
        }

        // 
        public override object VisitExpr([NotNull] WSParser.ExprContext context)
        {
            return Visit(context);
        }

        // addExpr op=('+'|'-') multExpr 
        public override object VisitAddExpr([NotNull] WSParser.AddExprContext context)
        {
            var left = Int32.Parse(Visit(context.expr()[0]).ToString());
            var right = Int32.Parse(Visit(context.expr()[1]).ToString());
            switch (context.op.Text)
            {
                case "+":
                    return left + right;
                case "-":
                    return left - right;
                default:
                    Console.WriteLine("Unkown op " + context.op.Text);
                    break;
            }
            return base.VisitAddExpr(context);
        }

        //  assign: Ident '=' expr ;
        public override object VisitAssign([NotNull] WSParser.AssignContext context)
        {
            var id = context.ID().GetText();
            var val = Visit(context.expr());
            memory[id] = val;
            return val;
        }

        // multExpr op=('*'|'/') miniExpr 
        public override object VisitMultExpr([NotNull] WSParser.MultExprContext context)
        {
            var left = Int32.Parse(Visit(context.expr()[0]).ToString());
            var right = Int32.Parse(Visit(context.expr()[1]).ToString());
            switch (context.op.Text)
            {
                case "*":
                    return left * right;
                case "/":
                    return left / right;
                default:
                    Console.WriteLine("Unkown op " + context.GetText());
                    break;
            }
            return base.VisitMultExpr(context);
        }

        public override object VisitInt([NotNull] WSParser.IntContext context)
        {
            return Int32.Parse(context.GetText());
        }

        public override object VisitIdent([NotNull] WSParser.IdentContext context)
        {
            var id = context.ID().GetText();
            if (memory.ContainsKey(id)) return memory[id];
            return null;
        }

        public override object VisitParens([NotNull] WSParser.ParensContext context)
        {
            return Visit(context.expr());
        }

        public override object VisitPrintExpr([NotNull] WSParser.PrintExprContext context)
        {
            Console.WriteLine(Visit(context.expr()));
            return base.VisitPrintExpr(context);
        }
    }
}
