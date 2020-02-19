


using LogicalGates;
using LogicalGates.Interface;
using LogicalGates.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterpretorBooleanExpression
{
  public  class Context
    {
        Dictionary<char, bool> keyValuePairs = new Dictionary<char, bool>();

      public  IPaint paint { get; set; }
      
       
        public bool LookUp(char c)
        {
            return keyValuePairs.GetValueOrDefault(c);
        }
        
        public void   Assign(char name,bool value)
        {
            if (keyValuePairs.ContainsKey(name))
            {
                keyValuePairs[name] = value;
            }
            else
            {
                keyValuePairs.Add(name, value);
            }
          
        }
        public void ReAssign(char name,bool value)
        {
            keyValuePairs[name] = value;
        }

      

       
    }
}
