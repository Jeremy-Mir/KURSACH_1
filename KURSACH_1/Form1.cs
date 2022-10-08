using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KURSACH_1
{
    public partial class Form1 : Form
    {

        double find_C(double f, int m)
        {
            double A1 = 40000;
            double A2 = 35000;
            double A3 = 16000;
            double E1 = 67000;
            double E2 = 68000;
            double E3 = 70000;
            double R = 8.31;
            double C1 = 0.4;
            double C2 = 0.3;
            double T = 300;
            double T0 = 300;
            double Kt = 5000;
            double Q1 = 81000;
            double Q2 = 48600;
            double p = 810;
            double Ct = 1200;
            double Tt = 285;
            double K1;
            double K2;
            double K3;
            double C3 = 0;
            double C5 = 0;
            double C10 = C1;
            double C20 = C2;
            double C30 = 0;
            double C50 = 0;


            for (double t = 0; t < 1800; t++)
            {
                K1 = A1 * Math.Exp(-E1 / (R * T));
                K2 = A2 * Math.Exp(-E2 / (R * T));
                K3 = A3 * Math.Exp(-E3 / (R * T));
                C1 = C10 + (-K2 * C10 * C30 - 3 * K1 * C10 * C20 - 2 * K3 * C10 * C20) ;
                C2 = C20 + (-K1 * C10 * C20 - 4 * K1 * C10 * C20) ;
                C3 = C30 + (K1 * C10 * C20 - K2 * C10 * C30);
                C5 = C50 + (K2 * C10 * C30) ;
                T = T0 + ((-Kt * f * (T0 - Tt)) + K1 * C10 * C20 * Q1 * m / p + K2 * C10 * C30 * Q2 * m / p)/Ct/m ;


                chart1.Series[0].Points.AddXY(t, C1);
                chart2.Series[0].Points.AddXY(t, C2);
                chart3.Series[0].Points.AddXY(t, C3);
                chart4.Series[0].Points.AddXY(t, C5);
                chart5.Series[0].Points.AddXY(t, T);
                C10 = C1;
                C20 = C2;
                C30 = C3;
                C50 = C5;
                T0 = T;

                //Console.WriteLine(Math.Abs(T));
            }
           
            return C5;
        }
        public Form1()
        {
            InitializeComponent();


            double n = 0;
            double nf = 0;
            double nm = 0;
            
            for (double f = 7; f < 12; f +=1)
            {
                for (int m = 2000; m < 3000; m+=10)
                {
                    //Console.WriteLine(find_C(f, m));
                    if(find_C(f, m) > n)
                    {
                        n = find_C(f ,m);
                        nf = f;
                        nm = m;
                       // Console.WriteLine("n = " + n);
                    }

                }
            }
                // find_C(7, 2000);
            Console.WriteLine("n = "+ n);
            Console.WriteLine("nf = " + nf);
            Console.WriteLine("nm = " + nm);

        }
    }
}
