namespace _33.Title
{
    partial class Title
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Title));
            this.gboxControl = new System.Windows.Forms.GroupBox();
            this.btnSizeCheck = new System.Windows.Forms.Button();
            this.lboxResult = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gboxControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxControl
            // 
            this.gboxControl.Controls.Add(this.label3);
            this.gboxControl.Controls.Add(this.label2);
            this.gboxControl.Controls.Add(this.label1);
            this.gboxControl.Controls.Add(this.button4);
            this.gboxControl.Controls.Add(this.button3);
            this.gboxControl.Controls.Add(this.button2);
            this.gboxControl.Controls.Add(this.button1);
            this.gboxControl.Location = new System.Drawing.Point(11, 8);
            this.gboxControl.Name = "gboxControl";
            this.gboxControl.Size = new System.Drawing.Size(543, 214);
            this.gboxControl.TabIndex = 0;
            this.gboxControl.TabStop = false;
            this.gboxControl.Text = "ControlBox";
            // 
            // btnSizeCheck
            // 
            this.btnSizeCheck.Location = new System.Drawing.Point(402, 234);
            this.btnSizeCheck.Name = "btnSizeCheck";
            this.btnSizeCheck.Size = new System.Drawing.Size(151, 31);
            this.btnSizeCheck.TabIndex = 1;
            this.btnSizeCheck.Text = "Control Size 확인";
            this.btnSizeCheck.UseVisualStyleBackColor = true;
            // 
            // lboxResult
            // 
            this.lboxResult.FormattingEnabled = true;
            this.lboxResult.ItemHeight = 12;
            this.lboxResult.Location = new System.Drawing.Point(11, 278);
            this.lboxResult.Name = "lboxResult";
            this.lboxResult.Size = new System.Drawing.Size(541, 136);
            this.lboxResult.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 48);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(46, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 81);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(191, 58);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(349, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 61);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(171, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 57);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(299, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(433, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 119);
            this.label3.TabIndex = 6;
            this.label3.Text = "label3";
            // 
            // Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 432);
            this.Controls.Add(this.lboxResult);
            this.Controls.Add(this.btnSizeCheck);
            this.Controls.Add(this.gboxControl);
            this.Name = "Title";
            this.Text = "Title";
            this.gboxControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxControl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSizeCheck;
        private System.Windows.Forms.ListBox lboxResult;
    }
}

