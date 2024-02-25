namespace TestFaceMask
{
    partial class frmMain
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
            splitContainer1 = new SplitContainer();
            pnlImage = new TestViewFaceCore.MyPanel();
            rbMsk = new RadioButton();
            picMaskImage = new PictureBox();
            btnSelectImage = new Button();
            rbImage = new RadioButton();
            btnSelectColor = new Button();
            rbColor = new RadioButton();
            cbMask = new CheckBox();
            btnFace = new Button();
            nudScale = new NumericUpDown();
            label2 = new Label();
            btnImportImage = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picMaskImage).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudScale).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlImage);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(rbMsk);
            splitContainer1.Panel2.Controls.Add(picMaskImage);
            splitContainer1.Panel2.Controls.Add(btnSelectImage);
            splitContainer1.Panel2.Controls.Add(rbImage);
            splitContainer1.Panel2.Controls.Add(btnSelectColor);
            splitContainer1.Panel2.Controls.Add(rbColor);
            splitContainer1.Panel2.Controls.Add(cbMask);
            splitContainer1.Panel2.Controls.Add(btnFace);
            splitContainer1.Panel2.Controls.Add(nudScale);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(btnImportImage);
            splitContainer1.Size = new Size(1195, 853);
            splitContainer1.SplitterDistance = 892;
            splitContainer1.TabIndex = 0;
            // 
            // pnlImage
            // 
            pnlImage.BackColor = SystemColors.ControlDark;
            pnlImage.Dock = DockStyle.Fill;
            pnlImage.Location = new Point(0, 0);
            pnlImage.Name = "pnlImage";
            pnlImage.Size = new Size(892, 853);
            pnlImage.TabIndex = 1;
            pnlImage.Paint += pnlImage_Paint;
            // 
            // rbMsk
            // 
            rbMsk.AutoSize = true;
            rbMsk.Location = new Point(16, 179);
            rbMsk.Name = "rbMsk";
            rbMsk.Size = new Size(105, 24);
            rbMsk.TabIndex = 18;
            rbMsk.TabStop = true;
            rbMsk.Text = "马赛克填充";
            rbMsk.UseVisualStyleBackColor = true;
            rbMsk.CheckedChanged += rbMsk_CheckedChanged;
            // 
            // picMaskImage
            // 
            picMaskImage.Location = new Point(16, 279);
            picMaskImage.Name = "picMaskImage";
            picMaskImage.Size = new Size(219, 184);
            picMaskImage.SizeMode = PictureBoxSizeMode.StretchImage;
            picMaskImage.TabIndex = 17;
            picMaskImage.TabStop = false;
            // 
            // btnSelectImage
            // 
            btnSelectImage.Location = new Point(114, 244);
            btnSelectImage.Name = "btnSelectImage";
            btnSelectImage.Size = new Size(121, 29);
            btnSelectImage.TabIndex = 16;
            btnSelectImage.Text = "选择图片";
            btnSelectImage.UseVisualStyleBackColor = true;
            btnSelectImage.Click += btnSelectImage_Click;
            // 
            // rbImage
            // 
            rbImage.AutoSize = true;
            rbImage.Location = new Point(18, 246);
            rbImage.Name = "rbImage";
            rbImage.Size = new Size(90, 24);
            rbImage.TabIndex = 15;
            rbImage.TabStop = true;
            rbImage.Text = "图片填充";
            rbImage.UseVisualStyleBackColor = true;
            // 
            // btnSelectColor
            // 
            btnSelectColor.Location = new Point(112, 209);
            btnSelectColor.Name = "btnSelectColor";
            btnSelectColor.Size = new Size(123, 29);
            btnSelectColor.TabIndex = 14;
            btnSelectColor.Text = "选择颜色";
            btnSelectColor.UseVisualStyleBackColor = true;
            btnSelectColor.Click += btnSelectColor_Click;
            // 
            // rbColor
            // 
            rbColor.AutoSize = true;
            rbColor.Location = new Point(16, 211);
            rbColor.Name = "rbColor";
            rbColor.Size = new Size(90, 24);
            rbColor.TabIndex = 13;
            rbColor.TabStop = true;
            rbColor.Text = "纯色填充";
            rbColor.UseVisualStyleBackColor = true;
            // 
            // cbMask
            // 
            cbMask.AutoSize = true;
            cbMask.Location = new Point(15, 149);
            cbMask.Name = "cbMask";
            cbMask.Size = new Size(91, 24);
            cbMask.TabIndex = 12;
            cbMask.Text = "遮挡人脸";
            cbMask.UseVisualStyleBackColor = true;
            cbMask.CheckedChanged += cbMask_CheckedChanged;
            // 
            // btnFace
            // 
            btnFace.Location = new Point(15, 92);
            btnFace.Name = "btnFace";
            btnFace.Size = new Size(148, 29);
            btnFace.TabIndex = 11;
            btnFace.Text = "识 别 人 脸";
            btnFace.UseVisualStyleBackColor = true;
            btnFace.Click += btnFace_Click;
            // 
            // nudScale
            // 
            nudScale.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            nudScale.Location = new Point(98, 59);
            nudScale.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudScale.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudScale.Name = "nudScale";
            nudScale.Size = new Size(66, 27);
            nudScale.TabIndex = 10;
            nudScale.Value = new decimal(new int[] { 100, 0, 0, 0 });
            nudScale.ValueChanged += nudScale_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 61);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 9;
            label2.Text = "缩放比例：";
            // 
            // btnImportImage
            // 
            btnImportImage.Location = new Point(15, 12);
            btnImportImage.Name = "btnImportImage";
            btnImportImage.Size = new Size(148, 29);
            btnImportImage.TabIndex = 8;
            btnImportImage.Text = "导 入 图 片";
            btnImportImage.UseVisualStyleBackColor = true;
            btnImportImage.Click += btnImportImage_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 853);
            Controls.Add(splitContainer1);
            Name = "frmMain";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picMaskImage).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudScale).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private TestViewFaceCore.MyPanel pnlImage;
        private Button btnFace;
        private NumericUpDown nudScale;
        private Label label2;
        private Button btnImportImage;
        private Button btnSelectColor;
        private RadioButton rbColor;
        private CheckBox cbMask;
        private Button btnSelectImage;
        private RadioButton rbImage;
        private PictureBox picMaskImage;
        private RadioButton rbMsk;
    }
}