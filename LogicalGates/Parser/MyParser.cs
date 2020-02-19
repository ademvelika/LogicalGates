using InterpretorBooleanExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicalGates.Parser
{
    public class MyParser
    {
      public  static Context Context;
        public static List<Token> TransformToPolishNotation(List<Token> infixTokenList)
        {
            Queue<Token> outputQueue = new Queue<Token>();
            Stack<Token> stack = new Stack<Token>();

            int index = 0;
            while (infixTokenList.Count > index)
            {
                Token t = infixTokenList[index];

                switch (t.type)
                {
                    case Token.TokenType.LITERAL:
                        outputQueue.Enqueue(t);
                        break;
                    case Token.TokenType.BINARY_OP:
                    case Token.TokenType.UNARY_OP:
                    case Token.TokenType.OPEN_PAREN:
                        stack.Push(t);
                        break;
                    case Token.TokenType.CLOSE_PAREN:
                        while (stack.Peek().type != Token.TokenType.OPEN_PAREN)
                        {
                            outputQueue.Enqueue(stack.Pop());
                        }
                        stack.Pop();
                        if (stack.Count > 0 && stack.Peek().type == Token.TokenType.UNARY_OP)
                        {
                            outputQueue.Enqueue(stack.Pop());
                        }
                        break;
                    default:
                        break;
                }

                ++index;
            }
            while (stack.Count > 0)
            {
                outputQueue.Enqueue(stack.Pop());
            }

            return outputQueue.Reverse().ToList();
        }



        public static BooleanExp Make(ref List<Token>.Enumerator polishNotationTokensEnumerator)
        {
            if (polishNotationTokensEnumerator.Current.type == Token.TokenType.LITERAL)
            {
                BooleanExp lit = new VariableExpression(Char.Parse(polishNotationTokensEnumerator.Current.value));
                Context.Assign(Char.Parse(polishNotationTokensEnumerator.Current.value), false);
                polishNotationTokensEnumerator.MoveNext();
                return lit;
            }
            else
            {
                if (polishNotationTokensEnumerator.Current.value == "NOT")
                {
                    polishNotationTokensEnumerator.MoveNext();
                    BooleanExp operand = Make(ref polishNotationTokensEnumerator);
                    return new NotExpression(operand);
                }
                else if (polishNotationTokensEnumerator.Current.value == "AND")
                {
                    polishNotationTokensEnumerator.MoveNext();
                    BooleanExp left = Make(ref polishNotationTokensEnumerator);
                    BooleanExp right = Make(ref polishNotationTokensEnumerator);
                    return new AndExpression(left, right);


                }
                else if (polishNotationTokensEnumerator.Current.value == "OR")
                {
                    polishNotationTokensEnumerator.MoveNext();
                    BooleanExp left = Make(ref polishNotationTokensEnumerator);
                    BooleanExp right = Make(ref polishNotationTokensEnumerator);
                    return new OrExpression(left, right);
                }
            }
            return null;
        }
    }
}