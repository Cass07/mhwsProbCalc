using System.Windows.Forms;

namespace mhwsProbCalc
{
    partial class ItemEntryForm
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
            this.Text = "항목 입력";
            this.Size = new System.Drawing.Size(300, 200);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblName = new Label();
            lblName.Text = "이름:";
            lblName.Location = new System.Drawing.Point(20, 20);
            lblName.Size = new System.Drawing.Size(80, 20);
            this.Controls.Add(lblName);

            txtName = new TextBox();
            txtName.Location = new System.Drawing.Point(120, 20);
            txtName.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(txtName);

            Label lblCount = new Label();
            lblCount.Text = "개수:";
            lblCount.Location = new System.Drawing.Point(20, 50);
            lblCount.Size = new System.Drawing.Size(80, 20);
            this.Controls.Add(lblCount);

            numCount = new NumericUpDown();
            numCount.Location = new System.Drawing.Point(120, 50);
            numCount.Size = new System.Drawing.Size(80, 20);
            numCount.Minimum = 1;
            numCount.Maximum = 100;
            numCount.Value = 1;
            this.Controls.Add(numCount);

            Label lblWeight = new Label();
            lblWeight.Text = "가중치:";
            lblWeight.Location = new System.Drawing.Point(20, 80);
            lblWeight.Size = new System.Drawing.Size(80, 20);
            this.Controls.Add(lblWeight);

            numWeight = new NumericUpDown();
            numWeight.Location = new System.Drawing.Point(120, 80);
            numWeight.Size = new System.Drawing.Size(80, 20);
            numWeight.Minimum = 1;
            numWeight.Maximum = 1000;
            numWeight.Value = 1;
            this.Controls.Add(numWeight);

            Button btnOK = new Button();
            btnOK.Text = "확인";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new System.Drawing.Point(50, 120);
            btnOK.Size = new System.Drawing.Size(80, 30);
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);

            Button btnCancel = new Button();
            btnCancel.Text = "취소";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new System.Drawing.Point(150, 120);
            btnCancel.Size = new System.Drawing.Size(80, 30);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        #endregion
    }
}