namespace PictureCapture
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFullScreenCapture = new System.Windows.Forms.Button();
            this.FakeConsole = new System.Windows.Forms.TextBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPaintOnScreen = new System.Windows.Forms.Button();
            this.btnCapturePart = new System.Windows.Forms.Button();
            this.btnStartCpatureMouse = new System.Windows.Forms.Button();
            this.btnStopCaptureMouse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFullScreenCapture
            // 
            this.btnFullScreenCapture.Location = new System.Drawing.Point(23, 331);
            this.btnFullScreenCapture.Name = "btnFullScreenCapture";
            this.btnFullScreenCapture.Size = new System.Drawing.Size(164, 51);
            this.btnFullScreenCapture.TabIndex = 0;
            this.btnFullScreenCapture.Text = "FullScreenCapture";
            this.btnFullScreenCapture.UseVisualStyleBackColor = true;
            this.btnFullScreenCapture.Click += new System.EventHandler(this.btnFullScreenCapture_Click);
            // 
            // FakeConsole
            // 
            this.FakeConsole.Location = new System.Drawing.Point(57, 12);
            this.FakeConsole.Multiline = true;
            this.FakeConsole.Name = "FakeConsole";
            this.FakeConsole.Size = new System.Drawing.Size(527, 158);
            this.FakeConsole.TabIndex = 1;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "PosX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 422);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "PosY";
            // 
            // btnPaintOnScreen
            // 
            this.btnPaintOnScreen.Location = new System.Drawing.Point(249, 331);
            this.btnPaintOnScreen.Name = "btnPaintOnScreen";
            this.btnPaintOnScreen.Size = new System.Drawing.Size(158, 51);
            this.btnPaintOnScreen.TabIndex = 4;
            this.btnPaintOnScreen.Text = "btnPrintOnScreen";
            this.btnPaintOnScreen.UseVisualStyleBackColor = true;
            this.btnPaintOnScreen.Click += new System.EventHandler(this.btnPaintOnScreen_Click);
            // 
            // btnCapturePart
            // 
            this.btnCapturePart.Location = new System.Drawing.Point(469, 331);
            this.btnCapturePart.Name = "btnCapturePart";
            this.btnCapturePart.Size = new System.Drawing.Size(162, 51);
            this.btnCapturePart.TabIndex = 5;
            this.btnCapturePart.Text = "CapturePart";
            this.btnCapturePart.UseVisualStyleBackColor = true;
            this.btnCapturePart.Click += new System.EventHandler(this.btnCapturePart_Click);
            // 
            // btnStartCpatureMouse
            // 
            this.btnStartCpatureMouse.Location = new System.Drawing.Point(469, 267);
            this.btnStartCpatureMouse.Name = "btnStartCpatureMouse";
            this.btnStartCpatureMouse.Size = new System.Drawing.Size(162, 42);
            this.btnStartCpatureMouse.TabIndex = 6;
            this.btnStartCpatureMouse.Text = "StartCaptureMouse";
            this.btnStartCpatureMouse.UseVisualStyleBackColor = true;
            this.btnStartCpatureMouse.Click += new System.EventHandler(this.btnStartCpatureMouse_Click);
            // 
            // btnStopCaptureMouse
            // 
            this.btnStopCaptureMouse.Location = new System.Drawing.Point(637, 267);
            this.btnStopCaptureMouse.Name = "btnStopCaptureMouse";
            this.btnStopCaptureMouse.Size = new System.Drawing.Size(162, 43);
            this.btnStopCaptureMouse.TabIndex = 7;
            this.btnStopCaptureMouse.Text = "StopCaptureMouse";
            this.btnStopCaptureMouse.UseVisualStyleBackColor = true;
            this.btnStopCaptureMouse.Click += new System.EventHandler(this.btnStopCaptureMouse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 450);
            this.Controls.Add(this.btnStopCaptureMouse);
            this.Controls.Add(this.btnStartCpatureMouse);
            this.Controls.Add(this.btnCapturePart);
            this.Controls.Add(this.btnPaintOnScreen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FakeConsole);
            this.Controls.Add(this.btnFullScreenCapture);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFullScreenCapture;
        private System.Windows.Forms.TextBox FakeConsole;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPaintOnScreen;
        private System.Windows.Forms.Button btnCapturePart;
        private System.Windows.Forms.Button btnStartCpatureMouse;
        private System.Windows.Forms.Button btnStopCaptureMouse;
    }
}

