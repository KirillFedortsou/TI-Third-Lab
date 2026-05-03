namespace TIThird
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblQ = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblB = new System.Windows.Forms.Label();
            this.txtP = new System.Windows.Forms.TextBox();
            this.txtQ = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnLoadEncrypted = new System.Windows.Forms.Button();
            this.lblParamHints = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQ
            // 
            this.lblQ.AutoSize = true;
            this.lblQ.Font = new System.Drawing.Font("Hack", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQ.Location = new System.Drawing.Point(183, 4);
            this.lblQ.Name = "lblQ";
            this.lblQ.Size = new System.Drawing.Size(21, 21);
            this.lblQ.TabIndex = 0;
            this.lblQ.Text = "q";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Font = new System.Drawing.Font("Hack", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblP.Location = new System.Drawing.Point(8, 4);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(21, 21);
            this.lblP.TabIndex = 1;
            this.lblP.Text = "p";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Font = new System.Drawing.Font("Hack", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblB.Location = new System.Drawing.Point(356, 8);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(21, 21);
            this.lblB.TabIndex = 2;
            this.lblB.Text = "b";
            // 
            // txtP
            // 
            this.txtP.Font = new System.Drawing.Font("Hack", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtP.Location = new System.Drawing.Point(12, 35);
            this.txtP.Name = "txtP";
            this.txtP.Size = new System.Drawing.Size(106, 23);
            this.txtP.TabIndex = 5;
            this.txtP.TextChanged += new System.EventHandler(this.txtP_TextChanged);
            // 
            // txtQ
            // 
            this.txtQ.Font = new System.Drawing.Font("Hack", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtQ.Location = new System.Drawing.Point(187, 35);
            this.txtQ.Name = "txtQ";
            this.txtQ.Size = new System.Drawing.Size(100, 23);
            this.txtQ.TabIndex = 6;
            this.txtQ.TextChanged += new System.EventHandler(this.txtQ_TextChanged);
            // 
            // txtB
            // 
            this.txtB.Font = new System.Drawing.Font("Hack", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtB.Location = new System.Drawing.Point(360, 35);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 23);
            this.txtB.TabIndex = 7;
            this.txtB.TextChanged += new System.EventHandler(this.txtB_TextChanged);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(5, 391);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResult.Size = new System.Drawing.Size(717, 295);
            this.txtResult.TabIndex = 8;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSelectFile.Font = new System.Drawing.Font("Hack", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectFile.Location = new System.Drawing.Point(7, 13);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(223, 62);
            this.btnSelectFile.TabIndex = 9;
            this.btnSelectFile.Text = "💾 Выбрать файл";
            this.btnSelectFile.UseVisualStyleBackColor = false;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnLoadEncrypted
            // 
            this.btnLoadEncrypted.Font = new System.Drawing.Font("Hack", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoadEncrypted.Location = new System.Drawing.Point(7, 83);
            this.btnLoadEncrypted.Name = "btnLoadEncrypted";
            this.btnLoadEncrypted.Size = new System.Drawing.Size(223, 62);
            this.btnLoadEncrypted.TabIndex = 12;
            this.btnLoadEncrypted.Text = "💾 Загрузить шифротекст";
            this.btnLoadEncrypted.UseVisualStyleBackColor = true;
            this.btnLoadEncrypted.Click += new System.EventHandler(this.btnLoadEncrypted_Click);
            // 
            // lblParamHints
            // 
            this.lblParamHints.AutoSize = true;
            this.lblParamHints.Location = new System.Drawing.Point(9, 84);
            this.lblParamHints.Name = "lblParamHints";
            this.lblParamHints.Size = new System.Drawing.Size(0, 16);
            this.lblParamHints.TabIndex = 13;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(5, 275);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(717, 98);
            this.txtLog.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.lblParamHints);
            this.panel1.Controls.Add(this.txtB);
            this.panel1.Controls.Add(this.txtQ);
            this.panel1.Controls.Add(this.txtP);
            this.panel1.Controls.Add(this.lblB);
            this.panel1.Controls.Add(this.lblP);
            this.panel1.Controls.Add(this.lblQ);
            this.panel1.Location = new System.Drawing.Point(253, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 156);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.btnLoadEncrypted);
            this.panel2.Controls.Add(this.btnSelectFile);
            this.panel2.Location = new System.Drawing.Point(5, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(242, 155);
            this.panel2.TabIndex = 16;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Enabled = false;
            this.btnEncrypt.Font = new System.Drawing.Font("Hack", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEncrypt.Location = new System.Drawing.Point(6, 6);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(250, 71);
            this.btnEncrypt.TabIndex = 10;
            this.btnEncrypt.Text = "🔒 Зашифровать";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Enabled = false;
            this.btnDecrypt.Font = new System.Drawing.Font("Hack", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDecrypt.Location = new System.Drawing.Point(457, 6);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(250, 71);
            this.btnDecrypt.TabIndex = 11;
            this.btnDecrypt.Text = "🔓 Расшифровать";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.btnDecrypt);
            this.panel3.Controls.Add(this.btnEncrypt);
            this.panel3.Location = new System.Drawing.Point(6, 179);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(716, 86);
            this.panel3.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(729, 691);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.txtResult);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Алгоритм Рабина";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQ;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtP;
        private System.Windows.Forms.TextBox txtQ;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnLoadEncrypted;
        private System.Windows.Forms.Label lblParamHints;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Panel panel3;
    }
}

