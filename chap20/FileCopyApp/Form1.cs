using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCopyApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFindSrc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtSource.Text = dialog.FileName;
            }
        }

        private void btnFindTrg_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txtTarget.Text = dialog.FileName;
            }
        }

        private async void btnAsyncCopy_Click(object sender, EventArgs e)
        {
            long totalCopied = await CopyAsync(txtSource.Text, txtTarget.Text);
            MessageBox.Show($"{totalCopied}로 복사했습니다", "비동기 복사 완료");
        }

        private void btnSyncCopy_Click(object sender, EventArgs e)
        {
            //동기 파일 복사
            long totalCopied = CopySync(txtSource.Text, txtTarget.Text);
            MessageBox.Show($"{totalCopied}로 복사했습니다", "동기 복사 완료");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("취소");
        }

        private async Task<long> CopyAsync(string srcPath, string trgPath)
        {
            btnSyncCopy.Enabled = false;   //비동기 버튼 비활성화
            long totalCopied = 0;           //전부 복사했는지 확인

            //존재하는 파일
            using (FileStream srcStream = new FileStream(srcPath, FileMode.Open))
            {
                //새로 설정
                using (FileStream trgStream = new FileStream(trgPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024];  //1024(1KB) * 1024 = 1MB
                    int nRead = 0;

                    while ((nRead = srcStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        await trgStream.WriteAsync(buffer, 0, nRead);  //복사
                        totalCopied += nRead;

                        //프로그레스바에 복사 상태 진행표시
                        pbCopy.Value = (int)((totalCopied / srcStream.Length) * 100);
                    }
                }
            }
            //copy 끝나면
            btnSyncCopy.Enabled = true;
            return totalCopied;
        }

        private long CopySync(string srcPath, string trgPath)
        {
            btnAsyncCopy.Enabled = false;   //비동기 버튼 비활성화
            long totalCopied = 0;           //전부 복사했는지 확인

            //존재하는 파일
            using (FileStream srcStream = new FileStream(srcPath, FileMode.Open))
            {
                //새로 설정
                using (FileStream trgStream = new FileStream(trgPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024 * 1024];  //1024(1KB) * 1024 = 1MB
                    int nRead = 0;

                    while((nRead = srcStream.Read(buffer, 0, buffer.Length)) != 0){
                        trgStream.Write(buffer, 0, nRead);  //복사
                        totalCopied += nRead;

                        //프로그레스바에 복사 상태 진행표시
                        pbCopy.Value = (int)((totalCopied / srcStream.Length) * 100);
                    }
                }
            }
            //copy 끝나면
            btnAsyncCopy.Enabled = true;
            return totalCopied;
        }
    }
}
