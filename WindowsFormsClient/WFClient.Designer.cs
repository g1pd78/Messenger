
namespace WindowsFormsClient
{
    partial class WFClient
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
            this.components = new System.ComponentModel.Container();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.MessageLB = new System.Windows.Forms.ListBox();
            this.SendB = new System.Windows.Forms.Button();
            this.MessageTB = new System.Windows.Forms.TextBox();
            this.UsernameL = new System.Windows.Forms.Label();
            this.MessageL = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UsernameTB
            // 
            this.UsernameTB.Location = new System.Drawing.Point(85, 361);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(133, 20);
            this.UsernameTB.TabIndex = 0;
            // 
            // MessageLB
            // 
            this.MessageLB.FormattingEnabled = true;
            this.MessageLB.Location = new System.Drawing.Point(24, 18);
            this.MessageLB.Name = "MessageLB";
            this.MessageLB.Size = new System.Drawing.Size(764, 329);
            this.MessageLB.TabIndex = 1;
            // 
            // SendB
            // 
            this.SendB.Location = new System.Drawing.Point(701, 410);
            this.SendB.Name = "SendB";
            this.SendB.Size = new System.Drawing.Size(75, 23);
            this.SendB.TabIndex = 2;
            this.SendB.Text = "Send";
            this.SendB.UseVisualStyleBackColor = true;
            this.SendB.Click += new System.EventHandler(this.SendB_Click);
            // 
            // MessageTB
            // 
            this.MessageTB.Location = new System.Drawing.Point(24, 412);
            this.MessageTB.Name = "MessageTB";
            this.MessageTB.Size = new System.Drawing.Size(637, 20);
            this.MessageTB.TabIndex = 3;
            // 
            // UsernameL
            // 
            this.UsernameL.AutoSize = true;
            this.UsernameL.Location = new System.Drawing.Point(21, 361);
            this.UsernameL.Name = "UsernameL";
            this.UsernameL.Size = new System.Drawing.Size(58, 13);
            this.UsernameL.TabIndex = 4;
            this.UsernameL.Text = "Username:";
            // 
            // MessageL
            // 
            this.MessageL.AutoSize = true;
            this.MessageL.Location = new System.Drawing.Point(21, 386);
            this.MessageL.Name = "MessageL";
            this.MessageL.Size = new System.Drawing.Size(53, 13);
            this.MessageL.TabIndex = 5;
            this.MessageL.Text = "Message:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // WFClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MessageL);
            this.Controls.Add(this.UsernameL);
            this.Controls.Add(this.MessageTB);
            this.Controls.Add(this.SendB);
            this.Controls.Add(this.MessageLB);
            this.Controls.Add(this.UsernameTB);
            this.Name = "WFClient";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.ListBox MessageLB;
        private System.Windows.Forms.Button SendB;
        private System.Windows.Forms.TextBox MessageTB;
        private System.Windows.Forms.Label UsernameL;
        private System.Windows.Forms.Label MessageL;
        private System.Windows.Forms.Timer timer1;
    }
}

