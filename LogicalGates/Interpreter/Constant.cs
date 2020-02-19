using LogicalGates.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterpretorBooleanExpression
{
    public class Constant : BooleanExp
    {

        bool value;

        public Constant(bool value)
        {
            this.value = value;
        }
        public override BooleanExp Copy()
        {
            throw new NotImplementedException();
        }

        public override bool Evaluate(Context c)
        {
            return value;
        }

        public override string GetStringExp()
        {
            return value.ToString();
        }

        public override SimplePoint Paint(Context c)
        {
            throw new NotImplementedException();
        }

        public override BooleanExp Replace(BooleanExp exp, char c)
        {
            throw new NotImplementedException();
        }
    }
}
