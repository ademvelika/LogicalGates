using InterpretorBooleanExpression;
using LogicalGates.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateSyntaxTree()
        {

            string expr = @"(A&B)";
            List<Token> tokens = new List<Token>();
            StringReader reader = new StringReader(expr);

            //Tokenize the expression
            Token t = null;
            do
            {
                t = new Token(reader);
                tokens.Add(t);
            } while (t.type != Token.TokenType.EXPR_END);

            //Use a minimal version of the Shunting Yard algorithm to transform the token list to polish notation
            List<Token> polishNotation =MyParser.TransformToPolishNotation(tokens);

            var enumerator = polishNotation.GetEnumerator();
            enumerator.MoveNext();
            BooleanExp root = MyParser.Make(ref enumerator);
            var str = root.GetStringExp();
        }
    }
}
