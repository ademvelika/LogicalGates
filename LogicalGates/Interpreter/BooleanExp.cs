using LogicalGates.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterpretorBooleanExpression
{
   public abstract class BooleanExp
    {
      
        public abstract bool Evaluate(Context c);
        public abstract BooleanExp Replace(BooleanExp exp, char c);
        public abstract BooleanExp Copy();
        public abstract string GetStringExp();
        public abstract SimplePoint Paint(Context c);
    }
}
