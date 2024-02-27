namespace Notepad
{
    partial class NotepadForm
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
            this.menuStripNotepad = new System.Windows.Forms.MenuStrip();
            this.statusStripNotepad = new System.Windows.Forms.StatusStrip();
            this.textBox = new System.Windows.Forms.TextBox();
            this.timerSpeed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // menuStripNotepad
            // 
            this.menuStripNotepad.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripNotepad.Location = new System.Drawing.Point(0, 0);
            this.menuStripNotepad.Name = "menuStripNotepad";
            this.menuStripNotepad.Size = new System.Drawing.Size(800, 24);
            this.menuStripNotepad.TabIndex = 0;
            // 
            // statusStripNotepad
            // 
            this.statusStripNotepad.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripNotepad.Location = new System.Drawing.Point(0, 428);
            this.statusStripNotepad.Name = "statusStripNotepad";
            this.statusStripNotepad.Size = new System.Drawing.Size(800, 22);
            this.statusStripNotepad.TabIndex = 1;
            this.statusStripNotepad.Text = "statusStrip1";
            // 
            // textBox
            // 
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(0, 24);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(800, 404);
            this.textBox.TabIndex = 2;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // timerSpeed
            // 
            this.timerSpeed.Enabled = true;
            this.timerSpeed.Interval = 3000;
            this.timerSpeed.Tick += new System.EventHandler(this.timerSpeed_Tick);
            // 
            // NotepadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.statusStripNotepad);
            this.Controls.Add(this.menuStripNotepad);
            this.MainMenuStrip = this.menuStripNotepad;
            this.Name = "NotepadForm";
            this.Text = "Блокнот";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripNotepad;
        private System.Windows.Forms.StatusStrip statusStripNotepad;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Timer timerSpeed;
    }
}

