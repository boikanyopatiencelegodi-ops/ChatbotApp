namespace ChatbotApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ChatInput = new RichTextBox();
            ChatInput2 = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // ChatInput
            // 
            ChatInput.Location = new Point(12, 12);
            ChatInput.Name = "ChatInput";
            ChatInput.Size = new Size(776, 299);
            ChatInput.TabIndex = 0;
            ChatInput.Text = "";
            // 
            // ChatInput2
            // 
            ChatInput2.Location = new Point(69, 338);
            ChatInput2.Name = "ChatInput2";
            ChatInput2.Size = new Size(644, 23);
            ChatInput2.TabIndex = 1;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(317, 396);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(124, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSend);
            Controls.Add(ChatInput2);
            Controls.Add(ChatInput);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox ChatInput;
        private TextBox ChatInput2;
        private Button btnSend;
    }
}
