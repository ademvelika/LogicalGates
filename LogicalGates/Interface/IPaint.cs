using LogicalGates.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicalGates.Interface
{
  public  interface IPaint 
    {

        SimplePoint DrawAndPort(SimplePoint leftop, SimplePoint rightop);
        SimplePoint DrawORPort(SimplePoint leeftop, SimplePoint rightop);
        SimplePoint DrawNotPort(SimplePoint expPoint);
        public SimplePoint DrawVariable(char name);


    }
}
