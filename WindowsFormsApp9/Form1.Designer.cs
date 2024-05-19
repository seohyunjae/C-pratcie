namespace WindowsFormsApp9
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
            this.pboxSun = new System.Windows.Forms.PictureBox();
            this.pboxmoon = new System.Windows.Forms.PictureBox();
            this.pboxstar = new System.Windows.Forms.PictureBox();
            this.pboxNone = new System.Windows.Forms.PictureBox();
            this.rdoButton1 = new System.Windows.Forms.RadioButton();
            this.rdoButton2 = new System.Windows.Forms.RadioButton();
            this.lboxResult2 = new System.Windows.Forms.ListBox();
            this.lboxResult1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxSun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxmoon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxstar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxNone)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "각 플레이어는 돌아가면서 선택을 합니다";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "5회씩 합니다";
            // 
            // pboxSun
            // 
            this.pboxSun.BackColor = System.Drawing.Color.Red;
            this.pboxSun.Location = new System.Drawing.Point(112, 101);
            this.pboxSun.Name = "pboxSun";
            this.pboxSun.Size = new System.Drawing.Size(97, 111);
            this.pboxSun.TabIndex = 2;
            this.pboxSun.TabStop = false;
            this.pboxSun.Click += new System.EventHandler(this.pboxSun_Click);
            // 
            // pboxmoon
            // 
            this.pboxmoon.BackColor = System.Drawing.Color.Yellow;
            this.pboxmoon.Location = new System.Drawing.Point(223, 101);
            this.pboxmoon.Name = "pboxmoon";
            this.pboxmoon.Size = new System.Drawing.Size(97, 111);
            this.pboxmoon.TabIndex = 3;
            this.pboxmoon.TabStop = false;
            this.pboxmoon.Click += new System.EventHandler(this.pboxmoon_Click);
            // 
            // pboxstar
            // 
            this.pboxstar.BackColor = System.Drawing.Color.Blue;
            this.pboxstar.Location = new System.Drawing.Point(351, 101);
            this.pboxstar.Name = "pboxstar";
            this.pboxstar.Size = new System.Drawing.Size(97, 111);
            this.pboxstar.TabIndex = 4;
            this.pboxstar.TabStop = false;
            this.pboxstar.Click += new System.EventHandler(this.pboxstar_Click);
            // 
            // pboxNone
            // 
            this.pboxNone.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pboxNone.Location = new System.Drawing.Point(496, 101);
            this.pboxNone.Name = "pboxNone";
            this.pboxNone.Size = new System.Drawing.Size(97, 111);
            this.pboxNone.TabIndex = 5;
            this.pboxNone.TabStop = false;
            this.pboxNone.Click += new System.EventHandler(this.pboxNone_Click);
            // 
            // rdoButton1
            // 
            this.rdoButton1.AutoSize = true;
            this.rdoButton1.Location = new System.Drawing.Point(122, 268);
            this.rdoButton1.Name = "rdoButton1";
            this.rdoButton1.Size = new System.Drawing.Size(65, 16);
            this.rdoButton1.TabIndex = 6;
            this.rdoButton1.TabStop = true;
            this.rdoButton1.Text = "Player1";
            this.rdoButton1.UseVisualStyleBackColor = true;
            // 
            // rdoButton2
            // 
            this.rdoButton2.AutoSize = true;
            this.rdoButton2.Location = new System.Drawing.Point(293, 268);
            this.rdoButton2.Name = "rdoButton2";
            this.rdoButton2.Size = new System.Drawing.Size(65, 16);
            this.rdoButton2.TabIndex = 7;
            this.rdoButton2.TabStop = true;
            this.rdoButton2.Text = "Player2";
            this.rdoButton2.UseVisualStyleBackColor = true;
            // 
            // lboxResult2
            // 
            this.lboxResult2.FormattingEnabled = true;
            this.lboxResult2.ItemHeight = 12;
            this.lboxResult2.Location = new System.Drawing.Point(293, 308);
            this.lboxResult2.Name = "lboxResult2";
            this.lboxResult2.Size = new System.Drawing.Size(120, 88);
            this.lboxResult2.TabIndex = 8;
            // 
            // lboxResult1
            // 
            this.lboxResult1.FormattingEnabled = true;
            this.lboxResult1.ItemHeight = 12;
            this.lboxResult1.Location = new System.Drawing.Point(122, 308);
            this.lboxResult1.Name = "lboxResult1";
            this.lboxResult1.Size = new System.Drawing.Size(120, 88);
            this.lboxResult1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lboxResult1);
            this.Controls.Add(this.lboxResult2);
            this.Controls.Add(this.rdoButton2);
            this.Controls.Add(this.rdoButton1);
            this.Controls.Add(this.pboxNone);
            this.Controls.Add(this.pboxstar);
            this.Controls.Add(this.pboxmoon);
            this.Controls.Add(this.pboxSun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pboxSun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxmoon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxstar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxNone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pboxSun;
        private System.Windows.Forms.PictureBox pboxmoon;
        private System.Windows.Forms.PictureBox pboxstar;
        private System.Windows.Forms.PictureBox pboxNone;
        private System.Windows.Forms.RadioButton rdoButton1;
        private System.Windows.Forms.RadioButton rdoButton2;
        private System.Windows.Forms.ListBox lboxResult2;
        private System.Windows.Forms.ListBox lboxResult1;
    }
}

