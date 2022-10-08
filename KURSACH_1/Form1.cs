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
        double find_C(double T)
        {
            double A1 = 40000;
            double A2 = 35000;
            double A3 = 16000;
            double E1 = 67000;
            double E2 = 68000;
            double E3 = 70000;
            double R = 8.31;
            double K1 = A1 * Math.Exp(-E1 / (R * T));
            double K2 = A2 * Math.Exp(-E2 / (R * T));
            double K3 = A3 * Math.Exp(-E3 / (R * T));
            double C1 = 0.4;
            double C2 = 0.3;
            double C3;
            double C5 = 0;
            double C10 = C1;
            double C20 = C2;
            double C30 = 0;
            double C50 = 0;


            for (int t = 0; t < 1800; t++)
            {
                C1 = C10 + (-K2 * C10 * C30 - 3 * K1 * C10 * C20 - 2 * K3 * C10 * C20) * t;
                C2 = C20 + (-K1 * C10 * C20 - 4 * K1 * C10 * C20) * t;
                C3 = C30 + (K1 * C10 * C20 - K2 * C10 * C30) * t;
                C5 = C50 + (K2 * C10 * C30) * t;
               
                chart1.Series[0].Points.AddXY(t, C1);
                chart2.Series[0].Points.AddXY(t, C2 );
                chart3.Series[0].Points.AddXY(t, C3);
                chart4.Series[0].Points.AddXY(t, C5 );
                //Console.WriteLine(Math.Abs(C5));

                C10 = C1;
                C20 = C2;
                C30 = C3;
                C50 = C5;


            }
            return C5;
        }
        public Form1()
        {
            InitializeComponent();

            Console.WriteLine(find_C(400));
        }
    }
}
