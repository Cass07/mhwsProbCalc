using System.Windows.Forms;

namespace mhwsProbCalc
{
    partial class ResultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listResults = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listResults
            // 
            this.listResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listResults.FullRowSelect = true;
            this.listResults.GridLines = true;
            this.listResults.HideSelection = false;
            this.listResults.Location = new System.Drawing.Point(20, 20);
            this.listResults.Name = "listResults";
            this.listResults.Size = new System.Drawing.Size(360, 220);
            this.listResults.TabIndex = 0;
            this.listResults.UseCompatibleStateImageBehavior = false;
            this.listResults.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "옵션";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "확률";
            this.columnHeader2.Width = 150;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(152, 246);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(97, 30);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "복사";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // ResultForm
            // 
            this.ClientSize = new System.Drawing.Size(398, 308);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.listResults);
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "계산 결과";
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listResults;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Button btnCopy;
    }
}