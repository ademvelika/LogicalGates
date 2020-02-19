using LogicalGates.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterpretorBooleanExpression
{
    public class AndExpression : BooleanExp
    {

        private BooleanExp _operand1;
        private BooleanExp _operand2;

        public AndExpression(BooleanExp op1,BooleanExp op2)
        {
            _operand1 = op1;
            _operand2 = op2;
        }

        public override BooleanExp Copy()
        {
            throw new NotImplementedException();
        }

        public override bool Evaluate(Context c)
        {
            return _operand2.Evaluate(c) && _operand1.Evaluate(c);
        }

        public override string GetStringExp()
        {
            return "( "+_operand1.GetStringExp() + " and " + _operand2.GetStringExp()+" )";
        }

        public override SimplePoint Paint(Context c)
        {
          var lft=  _operand1.Paint(c);
          var righ= _operand2.Paint(c);
          return  c.paint.DrawAndPort(lft,righ);
        }

        public override BooleanExp Replace(BooleanExp exp, char c)
        {
            throw new NotImplementedException();
        }
    }
}
