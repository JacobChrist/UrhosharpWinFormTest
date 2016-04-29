namespace UrhoTest
{
    partial class UrhoPanel
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
            this.StandaloneButton = new System.Windows.Forms.Button();
            this.urhoSurfacePlaceholder = new System.Windows.Forms.Panel();
            this.RebuildButton = new System.Windows.Forms.Button();
            this.RotatePlusButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.RotateMinusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StandaloneButton
            // 
            this.StandaloneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StandaloneButton.Location = new System.Drawing.Point(147, 355);
            this.StandaloneButton.Name = "StandaloneButton";
            this.StandaloneButton.Size = new System.Drawing.Size(75, 23);
            this.StandaloneButton.TabIndex = 0;
            this.StandaloneButton.Text = "Standalone";
            this.StandaloneButton.UseVisualStyleBackColor = true;
            this.StandaloneButton.Visible = false;
            this.StandaloneButton.Click += new System.EventHandler(this.StandaloneButton_Click);
            // 
            // urhoSurfacePlaceholder
            // 
            this.urhoSurfacePlaceholder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.urhoSurfacePlaceholder.BackColor = System.Drawing.Color.Bisque;
            this.urhoSurfacePlaceholder.Location = new System.Drawing.Point(12, 12);
            this.urhoSurfacePlaceholder.Name = "urhoSurfacePlaceholder";
            this.urhoSurfacePlaceholder.Size = new System.Drawing.Size(453, 337);
            this.urhoSurfacePlaceholder.TabIndex = 1;
            // 
            // RebuildButton
            // 
            this.RebuildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RebuildButton.Location = new System.Drawing.Point(66, 355);
            this.RebuildButton.Name = "RebuildButton";
            this.RebuildButton.Size = new System.Drawing.Size(75, 23);
            this.RebuildButton.TabIndex = 2;
            this.RebuildButton.Text = "Build";
            this.RebuildButton.UseVisualStyleBackColor = true;
            this.RebuildButton.Visible = false;
            this.RebuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // RotatePlusButton
            // 
            this.RotatePlusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RotatePlusButton.Location = new System.Drawing.Point(390, 355);
            this.RotatePlusButton.Name = "RotatePlusButton";
            this.RotatePlusButton.Size = new System.Drawing.Size(75, 23);
            this.RotatePlusButton.TabIndex = 3;
            this.RotatePlusButton.Text = "Rotate +";
            this.RotatePlusButton.UseVisualStyleBackColor = true;
            this.RotatePlusButton.Click += new System.EventHandler(this.RotatePlusButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StopButton.Location = new System.Drawing.Point(309, 355);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 4;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // RotateMinusButton
            // 
            this.RotateMinusButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RotateMinusButton.Location = new System.Drawing.Point(228, 355);
            this.RotateMinusButton.Name = "RotateMinusButton";
            this.RotateMinusButton.Size = new System.Drawing.Size(75, 23);
            this.RotateMinusButton.TabIndex = 5;
            this.RotateMinusButton.Text = "Rotate -";
            this.RotateMinusButton.UseVisualStyleBackColor = true;
            this.RotateMinusButton.Click += new System.EventHandler(this.RotateMinusButton_Click);
            // 
            // UrhoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 390);
            this.Controls.Add(this.RotateMinusButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.RotatePlusButton);
            this.Controls.Add(this.RebuildButton);
            this.Controls.Add(this.urhoSurfacePlaceholder);
            this.Controls.Add(this.StandaloneButton);
            this.Name = "UrhoPanel";
            this.Text = "Urho Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UrhoPanel_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StandaloneButton;
        private System.Windows.Forms.Panel urhoSurfacePlaceholder;
        private System.Windows.Forms.Button RebuildButton;
        private System.Windows.Forms.Button RotatePlusButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button RotateMinusButton;
    }
}

