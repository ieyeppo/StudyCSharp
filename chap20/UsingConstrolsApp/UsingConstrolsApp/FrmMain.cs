﻿using System;
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
        Random random = new Random();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lvDummy.Columns.Add("Name");
            lvDummy.Columns.Add("Columns");

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

        private void btnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Modal Form";
            frm.Width = 300;
            frm.Height = 100;
            frm.BackColor = Color.Pink;
            frm.ShowDialog();   //Modal 창 띄우기
        }

        private void btnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Modaless Form";
            frm.Width = 300;
            frm.Height = 300;
            frm.BackColor = Color.HotPink;
            frm.Show();   //Modal 창 띄우기
        }

        private void btnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtResult.Text, "MessageBox Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void TreeToList()
        {
            lvDummy.Items.Clear();
            foreach(TreeNode node in tvDummy.Nodes)
            {
                TreeToList(node);
            }
        }

        private void TreeToList(TreeNode Node)
        {
            lvDummy.Items.Add(
                    new ListViewItem(
                        new string[]
                        { Node.Text, Node.FullPath.Count(f => f == '\\').ToString() }));
            foreach(TreeNode node in Node.Nodes)
            {
                TreeToList(node);
            }
        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            tvDummy.Nodes.Add(random.Next().ToString());
            TreeToList();
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            if(tvDummy.SelectedNode == null)
            {
                MessageBox.Show("선택된 노드가 없습니다.",
                    "TreeView Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tvDummy.SelectedNode.Nodes.Add(random.Next().ToString());
            tvDummy.SelectedNode.Expand();
            TreeToList();
        }
    }
}
