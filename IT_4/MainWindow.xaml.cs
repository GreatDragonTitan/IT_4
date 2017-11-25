namespace IT_4
{
    using System;
    using System.Windows;
    using System.Windows.Media;

    public partial class MainWindow : Window
    {
        string t;
        StreamGeometry sg;
        double xadd = 50.0;
        double yadd = -10.0;
        public MainWindow()
        {
            InitializeComponent();

            sg = new StreamGeometry();

            var ox = new StreamGeometry();
            using (StreamGeometryContext ctx = ox.Open())
            {
                ctx.BeginFigure(new Point(xadd, yadd + CanvasArea.Height), true, false);
                
                ctx.LineTo(new Point(xadd + 300.0, yadd + CanvasArea.Height), true, false);

            }

            var oy = new StreamGeometry();
            using (StreamGeometryContext ctx = oy.Open())
            {
                ctx.BeginFigure(new Point(xadd, yadd + CanvasArea.Height), true, false);

                ctx.LineTo(new Point(xadd, yadd + CanvasArea.Height - 300.0), true, false);

            }

            using (StreamGeometryContext ctx = sg.Open())
            {
                ctx.BeginFigure(new Point(xadd +200.0/5.0 ,yadd + CanvasArea.Height- Func(200.0/100.0)), true, false );
                for(int i=200;i<700;++i)
                {
                    ctx.LineTo(new Point(xadd+i/5.0,yadd + CanvasArea.Height - Func(i/100.0)), true , true );
                }
                
            }
            GraphiPath.Data = sg;
            YPath.Data = oy;
            XPath.Data = ox;

        
            

            t = F(4.0).ToString();
            te.Text += t;
        }
        public double F(double x)
        {
            var xar = new double[]
            {
                3.2,
                3.6,
                5.8,
                5.9,
                6.2
            };
            var yar = new double[]
            {
                5.3,
                6.0,
                2.4,
                -1.0,
                -3.2
            };
            
            var an = new double[5];
            an[0] = 0;
            an[1] = 0;
            an[2] = 0;
            an[3] = 0;
            an[4] = 0;

            //x^4
            for (int i = 0; i < 5; ++i)
            {
                double s = yar[i];
                for (int j = 0; j < 5; ++j)
                {
                    if (i != j)
                    {
                        s /= (xar[i] - xar[j]);
                    }
                }
                an[0] += s;
            }

            //x^0
           
            for (int i = 0; i < 5; ++i)
            {
                double s = yar[i];
                for (int j = 0; j < 5; ++j)
                {
                    if (i != j)
                    {
                        s *= (  - xar[j]) / (xar[i] - xar[j]);
                    }
                }
                an[4] += s;
            }

            //x^3
            for (int i = 0; i < 5; ++i)
            {
                double s = yar[i];
                for (int j = 0; j < 5; ++j)
                {
                    if (i != j)
                    {
                        s /= (xar[i] - xar[j]);
                    }
                }
                double os = 0.0;
                for (int j = 0; j < 5; ++j)
                {
                    if (i != j)
                    {
                        os += (-xar[j]);
                    }
                }
                an[1] += os * s;
            }

            //x^2
            for (int i = 0; i < 5; ++i)
            {
                double s = yar[i];
                for (int j = 0; j < 5; ++j)
                {
                    if (i != j)
                    {
                        s /= (xar[i] - xar[j]);
                    }
                }
                double os = 0.0;
                for (int j = 0; j < 4; ++j)
                {
                    for(int k=j+1;k<5;++k)
                    {
                        if(j!=i && k!=i)
                        {
                            os += (xar[j] * xar[k]);
                        }
                    }
                }
                an[2] += s*os;
            }

            //x^1
            an[3] = (5.3 - an[4] - an[2] * Math.Pow(3.2, 2.0) - an[1] * Math.Pow(3.2, 3.0) - an[0]*Math.Pow(3.2,4.0))/(3.2);



            ter.Text += "x^4 * " + an[0].ToString() + " + x^3 * " + an[1].ToString() + " + x^2 * " + an[2].ToString() + " + x * " + an[3].ToString() + " + " + an[4].ToString();


            double answer = 0;
            answer = an[0] * Math.Pow(x, 4.0) + an[1] * Math.Pow(x, 3.0) + an[2] * Math.Pow(x, 2.0) + an[3]*x +an[4];
            return answer;
        }

        public double Func(double x)
        {
            return  11.9273842099928 * Math.Pow(x, 4.0) - 225.385755548797 * Math.Pow(x, 3.0) + 1552.78605452517 * Math.Pow(x, 2.0) - 4613.4658710854 * x + 5002.62514442076;
        }
    }
}
