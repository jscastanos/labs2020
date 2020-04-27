namespace PillReminderUI
{
    partial class ReminderWindow
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
            this.components = new System.ComponentModel.Container();
            this.allPillsListBox = new System.Windows.Forms.ListBox();
            this.pillsToTakeListBox = new System.Windows.Forms.ListBox();
            this.pillsToTakeLabel = new System.Windows.Forms.Label();
            this.allPillsLabel = new System.Windows.Forms.Label();
            this.takePill = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // allPillsListBox
            // 
            this.allPillsListBox.FormattingEnabled = true;
            this.allPillsListBox.ItemHeight = 29;
            this.allPillsListBox.Location = new System.Drawing.Point(480, 116);
            this.allPillsListBox.Name = "allPillsListBox";
            this.allPillsListBox.Size = new System.Drawing.Size(310, 294);
            this.allPillsListBox.TabIndex = 0;
            // 
            // pillsToTakeListBox
            // 
            this.pillsToTakeListBox.FormattingEnabled = true;
            this.pillsToTakeListBox.ItemHeight = 29;
            this.pillsToTakeListBox.Location = new System.Drawing.Point(59, 116);
            this.pillsToTakeListBox.Name = "pillsToTakeListBox";
            this.pillsToTakeListBox.Size = new System.Drawing.Size(310, 294);
            this.pillsToTakeListBox.TabIndex = 0;
            // 
            // pillsToTakeLabel
            // 
            this.pillsToTakeLabel.AutoSize = true;
            this.pillsToTakeLabel.Location = new System.Drawing.Point(53, 80);
            this.pillsToTakeLabel.Name = "pillsToTakeLabel";
            this.pillsToTakeLabel.Size = new System.Drawing.Size(156, 29);
            this.pillsToTakeLabel.TabIndex = 1;
            this.pillsToTakeLabel.Text = "Pills To Take";
            // 
            // allPillsLabel
            // 
            this.allPillsLabel.AutoSize = true;
            this.allPillsLabel.Location = new System.Drawing.Point(474, 80);
            this.allPillsLabel.Name = "allPillsLabel";
            this.allPillsLabel.Size = new System.Drawing.Size(174, 29);
            this.allPillsLabel.TabIndex = 1;
            this.allPillsLabel.Text = "Medication List";
            // 
            // takePill
            // 
            this.takePill.Location = new System.Drawing.Point(120, 423);
            this.takePill.Name = "takePill";
            this.takePill.Size = new System.Drawing.Size(169, 73);
            this.takePill.TabIndex = 2;
            this.takePill.Text = "Take Pill";
            this.takePill.UseVisualStyleBackColor = true;
            this.takePill.Click += new System.EventHandler(this.TakePill_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // ReminderWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 530);
            this.Controls.Add(this.takePill);
            this.Controls.Add(this.allPillsLabel);
            this.Controls.Add(this.pillsToTakeLabel);
            this.Controls.Add(this.pillsToTakeListBox);
            this.Controls.Add(this.allPillsListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "ReminderWindow";
            this.Text = "Pill Reminder Challenge by Tim Corey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox allPillsListBox;
        private System.Windows.Forms.ListBox pillsToTakeListBox;
        private System.Windows.Forms.Label pillsToTakeLabel;
        private System.Windows.Forms.Label allPillsLabel;
        private System.Windows.Forms.Button takePill;
        private System.Windows.Forms.Timer timer1;
    }
}

