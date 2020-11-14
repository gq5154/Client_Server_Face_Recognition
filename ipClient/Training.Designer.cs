namespace Casablanca.IPClient {
    partial class Training {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         this.CamView = new Emgu.CV.UI.ImageBox();
         this.NameBox = new System.Windows.Forms.TextBox();
         this.FaceBox1 = new Emgu.CV.UI.ImageBox();
         this.Start = new System.Windows.Forms.Button();
         this.Stop = new System.Windows.Forms.Button();
         this.TooMany = new System.Windows.Forms.Label();
         this.RemainingImages = new System.Windows.Forms.Label();
         this.PicLabel = new System.Windows.Forms.Label();
         this.FaceBox2 = new Emgu.CV.UI.ImageBox();
         this.FaceBox3 = new Emgu.CV.UI.ImageBox();
         this.FaceBox4 = new Emgu.CV.UI.ImageBox();
         this.FaceBox5 = new Emgu.CV.UI.ImageBox();
         this.FaceBox6 = new Emgu.CV.UI.ImageBox();
         this.FaceBox7 = new Emgu.CV.UI.ImageBox();
         this.FaceBox8 = new Emgu.CV.UI.ImageBox();
         this.FaceBox9 = new Emgu.CV.UI.ImageBox();
         this.Save1 = new System.Windows.Forms.CheckBox();
         this.Save2 = new System.Windows.Forms.CheckBox();
         this.Save3 = new System.Windows.Forms.CheckBox();
         this.Save4 = new System.Windows.Forms.CheckBox();
         this.Save5 = new System.Windows.Forms.CheckBox();
         this.Save6 = new System.Windows.Forms.CheckBox();
         this.Save7 = new System.Windows.Forms.CheckBox();
         this.Save8 = new System.Windows.Forms.CheckBox();
         this.Save9 = new System.Windows.Forms.CheckBox();
         this.Save = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.CamView)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox4)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox5)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox6)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox7)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox8)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox9)).BeginInit();
         this.SuspendLayout();
         // 
         // CamView
         // 
         this.CamView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.CamView.Location = new System.Drawing.Point(12, 12);
         this.CamView.Name = "CamView";
         this.CamView.Size = new System.Drawing.Size(400, 315);
         this.CamView.TabIndex = 2;
         this.CamView.TabStop = false;
         // 
         // NameBox
         // 
         this.NameBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
         this.NameBox.ForeColor = System.Drawing.Color.Yellow;
         this.NameBox.Location = new System.Drawing.Point(12, 339);
         this.NameBox.Name = "NameBox";
         this.NameBox.Size = new System.Drawing.Size(400, 20);
         this.NameBox.TabIndex = 3;
         // 
         // FaceBox1
         // 
         this.FaceBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox1.Location = new System.Drawing.Point(419, 12);
         this.FaceBox1.Name = "FaceBox1";
         this.FaceBox1.Size = new System.Drawing.Size(100, 100);
         this.FaceBox1.TabIndex = 2;
         this.FaceBox1.TabStop = false;
         // 
         // Start
         // 
         this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(0)))));
         this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.Start.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
         this.Start.Location = new System.Drawing.Point(419, 339);
         this.Start.Name = "Start";
         this.Start.Size = new System.Drawing.Size(100, 39);
         this.Start.TabIndex = 4;
         this.Start.Text = "Iniciar";
         this.Start.UseVisualStyleBackColor = false;
         this.Start.Click += new System.EventHandler(this.Start_Click);
         // 
         // Stop
         // 
         this.Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.Stop.ForeColor = System.Drawing.Color.White;
         this.Stop.Location = new System.Drawing.Point(526, 339);
         this.Stop.Name = "Stop";
         this.Stop.Size = new System.Drawing.Size(100, 39);
         this.Stop.TabIndex = 5;
         this.Stop.Text = "Detener";
         this.Stop.UseVisualStyleBackColor = false;
         this.Stop.Click += new System.EventHandler(this.Stop_Click);
         // 
         // TooMany
         // 
         this.TooMany.AutoSize = true;
         this.TooMany.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
         this.TooMany.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
         this.TooMany.ForeColor = System.Drawing.Color.LightCoral;
         this.TooMany.Location = new System.Drawing.Point(38, 148);
         this.TooMany.Name = "TooMany";
         this.TooMany.Size = new System.Drawing.Size(351, 25);
         this.TooMany.TabIndex = 6;
         this.TooMany.Text = "Hay más de una persona en la imágen.";
         this.TooMany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // RemainingImages
         // 
         this.RemainingImages.AutoSize = true;
         this.RemainingImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
         this.RemainingImages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
         this.RemainingImages.Location = new System.Drawing.Point(107, 362);
         this.RemainingImages.Name = "RemainingImages";
         this.RemainingImages.Size = new System.Drawing.Size(36, 26);
         this.RemainingImages.TabIndex = 7;
         this.RemainingImages.Text = "10";
         // 
         // PicLabel
         // 
         this.PicLabel.AutoSize = true;
         this.PicLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
         this.PicLabel.Location = new System.Drawing.Point(12, 366);
         this.PicLabel.Name = "PicLabel";
         this.PicLabel.Size = new System.Drawing.Size(89, 13);
         this.PicLabel.TabIndex = 8;
         this.PicLabel.Text = "Fotos Pendientes";
         // 
         // FaceBox2
         // 
         this.FaceBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox2.Location = new System.Drawing.Point(526, 12);
         this.FaceBox2.Name = "FaceBox2";
         this.FaceBox2.Size = new System.Drawing.Size(100, 100);
         this.FaceBox2.TabIndex = 2;
         this.FaceBox2.TabStop = false;
         // 
         // FaceBox3
         // 
         this.FaceBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox3.Location = new System.Drawing.Point(633, 12);
         this.FaceBox3.Name = "FaceBox3";
         this.FaceBox3.Size = new System.Drawing.Size(100, 100);
         this.FaceBox3.TabIndex = 2;
         this.FaceBox3.TabStop = false;
         // 
         // FaceBox4
         // 
         this.FaceBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox4.Location = new System.Drawing.Point(419, 120);
         this.FaceBox4.Name = "FaceBox4";
         this.FaceBox4.Size = new System.Drawing.Size(100, 100);
         this.FaceBox4.TabIndex = 2;
         this.FaceBox4.TabStop = false;
         // 
         // FaceBox5
         // 
         this.FaceBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox5.Location = new System.Drawing.Point(526, 120);
         this.FaceBox5.Name = "FaceBox5";
         this.FaceBox5.Size = new System.Drawing.Size(100, 100);
         this.FaceBox5.TabIndex = 2;
         this.FaceBox5.TabStop = false;
         // 
         // FaceBox6
         // 
         this.FaceBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox6.Location = new System.Drawing.Point(633, 120);
         this.FaceBox6.Name = "FaceBox6";
         this.FaceBox6.Size = new System.Drawing.Size(100, 100);
         this.FaceBox6.TabIndex = 2;
         this.FaceBox6.TabStop = false;
         // 
         // FaceBox7
         // 
         this.FaceBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox7.Location = new System.Drawing.Point(419, 227);
         this.FaceBox7.Name = "FaceBox7";
         this.FaceBox7.Size = new System.Drawing.Size(100, 100);
         this.FaceBox7.TabIndex = 2;
         this.FaceBox7.TabStop = false;
         // 
         // FaceBox8
         // 
         this.FaceBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox8.Location = new System.Drawing.Point(526, 227);
         this.FaceBox8.Name = "FaceBox8";
         this.FaceBox8.Size = new System.Drawing.Size(100, 100);
         this.FaceBox8.TabIndex = 2;
         this.FaceBox8.TabStop = false;
         // 
         // FaceBox9
         // 
         this.FaceBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.FaceBox9.Location = new System.Drawing.Point(633, 227);
         this.FaceBox9.Name = "FaceBox9";
         this.FaceBox9.Size = new System.Drawing.Size(100, 100);
         this.FaceBox9.TabIndex = 2;
         this.FaceBox9.TabStop = false;
         // 
         // Save1
         // 
         this.Save1.AutoSize = true;
         this.Save1.Enabled = false;
         this.Save1.Location = new System.Drawing.Point(503, 97);
         this.Save1.Name = "Save1";
         this.Save1.Size = new System.Drawing.Size(15, 14);
         this.Save1.TabIndex = 9;
         this.Save1.UseVisualStyleBackColor = true;
         // 
         // Save2
         // 
         this.Save2.AutoSize = true;
         this.Save2.Location = new System.Drawing.Point(610, 97);
         this.Save2.Name = "Save2";
         this.Save2.Size = new System.Drawing.Size(15, 14);
         this.Save2.TabIndex = 10;
         this.Save2.UseVisualStyleBackColor = true;
         // 
         // Save3
         // 
         this.Save3.AutoSize = true;
         this.Save3.Location = new System.Drawing.Point(717, 97);
         this.Save3.Name = "Save3";
         this.Save3.Size = new System.Drawing.Size(15, 14);
         this.Save3.TabIndex = 11;
         this.Save3.UseVisualStyleBackColor = true;
         // 
         // Save4
         // 
         this.Save4.AutoSize = true;
         this.Save4.Location = new System.Drawing.Point(503, 204);
         this.Save4.Name = "Save4";
         this.Save4.Size = new System.Drawing.Size(15, 14);
         this.Save4.TabIndex = 12;
         this.Save4.UseVisualStyleBackColor = true;
         // 
         // Save5
         // 
         this.Save5.AutoSize = true;
         this.Save5.Location = new System.Drawing.Point(610, 204);
         this.Save5.Name = "Save5";
         this.Save5.Size = new System.Drawing.Size(15, 14);
         this.Save5.TabIndex = 13;
         this.Save5.UseVisualStyleBackColor = true;
         // 
         // Save6
         // 
         this.Save6.AutoSize = true;
         this.Save6.Location = new System.Drawing.Point(717, 204);
         this.Save6.Name = "Save6";
         this.Save6.Size = new System.Drawing.Size(15, 14);
         this.Save6.TabIndex = 14;
         this.Save6.UseVisualStyleBackColor = true;
         // 
         // Save7
         // 
         this.Save7.AutoSize = true;
         this.Save7.Location = new System.Drawing.Point(503, 312);
         this.Save7.Name = "Save7";
         this.Save7.Size = new System.Drawing.Size(15, 14);
         this.Save7.TabIndex = 15;
         this.Save7.UseVisualStyleBackColor = true;
         // 
         // Save8
         // 
         this.Save8.AutoSize = true;
         this.Save8.Location = new System.Drawing.Point(610, 312);
         this.Save8.Name = "Save8";
         this.Save8.Size = new System.Drawing.Size(15, 14);
         this.Save8.TabIndex = 16;
         this.Save8.UseVisualStyleBackColor = true;
         // 
         // Save9
         // 
         this.Save9.AutoSize = true;
         this.Save9.Location = new System.Drawing.Point(717, 312);
         this.Save9.Name = "Save9";
         this.Save9.Size = new System.Drawing.Size(15, 14);
         this.Save9.TabIndex = 17;
         this.Save9.UseVisualStyleBackColor = true;
         // 
         // Save
         // 
         this.Save.Location = new System.Drawing.Point(633, 339);
         this.Save.Name = "Save";
         this.Save.Size = new System.Drawing.Size(100, 40);
         this.Save.TabIndex = 18;
         this.Save.Text = "Guardar";
         this.Save.UseVisualStyleBackColor = true;
         this.Save.Click += new System.EventHandler(this.Save_Click);
         // 
         // Training
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
         this.ClientSize = new System.Drawing.Size(744, 388);
         this.Controls.Add(this.Save);
         this.Controls.Add(this.Save9);
         this.Controls.Add(this.Save8);
         this.Controls.Add(this.Save7);
         this.Controls.Add(this.Save6);
         this.Controls.Add(this.Save5);
         this.Controls.Add(this.Save4);
         this.Controls.Add(this.Save3);
         this.Controls.Add(this.Save2);
         this.Controls.Add(this.Save1);
         this.Controls.Add(this.FaceBox9);
         this.Controls.Add(this.FaceBox8);
         this.Controls.Add(this.FaceBox7);
         this.Controls.Add(this.FaceBox6);
         this.Controls.Add(this.FaceBox5);
         this.Controls.Add(this.FaceBox4);
         this.Controls.Add(this.FaceBox3);
         this.Controls.Add(this.FaceBox2);
         this.Controls.Add(this.PicLabel);
         this.Controls.Add(this.RemainingImages);
         this.Controls.Add(this.TooMany);
         this.Controls.Add(this.Stop);
         this.Controls.Add(this.Start);
         this.Controls.Add(this.FaceBox1);
         this.Controls.Add(this.NameBox);
         this.Controls.Add(this.CamView);
         this.Name = "Training";
         this.Text = "Registro de Rostros";
         ((System.ComponentModel.ISupportInitialize)(this.CamView)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox4)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox5)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox6)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox7)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox8)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FaceBox9)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox CamView;
        private System.Windows.Forms.TextBox NameBox;
        private Emgu.CV.UI.ImageBox FaceBox1;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label TooMany;
        private System.Windows.Forms.Label RemainingImages;
        private System.Windows.Forms.Label PicLabel;
        private Emgu.CV.UI.ImageBox FaceBox2;
        private Emgu.CV.UI.ImageBox FaceBox3;
        private Emgu.CV.UI.ImageBox FaceBox4;
        private Emgu.CV.UI.ImageBox FaceBox5;
        private Emgu.CV.UI.ImageBox FaceBox6;
        private Emgu.CV.UI.ImageBox FaceBox7;
        private Emgu.CV.UI.ImageBox FaceBox8;
        private Emgu.CV.UI.ImageBox FaceBox9;
        private System.Windows.Forms.CheckBox Save1;
        private System.Windows.Forms.CheckBox Save2;
        private System.Windows.Forms.CheckBox Save3;
        private System.Windows.Forms.CheckBox Save4;
        private System.Windows.Forms.CheckBox Save5;
        private System.Windows.Forms.CheckBox Save6;
        private System.Windows.Forms.CheckBox Save7;
        private System.Windows.Forms.CheckBox Save8;
        private System.Windows.Forms.CheckBox Save9;
        private System.Windows.Forms.Button Save;
    }
}

