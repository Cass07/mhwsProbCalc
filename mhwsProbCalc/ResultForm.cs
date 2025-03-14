using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mhwsProbCalc
{
    public partial class ResultForm : Form
    {
        private ResultEntry[] results;

        public ResultForm(ResultEntry[] results)
        {
            this.results = results;
            InitializeComponent();
            DisplayResults(results);
        }

        private void DisplayResults(ResultEntry[] results)
        {
            foreach (ResultEntry result in results)
            {
                ListViewItem item = new ListViewItem(result.getName());
                item.SubItems.Add(result.getRate().ToString("P4"));  // 퍼센트 형식으로 표시
                listResults.Items.Add(item);
            }
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (ResultEntry result in results)
            {
                // 옵션: 확률% 형식으로 텍스트 구성
                sb.AppendLine($"{result.getName()}: {result.getRate():P2}");
            }

            if (sb.Length > 0)
            {
                try
                {
                    Clipboard.SetText(sb.ToString());
                    MessageBox.Show("결과가 클립보드에 복사되었습니다.", "복사 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"복사 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
