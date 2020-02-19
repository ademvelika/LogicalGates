using LogicalGates.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterpretorBooleanExpression
{
    public class NotExpression : BooleanExp
    {
        BooleanExp exp;
        public NotExpression(BooleanExp exp)
        {
            this.exp = exp;
        }
        public override BooleanExp Copy()
        {
            throw new NotImplementedException();
        }

        public override bool Evaluate(Context c)
        {
            return !exp.Evaluate(c);
        }

        public override string GetStringExp()
        {
            return "not " + exp.GetStringExp();
        }

        public override SimplePoint Paint(Context c)
        {
            var point = exp.Paint(c);
            var point2 = c.paint.DrawNotPort(point);
            return point;
        }

        public override BooleanExp Replace(BooleanExp exp, char c)
        {
            throw new NotImplementedException();
        }
    }
}
