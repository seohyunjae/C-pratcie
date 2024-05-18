namespace WindowsFormsApp8
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
            this.lblwhileResult = new System.Windows.Forms.Label();
            this.btnwhileResult = new System.Windows.Forms.Button();
            this.IboxwhileResult = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btndowhileResult = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldowhile = new System.Windows.Forms.Label();
            this.tboxnumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblwhileResult
            // 
            this.lblwhileResult.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblwhileResult.ForeColor = System.Drawing.SystemColors.Control;
            this.lblwhileResult.Location = new System.Drawing.Point(58, 44);
            this.lblwhileResult.Name = "lblwhileResult";
            this.lblwhileResult.Size = new System.Drawing.Size(300, 63);
            this.lblwhileResult.TabIndex = 0;
            this.lblwhileResult.Text = "0, 0, 0, 0, 0, 0";
            this.lblwhileResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnwhileResult
            // 
            this.btnwhileResult.Location = new System.Drawing.Point(385, 55);
            this.btnwhileResult.Name = "btnwhileResult";
            this.btnwhileResult.Size = new System.Drawing.Size(75, 52);
            this.btnwhileResult.TabIndex = 1;
            this.btnwhileResult.Text = "로또번호";
            this.btnwhileResult.UseVisualStyleBackColor = true;
            this.btnwhileResult.Click += new System.EventHandler(this.btnwhileResult_Click);
            // 
            // IboxwhileResult
            // 
            this.IboxwhileResult.FormattingEnabled = true;
            this.IboxwhileResult.ItemHeight = 12;
            this.IboxwhileResult.Location = new System.Drawing.Point(95, 129);
            this.IboxwhileResult.Name = "IboxwhileResult";
            this.IboxwhileResult.Size = new System.Drawing.Size(329, 88);
            this.IboxwhileResult.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(100, 251);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 10);
            this.panel1.TabIndex = 3;
            // 
            // btndowhileResult
            // 
            this.btndowhileResult.Location = new System.Drawing.Point(349, 288);
            this.btndowhileResult.Name = "btndowhileResult";
            this.btndowhileResult.Size = new System.Drawing.Size(75, 52);
            this.btndowhileResult.TabIndex = 4;
            this.btndowhileResult.Text = "선택번호";
            this.btndowhileResult.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "1 ~ 100안의 숫자를 입력하세요";
            // 
            // lbldowhile
            // 
            this.lbldowhile.AutoSize = true;
            this.lbldowhile.Location = new System.Drawing.Point(107, 357);
            this.lbldowhile.Name = "lbldowhile";
            this.lbldowhile.Size = new System.Drawing.Size(11, 12);
            this.lbldowhile.TabIndex = 6;
            this.lbldowhile.Text = "-";
            // 
            // tboxnumber
            // 
            this.tboxnumber.Location = new System.Drawing.Point(139, 318);
            this.tboxnumber.Name = "tboxnumber";
            this.tboxnumber.Size = new System.Drawing.Size(100, 21);
            this.tboxnumber.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tboxnumber);
            this.Controls.Add(this.lbldowhile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btndowhileResult);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.IboxwhileResult);
            this.Controls.Add(this.btnwhileResult);
            this.Controls.Add(this.lblwhileResult);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblwhileResult;
        private System.Windows.Forms.Button btnwhileResult;
        private System.Windows.Forms.ListBox IboxwhileResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btndowhileResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldowhile;
        private System.Windows.Forms.TextBox tboxnumber;
    }
}

