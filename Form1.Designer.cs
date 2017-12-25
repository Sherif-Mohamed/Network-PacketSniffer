namespace Packet_Sniffer_test
{
    partial class GUI
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
            this.Select_but = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Protocol_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Select_but
            // 
            this.Select_but.Location = new System.Drawing.Point(12, 12);
            this.Select_but.Name = "Select_but";
            this.Select_but.Size = new System.Drawing.Size(75, 23);
            this.Select_but.TabIndex = 0;
            this.Select_but.Text = "Select";
            this.Select_but.UseVisualStyleBackColor = true;
            this.Select_but.Click += new System.EventHandler(this.Select_but_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 103);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(13, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(71, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "capture";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(90, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(43, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "stop";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time_,
            this.Source_,
            this.Destination_,
            this.Protocol_,
            this.Length_,
            this.Info_});
            this.dataGridView1.Location = new System.Drawing.Point(192, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(744, 219);
            this.dataGridView1.TabIndex = 5;
            //
            // Time_
            // 
            this.Time_.HeaderText = "Time";
            this.Time_.Name = "Time_";
            // 
            // Source_
            // 
            this.Source_.HeaderText = "Source";
            this.Source_.Name = "Source_";
            // 
            // Destination_
            // 
            this.Destination_.HeaderText = "Destination";
            this.Destination_.Name = "Destination_";
            // 
            // Protocol_
            // 
            this.Protocol_.HeaderText = "Protocol";
            this.Protocol_.Name = "Protocol_";
            // 
            // Length_
            // 
            this.Length_.HeaderText = "Length";
            this.Length_.Name = "Length_";
            // 
            // Info_
            // 
            this.Info_.HeaderText = "Info";
            this.Info_.Name = "Info_";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 313);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.Select_but);
            this.Name = "GUI";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Select_but;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Protocol_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info_;
    }
}

