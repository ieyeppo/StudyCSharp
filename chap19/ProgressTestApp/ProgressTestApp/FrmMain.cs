using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressTestApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() => {
                for (int i = 1; i <= 100; i++)
                {
                    label1.Text = $"프로그램 진행률 : {i}%";
                    progressBar1.Value = i;
                    Thread.Sleep(100);
                }
            });

            try
            {
                label1.Text = "프로그램을 시작합니다.";
                Thread.Sleep(2000);
                th.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                th.Join();
                label1.Text = "프로그램을 종료합니다.";
            }
        }
    }
}
