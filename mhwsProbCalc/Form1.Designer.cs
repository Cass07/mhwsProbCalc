using System.Drawing;
using System.Windows.Forms;

namespace mhwsProbCalc
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblTrialCount = new System.Windows.Forms.Label();
            this.numericTrials = new System.Windows.Forms.NumericUpDown();
            this.btnCalculateDep = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericTrials)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxItems
            // 
            this.listBoxItems.ItemHeight = 12;
            this.listBoxItems.Location = new System.Drawing.Point(20, 20);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(300, 220);
            this.listBoxItems.TabIndex = 2;
            this.listBoxItems.DoubleClick += new System.EventHandler(this.ListBoxItems_DoubleClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 254);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "입력";
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(220, 254);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(100, 30);
            this.btnCalculate.TabIndex = 1;
            this.btnCalculate.Text = "계산";
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculate_Click);
            // 
            // lblTrialCount
            // 
            this.lblTrialCount.Location = new System.Drawing.Point(20, 294);
            this.lblTrialCount.Name = "lblTrialCount";
            this.lblTrialCount.Size = new System.Drawing.Size(80, 20);
            this.lblTrialCount.TabIndex = 3;
            this.lblTrialCount.Text = "뽑는 수:";
            // 
            // numericTrials
            // 
            this.numericTrials.Location = new System.Drawing.Point(100, 294);
            this.numericTrials.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericTrials.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericTrials.Name = "numericTrials";
            this.numericTrials.Size = new System.Drawing.Size(60, 21);
            this.numericTrials.TabIndex = 4;
            this.numericTrials.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCalculateDep
            // 
            this.btnCalculateDep.Location = new System.Drawing.Point(220, 294);
            this.btnCalculateDep.Name = "btnCalculateDep";
            this.btnCalculateDep.Size = new System.Drawing.Size(100, 30);
            this.btnCalculateDep.TabIndex = 5;
            this.btnCalculateDep.Text = "계산2";
            this.btnCalculateDep.Click += new System.EventHandler(this.BtnCalculate2_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(348, 361);
            this.Controls.Add(this.btnCalculateDep);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.lblTrialCount);
            this.Controls.Add(this.numericTrials);
            this.Name = "Form1";
            this.Text = "확률 계산기";
            ((System.ComponentModel.ISupportInitialize)(this.numericTrials)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBoxItems;
        private NumericUpDown numericTrials;
        private Button btnAdd;
        private Button btnCalculate;
        private Label lblTrialCount;
        private Button btnCalculateDep;
    }
}

