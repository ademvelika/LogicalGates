using LogicalGates.Interpreter;
using System;

namespace InterpretorBooleanExpression
{
    public class VariableExpression : BooleanExp
    {

      public  char name { get; set; }

        public VariableExpression(char c)
        {
            name = c;
        }
        public override BooleanExp Copy()
        {
            throw new NotImplementedException();
        }

        public override bool Evaluate(Context c)
        {
            return c.LookUp(name);
        }

        public override BooleanExp Replace(BooleanExp exp, char c)
        {
            throw new NotImplementedException();
        }

        public override string GetStringExp()
        {
            return name.ToString();
        }

        public override SimplePoint Paint(Context c)
        {
           return c.paint.DrawVariable(name);
        }
    }
}
