namespace FormBase1
{
    partial class FormBaseBusArt
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
			this.buttonNue = new System.Windows.Forms.Button();
			this.buttonSel = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.buttonCan = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonNue
			// 
			this.buttonNue.Location = new System.Drawing.Point(174, 198);
			this.buttonNue.Name = "buttonNue";
			this.buttonNue.Size = new System.Drawing.Size(75, 23);
			this.buttonNue.TabIndex = 11;
			this.buttonNue.Text = "Nuevo...";
			this.buttonNue.UseVisualStyleBackColor = true;
			// 
			// buttonSel
			// 
			this.buttonSel.Location = new System.Drawing.Point(93, 198);
			this.buttonSel.Name = "buttonSel";
			this.buttonSel.Size = new System.Drawing.Size(75, 23);
			this.buttonSel.TabIndex = 10;
			this.buttonSel.Text = "Seleccionar";
			this.buttonSel.UseVisualStyleBackColor = true;
			this.buttonSel.Click += new System.EventHandler(this.buttonSel_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(12, 31);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(414, 150);
			this.dataGridView1.TabIndex = 9;
			this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			this.dataGridView1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dataGridView1_PreviewKeyDown);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Info;
			this.textBox1.Location = new System.Drawing.Point(55, 5);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(371, 20);
			this.textBox1.TabIndex = 8;
			this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
			this.textBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox1_PreviewKeyDown);
			// 
			// buttonCan
			// 
			this.buttonCan.Location = new System.Drawing.Point(12, 198);
			this.buttonCan.Name = "buttonCan";
			this.buttonCan.Size = new System.Drawing.Size(75, 23);
			this.buttonCan.TabIndex = 12;
			this.buttonCan.Text = "Cancelar";
			this.buttonCan.UseVisualStyleBackColor = true;
			this.buttonCan.Click += new System.EventHandler(this.buttonCan_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Buscar";
			// 
			// FormBaseBusArt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(434, 227);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonNue);
			this.Controls.Add(this.buttonSel);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.buttonCan);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Name = "FormBaseBusArt";
			this.Text = "Buscar Item";
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormBaseBusArt_PreviewKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNue;
        private System.Windows.Forms.Button buttonSel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonCan;
        private System.Windows.Forms.Label label1;
    }
}