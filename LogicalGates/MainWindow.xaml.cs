using InterpretorBooleanExpression;
using LogicalGates.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;

namespace LogicalGates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Context ct;
        BooleanExp exp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           
            ct = new Context();
            ct.paint = Circuit;
            MyParser.Context = ct;
            //VariableExpression a = new VariableExpression('A');
            //VariableExpression b = new VariableExpression('B');
            //VariableExpression c = new VariableExpression('C');
            //VariableExpression d = new VariableExpression('D');

            //OrExpression orExpression = new OrExpression(a,b);
            //OrExpression orExpression1 = new OrExpression(c,d);
            //ct.Assign(a.name, false);
            //ct.Assign(b.name, false);
            //ct.Assign(c.name, false);
            //ct.Assign(d.name, false);
            //exp = new AndExpression(orExpression, orExpression1);
            //exp.Paint(ct);
            //LogicalExpression.Text = exp.GetStringExp();
            //var result = exp.Evaluate(ct);
            //Circuit.AddLamp();
            //Circuit.SwitchLamp(result);

        }

        public void AssignValue(char name,bool value)
        {
            ct.Assign(name, value);

            var result = exp.Evaluate(ct);
            Circuit.SwitchLamp(result);
            if (result)
            {
                var basePath = System.AppDomain.CurrentDomain.BaseDirectory;
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation =System.IO.Path.Combine(basePath, @"Sound\\sound.wav");
                player.Load();
                player.Play();
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Circuit.Reset();
            string expr = LogicalExpression.Text;
            List<Token> tokens = new List<Token>();
            StringReader reader = new StringReader(expr);

            try
            {
                //Tokenize the expression
                Token t = null;
                do
                {
                    t = new Token(reader);
                    tokens.Add(t);
                } while (t.type != Token.TokenType.EXPR_END);

                //Use a minimal version of the Shunting Yard algorithm to transform the token list to polish notation
                List<Token> polishNotation = MyParser.TransformToPolishNotation(tokens);

                var enumerator = polishNotation.GetEnumerator();
                enumerator.MoveNext();
                exp = MyParser.Make(ref enumerator);

                exp.Paint(ct);
                //LogicalExpression.Text = exp.GetStringExp();
                var result = exp.Evaluate(ct);
                Circuit.AddLamp();
                Circuit.SwitchLamp(result);

            }
            catch(Exception ex)
            {
                MessageBox.Show($"Gabim ne shprehje: {ex.Message}");
            }
        }
    }
}
