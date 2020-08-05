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
            var left = Int32.Parse(Visit(context.addExpr()).ToString());
            var right = Int32.Parse(Visit(context.multExpr()).ToString());
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
            var left = Int32.Parse(Visit(context.multExpr()).ToString());
            var right = Int32.Parse(Visit(context.miniExpr()).ToString());
            switch (context.op.Text)
            {
                case "*":
                    return left * right;
                case "/":
                    return left / right;
                default:
                    Console.WriteLine("Unkown op " + context.op.Text);
                    break;
            }
            return base.VisitMultExpr(context);
        }

        public override object VisitMiniExpr([NotNull] WSParser.MiniExprContext context)
        {
            return Visit(context);
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
            return Visit(context);
        }

        public override object VisitAddExpression([NotNull] WSParser.AddExpressionContext context)
        {
            return base.VisitAddExpression(context);
        }

        public override object VisitPrintExpr([NotNull] WSParser.PrintExprContext context)
        {
            Console.WriteLine(Visit(context.expr()));
            return base.VisitPrintExpr(context);
        }


        //public override object VisitParenthesis(WSParser.ParenthesisContext context)
        //{
        //    object obj = Visit(context.expression());
        //    return obj;
        //}

        //public override object VisitMultiplyDivide(WSParser.MultiplyDivideContext context)
        //{
        //    double left = Convert.ToDouble(Visit(context.expression(0)));
        //    double right = Convert.ToDouble(Visit(context.expression(1)));

        //    object obj = new object();
        //    if (context.operate.Type == WSParser.MUL)
        //    {
        //        obj = left * right;
        //    }
        //    else if (context.operate.Type == WSParser.DIV)
        //    {
        //        if (right == 0)
        //        {
        //            throw new Exception("Cannot divide by zero.");
        //        }
        //        obj = left / right;
        //    }

        //    return obj;
        //}

        //public override object VisitAddSubtraction(WSParser.AddSubtractionContext context)
        //{
        //    double left = Convert.ToDouble(Visit(context.expression(0)));
        //    double right = Convert.ToDouble(Visit(context.expression(1)));

        //    object obj = new object();
        //    if (context.operate.Type == WSParser.ADD)
        //    {
        //        obj = left + right;
        //    }
        //    else if (context.operate.Type == WSParser.SUB)
        //    {
        //        obj = left - right;
        //    }

        //    return obj;
        //}

        //public override object VisitNumberLiteral(WSParser.NumberLiteralContext context)
        //{
        //    object obj = context.GetText();
        //    return obj;
        //}
    }
}
