namespace LevelEditor
{
    partial class CameraProperties
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
            this.buttonCameraPropOK = new System.Windows.Forms.Button();
            this.tbCamX = new System.Windows.Forms.TextBox();
            this.tbCamY = new System.Windows.Forms.TextBox();
            this.tbCamWidth = new System.Windows.Forms.TextBox();
            this.tbCamHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCameraPropOK
            // 
            this.buttonCameraPropOK.Location = new System.Drawing.Point(91, 222);
            this.buttonCameraPropOK.Name = "buttonCameraPropOK";
            this.buttonCameraPropOK.Size = new System.Drawing.Size(92, 27);
            this.buttonCameraPropOK.TabIndex = 0;
            this.buttonCameraPropOK.Text = "OK";
            this.buttonCameraPropOK.UseVisualStyleBackColor = true;
            this.buttonCameraPropOK.Click += new System.EventHandler(this.buttonCameraPropOK_Click);
            // 
            // tbCamX
            // 
            this.tbCamX.Location = new System.Drawing.Point(116, 38);
            this.tbCamX.Name = "tbCamX";
            this.tbCamX.Size = new System.Drawing.Size(100, 20);
            this.tbCamX.TabIndex = 1;
            // 
            // tbCamY
            // 
            this.tbCamY.Location = new System.Drawing.Point(116, 88);
            this.tbCamY.Name = "tbCamY";
            this.tbCamY.Size = new System.Drawing.Size(100, 20);
            this.tbCamY.TabIndex = 2;
            // 
            // tbCamWidth
            // 
            this.tbCamWidth.Location = new System.Drawing.Point(116, 128);
            this.tbCamWidth.Name = "tbCamWidth";
            this.tbCamWidth.Size = new System.Drawing.Size(100, 20);
            this.tbCamWidth.TabIndex = 3;
            this.tbCamWidth.TextChanged += new System.EventHandler(this.tbCamWidth_TextChanged);
            // 
            // tbCamHeight
            // 
            this.tbCamHeight.Location = new System.Drawing.Point(116, 177);
            this.tbCamHeight.Name = "tbCamHeight";
            this.tbCamHeight.Size = new System.Drawing.Size(100, 20);
            this.tbCamHeight.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Width :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Height :";
            // 
            // CameraProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCamHeight);
            this.Controls.Add(this.tbCamWidth);
            this.Controls.Add(this.tbCamY);
            this.Controls.Add(this.tbCamX);
            this.Controls.Add(this.buttonCameraPropOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CameraProperties";
            this.Text = "CameraProperties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCameraPropOK;
        private System.Windows.Forms.TextBox tbCamX;
        private System.Windows.Forms.TextBox tbCamY;
        private System.Windows.Forms.TextBox tbCamWidth;
        private System.Windows.Forms.TextBox tbCamHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}