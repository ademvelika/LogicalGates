using LogicalGates.Interface;
using LogicalGates.Interpreter;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LogicalGates.MyController
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl, IPaint
    {

        private static int VariableY = 10;
        static int PortX = 200;
        static int PortY = 100;
        SimplePoint EndGatePoint;
        Lamp lamp;
        static readonly double SwitchHeight = 50;
        static readonly double SwitchWidth = 50;
        static readonly double LogicGateWidth = 100;
        static readonly double LogicGateHeight = 60;
        static readonly double NotGateSize = 40;
        public Board()
        {
            InitializeComponent();

            lamp = new Lamp();
        }

        public SimplePoint DrawAndPort(SimplePoint leftop, SimplePoint rightop)
        {
            ANDControl andControl = new ANDControl();

            Canvas.SetLeft(andControl, PortX);
            Canvas.SetTop(andControl, PortY);

            CircuitField.Children.Add(andControl);

            DrawConectionLines(leftop, rightop);
            var con = new SimplePoint { X = PortX + LogicGateWidth, Y = PortY + LogicGateHeight / 2 };
            IncrementGatesCordinate();
            return con;
        }

        public SimplePoint DrawNotPort(SimplePoint expPoint)
        {
            NotControl notControl = new NotControl();
            Canvas.SetLeft(notControl,expPoint.X-5);
            Canvas.SetTop(notControl, expPoint.Y-( NotGateSize / 2));

            CircuitField.Children.Add(notControl);

            if (EndGatePoint != null)
            {
                EndGatePoint.X += notControl.Width;
            }
            
            return new SimplePoint { X = expPoint.X + notControl.Width, Y = expPoint.Y };

        }

        public SimplePoint DrawORPort(SimplePoint leeftop, SimplePoint rightop)
        {

            ORControl andControl = new ORControl();

            Canvas.SetLeft(andControl, PortX);
            Canvas.SetTop(andControl, PortY);



            CircuitField.Children.Add(andControl);

            DrawConectionLines(leeftop, rightop);


            var con = new SimplePoint { X = PortX + LogicGateWidth, Y = PortY + LogicGateHeight / 2 };
            IncrementGatesCordinate();
            return con;
        }

        public SimplePoint DrawVariable(char name)
        {
            Switch sw = new Switch(name);



            Canvas.SetLeft(sw, 10);
            Canvas.SetTop(sw, VariableY);
            var x1 = 10 + SwitchWidth;
            var y1 = VariableY + SwitchHeight / 2;
            SimplePoint p = new SimplePoint { X = x1, Y = y1 };
            VariableY += (int)sw.Height + 20;
            CircuitField.Children.Add(sw);

            return p;
        }

        void DrawConectionLines(SimplePoint leftop, SimplePoint rightop)
        {

            EndGatePoint = new SimplePoint { X = PortX, Y = PortY };

            var x2Input = PortX + 7;
            var y2Input = PortY + 20;
            var y22Input = PortY + 40;

            Polyline leftPolyline = new Polyline();
            leftPolyline.Stroke = Brushes.OrangeRed;
            PointCollection leftpoints = new PointCollection();


            leftpoints.Add(new Point { X = leftop.X - 2, Y = leftop.Y });
            leftpoints.Add(new Point { X = (x2Input + leftop.X) / 2.2, Y = leftop.Y });
            leftpoints.Add(new Point { X = (x2Input + leftop.X) / 2.2, Y = y2Input });
            leftpoints.Add(new Point { X = x2Input, Y = y2Input });
            leftPolyline.Points = leftpoints;



            Polyline rightPolyline = new Polyline();
            rightPolyline.Stroke = Brushes.OrangeRed;
            PointCollection rightpoints = new PointCollection();


            rightpoints.Add(new Point { X = rightop.X, Y = rightop.Y });
            rightpoints.Add(new Point { X = (x2Input + rightop.X) / 2.2 - 5, Y = rightop.Y });
            rightpoints.Add(new Point { X = (x2Input + rightop.X) / 2.2 - 5, Y = y22Input });
            rightpoints.Add(new Point { X = x2Input, Y = y22Input });
            rightPolyline.Points = rightpoints;





            CircuitField.Children.Add(leftPolyline);

            CircuitField.Children.Add(rightPolyline);
        }
        void IncrementGatesCordinate()
        {
            PortX += 250;
            PortY += 100;
        }

        public void AddLamp()
        {
            Canvas.SetLeft(lamp, EndGatePoint.X + LogicGateWidth - 10);
            Canvas.SetTop(lamp, EndGatePoint.Y - LogicGateHeight / 2);
            CircuitField.Children.Add(lamp);
        }
        public void SwitchLamp(bool state)
        {
            lamp.Swich(state);

        }
        public void Reset()
        {
            VariableY = 10;
            PortX = 200;
            PortY = 100;
            CircuitField.Children.Clear();
        
        }
    }
}
