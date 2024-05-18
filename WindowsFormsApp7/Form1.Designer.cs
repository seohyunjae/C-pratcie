namespace WindowsFormsApp7
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nNumber1 = new System.Windows.Forms.NumericUpDown();
            this.nNumber2 = new System.Windows.Forms.NumericUpDown();
            this.btnifResult = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnswitchResult = new System.Windows.Forms.Button();
            this.strResult = new System.Windows.Forms.Label();
            this.lblswitchrResult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nNumber1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumber2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(186, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // nNumber1
            // 
            this.nNumber1.Location = new System.Drawing.Point(136, 101);
            this.nNumber1.Name = "nNumber1";
            this.nNumber1.Size = new System.Drawing.Size(120, 21);
            this.nNumber1.TabIndex = 2;
            // 
            // nNumber2
            // 
            this.nNumber2.Location = new System.Drawing.Point(275, 101);
            this.nNumber2.Name = "nNumber2";
            this.nNumber2.Size = new System.Drawing.Size(120, 21);
            this.nNumber2.TabIndex = 3;
            // 
            // btnifResult
            // 
            this.btnifResult.Location = new System.Drawing.Point(474, 101);
            this.btnifResult.Name = "btnifResult";
            this.btnifResult.Size = new System.Drawing.Size(122, 21);
            this.btnifResult.TabIndex = 4;
            this.btnifResult.Text = "Number 비교";
            this.btnifResult.UseVisualStyleBackColor = true;
            this.btnifResult.Click += new System.EventHandler(this.btnifResult_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "월",
            "화",
            "수",
            "목",
            "금",
            "토",
            "일"});
            this.comboBox1.Location = new System.Drawing.Point(292, 232);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.Text = "월";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "요일선택";
            // 
            // btnswitchResult
            // 
            this.btnswitchResult.Location = new System.Drawing.Point(456, 241);
            this.btnswitchResult.Name = "btnswitchResult";
            this.btnswitchResult.Size = new System.Drawing.Size(122, 21);
            this.btnswitchResult.TabIndex = 7;
            this.btnswitchResult.Text = "선택요일확인";
            this.btnswitchResult.UseVisualStyleBackColor = true;
            // 
            // strResult
            // 
            this.strResult.AutoSize = true;
            this.strResult.Location = new System.Drawing.Point(290, 150);
            this.strResult.Name = "strResult";
            this.strResult.Size = new System.Drawing.Size(11, 12);
            this.strResult.TabIndex = 8;
            this.strResult.Text = "-";
            // 
            // lblswitchrResult
            // 
            this.lblswitchrResult.AutoSize = true;
            this.lblswitchrResult.Location = new System.Drawing.Point(290, 298);
            this.lblswitchrResult.Name = "lblswitchrResult";
            this.lblswitchrResult.Size = new System.Drawing.Size(11, 12);
            this.lblswitchrResult.TabIndex = 9;
            this.lblswitchrResult.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblswitchrResult);
            this.Controls.Add(this.strResult);
            this.Controls.Add(this.btnswitchResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnifResult);
            this.Controls.Add(this.nNumber2);
            this.Controls.Add(this.nNumber1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nNumber1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nNumber2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nNumber1;
        private System.Windows.Forms.NumericUpDown nNumber2;
        private System.Windows.Forms.Button btnifResult;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnswitchResult;
        private System.Windows.Forms.Label strResult;
        private System.Windows.Forms.Label lblswitchrResult;
    }
}

