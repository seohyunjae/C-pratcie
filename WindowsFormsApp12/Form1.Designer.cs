﻿namespace WindowsFormsApp12
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
            this.tboxConfigData = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numData = new System.Windows.Forms.NumericUpDown();
            this.cboxData = new System.Windows.Forms.CheckBox();
            this.tboxData = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnConfigSet = new System.Windows.Forms.Button();
            this.btnConfigRead = new System.Windows.Forms.Button();
            this.SFDialog = new System.Windows.Forms.SaveFileDialog();
            this.OFDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numData)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxConfigData
            // 
            this.tboxConfigData.Enabled = false;
            this.tboxConfigData.Location = new System.Drawing.Point(62, 82);
            this.tboxConfigData.Multiline = true;
            this.tboxConfigData.Name = "tboxConfigData";
            this.tboxConfigData.Size = new System.Drawing.Size(240, 81);
            this.tboxConfigData.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numData);
            this.groupBox1.Controls.Add(this.cboxData);
            this.groupBox1.Controls.Add(this.tboxData);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(62, 162);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // numData
            // 
            this.numData.Location = new System.Drawing.Point(116, 74);
            this.numData.Name = "numData";
            this.numData.Size = new System.Drawing.Size(90, 21);
            this.numData.TabIndex = 7;
            // 
            // cboxData
            // 
            this.cboxData.AutoSize = true;
            this.cboxData.Location = new System.Drawing.Point(106, 39);
            this.cboxData.Name = "cboxData";
            this.cboxData.Size = new System.Drawing.Size(47, 16);
            this.cboxData.TabIndex = 6;
            this.cboxData.Text = "CB1";
            this.cboxData.UseVisualStyleBackColor = true;
            // 
            // tboxData
            // 
            this.tboxData.Location = new System.Drawing.Point(106, 7);
            this.tboxData.Name = "tboxData";
            this.tboxData.Size = new System.Drawing.Size(100, 21);
            this.tboxData.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "3. Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "2. CheckBox:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. Text:";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(62, 33);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 23);
            this.btnLoad.TabIndex = 6;
            this.btnLoad.Text = "Text 읽어오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(193, 33);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(109, 23);
            this.btnsave.TabIndex = 7;
            this.btnsave.Text = "Text 저장하기";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnConfigSet
            // 
            this.btnConfigSet.Location = new System.Drawing.Point(193, 307);
            this.btnConfigSet.Name = "btnConfigSet";
            this.btnConfigSet.Size = new System.Drawing.Size(109, 23);
            this.btnConfigSet.TabIndex = 9;
            this.btnConfigSet.Text = "Text 저장하기";
            this.btnConfigSet.UseVisualStyleBackColor = true;
            this.btnConfigSet.Click += new System.EventHandler(this.btnConfigSet_Click);
            // 
            // btnConfigRead
            // 
            this.btnConfigRead.Location = new System.Drawing.Point(62, 307);
            this.btnConfigRead.Name = "btnConfigRead";
            this.btnConfigRead.Size = new System.Drawing.Size(100, 23);
            this.btnConfigRead.TabIndex = 8;
            this.btnConfigRead.Text = "Config가져오기";
            this.btnConfigRead.UseVisualStyleBackColor = true;
            this.btnConfigRead.Click += new System.EventHandler(this.btnConfigRead_Click);
            // 
            // OFDialog
            // 
            this.OFDialog.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 415);
            this.Controls.Add(this.btnConfigSet);
            this.Controls.Add(this.btnConfigRead);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tboxConfigData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tboxConfigData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numData;
        private System.Windows.Forms.CheckBox cboxData;
        private System.Windows.Forms.TextBox tboxData;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnConfigSet;
        private System.Windows.Forms.Button btnConfigRead;
        private System.Windows.Forms.SaveFileDialog SFDialog;
        private System.Windows.Forms.OpenFileDialog OFDialog;
    }
}

