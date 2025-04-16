namespace StationOffsetCalculator.WinForms
{
    partial class MainForm
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
            label1 = new Label();
            txtFilePath = new TextBox();
            btnLoadPolyline = new Button();
            polylinePanel = new Panel();
            label2 = new Label();
            label3 = new Label();
            txtX = new TextBox();
            txtY = new TextBox();
            btnCalculate = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtStation = new TextBox();
            txtOffset = new TextBox();
            txtNearestPoint = new TextBox();
            label7 = new Label();
            txtStatus = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 21);
            label1.Name = "label1";
            label1.Size = new Size(107, 25);
            label1.TabIndex = 0;
            label1.Text = "Polyline File:";
            // 
            // txtFilePath
            // 
            txtFilePath.BackColor = SystemColors.ControlLightLight;
            txtFilePath.Location = new Point(120, 21);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(316, 31);
            txtFilePath.TabIndex = 1;
            // 
            // btnLoadPolyline
            // 
            btnLoadPolyline.BackColor = SystemColors.ActiveCaption;
            btnLoadPolyline.ForeColor = SystemColors.ControlLightLight;
            btnLoadPolyline.Location = new Point(442, 12);
            btnLoadPolyline.Name = "btnLoadPolyline";
            btnLoadPolyline.Size = new Size(192, 48);
            btnLoadPolyline.TabIndex = 2;
            btnLoadPolyline.Text = "Load Polyline";
            btnLoadPolyline.UseVisualStyleBackColor = false;
            // 
            // polylinePanel
            // 
            polylinePanel.BorderStyle = BorderStyle.FixedSingle;
            polylinePanel.Location = new Point(640, 15);
            polylinePanel.Name = "polylinePanel";
            polylinePanel.Size = new Size(740, 526);
            polylinePanel.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 72);
            label2.Name = "label2";
            label2.Size = new Size(27, 25);
            label2.TabIndex = 4;
            label2.Text = "X:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(424, 69);
            label3.Name = "label3";
            label3.Size = new Size(26, 25);
            label3.TabIndex = 5;
            label3.Text = "Y:";
            // 
            // txtX
            // 
            txtX.Location = new Point(41, 69);
            txtX.Name = "txtX";
            txtX.Size = new Size(150, 31);
            txtX.TabIndex = 6;
            // 
            // txtY
            // 
            txtY.Location = new Point(456, 66);
            txtY.Name = "txtY";
            txtY.Size = new Size(150, 31);
            txtY.TabIndex = 7;
            // 
            // btnCalculate
            // 
            btnCalculate.BackColor = SystemColors.ActiveCaption;
            btnCalculate.Location = new Point(235, 158);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(130, 50);
            btnCalculate.TabIndex = 8;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 252);
            label4.Name = "label4";
            label4.Size = new Size(71, 25);
            label4.TabIndex = 9;
            label4.Text = "Station:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 306);
            label5.Name = "label5";
            label5.Size = new Size(65, 25);
            label5.TabIndex = 10;
            label5.Text = "Offset:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 361);
            label6.Name = "label6";
            label6.Size = new Size(121, 25);
            label6.TabIndex = 11;
            label6.Text = "Nearest Point:";
            // 
            // txtStation
            // 
            txtStation.BackColor = SystemColors.ControlLightLight;
            txtStation.Location = new Point(105, 246);
            txtStation.Name = "txtStation";
            txtStation.ReadOnly = true;
            txtStation.Size = new Size(150, 31);
            txtStation.TabIndex = 12;
            // 
            // txtOffset
            // 
            txtOffset.BackColor = SystemColors.ControlLightLight;
            txtOffset.Location = new Point(105, 300);
            txtOffset.Name = "txtOffset";
            txtOffset.ReadOnly = true;
            txtOffset.Size = new Size(150, 31);
            txtOffset.TabIndex = 13;
            // 
            // txtNearestPoint
            // 
            txtNearestPoint.BackColor = SystemColors.ControlLightLight;
            txtNearestPoint.Location = new Point(143, 361);
            txtNearestPoint.Name = "txtNearestPoint";
            txtNearestPoint.ReadOnly = true;
            txtNearestPoint.Size = new Size(150, 31);
            txtNearestPoint.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 444);
            label7.Name = "label7";
            label7.Size = new Size(64, 25);
            label7.TabIndex = 15;
            label7.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.BackColor = SystemColors.ControlLightLight;
            txtStatus.Location = new Point(90, 444);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(493, 31);
            txtStatus.TabIndex = 16;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1392, 550);
            Controls.Add(txtStatus);
            Controls.Add(label7);
            Controls.Add(txtNearestPoint);
            Controls.Add(txtOffset);
            Controls.Add(txtStation);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnCalculate);
            Controls.Add(txtY);
            Controls.Add(txtX);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(polylinePanel);
            Controls.Add(btnLoadPolyline);
            Controls.Add(txtFilePath);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Station Offset Calculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFilePath;
        private Button btnLoadPolyline;
        private Panel polylinePanel;
        private Label label2;
        private Label label3;
        private TextBox txtX;
        private TextBox txtY;
        private Button btnCalculate;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtStation;
        private TextBox txtOffset;
        private TextBox txtNearestPoint;
        private Label label7;
        private TextBox txtStatus;
    }
}
