using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsingConstrolsApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var FontList = FontFamily.Families;
            foreach(var font in FontList)
            {
                cboFont.Items.Add(font.Name);
            }
        }

        //콤보박스, 체크박스 글자체 변경 메서드
        private void ChangFont()
        {
            //콤보박스 선택 안한상태는 index : -1
            if (cboFont.SelectedIndex < 0) cboFont.Text = "폰트를 선택해주세요.";

            FontStyle style = FontStyle.Regular;
            if (chkBold.Checked) style |= FontStyle.Bold;   //00000001
            if (chkItalic.Checked) style |= FontStyle.Italic;   //00000010
            //00000001 | 00000010 = 00000011 = Bold + Italic

            txtResult.Font = new Font((string)cboFont.SelectedItem, 14, style);
        }
        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangFont();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
            ChangFont();
        }

        private void ChangeGage()
        {

        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangFont();
        }

        private void trbHandle_Scroll(object sender, EventArgs e)
        {
            prbDisplay.Value = trbHandle.Value;
        }

        private void prbDisplay_Click(object sender, EventArgs e)
        {

        }
    }
}
