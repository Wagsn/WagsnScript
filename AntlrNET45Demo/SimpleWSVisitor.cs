using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntlrNET45Demo
{
    public class SimpleWSVisitor : WSBaseVisitor<object>
    {
        Dictionary<string, object> memory = new Dictionary<string, object>();

        public override object VisitParenthesis(WSParser.ParenthesisContext context)
        {
            object obj = Visit(context.expression());
            return obj;
        }

        public override object VisitMultiplyDivide(WSParser.MultiplyDivideContext context)
        {
            double left = Convert.ToDouble(Visit(context.expression(0)));
            double right = Convert.ToDouble(Visit(context.expression(1)));

            object obj = new object();
            if (context.operate.Type == WSParser.MUL)
            {
                obj = left * right;
            }
            else if (context.operate.Type == WSParser.DIV)
            {
                if (right == 0)
                {
                    throw new Exception("Cannot divide by zero.");
                }
                obj = left / right;
            }

            return obj;
        }

        public override object VisitAddSubtraction(WSParser.AddSubtractionContext context)
        {
            double left = Convert.ToDouble(Visit(context.expression(0)));
            double right = Convert.ToDouble(Visit(context.expression(1)));

            object obj = new object();
            if (context.operate.Type == WSParser.ADD)
            {
                obj = left + right;
            }
            else if (context.operate.Type == WSParser.SUB)
            {
                obj = left - right;
            }

            return obj;
        }

        public override object VisitNumber(WSParser.NumberContext context)
        {
            object obj = context.GetText();
            return obj;
        }
    }
}
