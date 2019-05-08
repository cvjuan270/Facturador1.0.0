namespace FormBase1
{
    partial class FormBaseBusc
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
			this.label1 = new System.Windows.Forms.Label();
			this.buttonCan = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonNue
			// 
			this.buttonNue.Location = new System.Drawing.Point(167, 199);
			this.buttonNue.Name = "buttonNue";
			this.buttonNue.Size = new System.Drawing.Size(75, 23);
			this.buttonNue.TabIndex = 4;
			this.buttonNue.Text = "Nuevo...";
			this.buttonNue.UseVisualStyleBackColor = true;
			this.buttonNue.Click += new System.EventHandler(this.buttonNue_Click);
			// 
			// buttonSel
			// 
			this.buttonSel.Location = new System.Drawing.Point(86, 199);
			this.buttonSel.Name = "buttonSel";
			this.buttonSel.Size = new System.Drawing.Size(75, 23);
			this.buttonSel.TabIndex = 3;
			this.buttonSel.Text = "Seleccionar";
			this.buttonSel.UseVisualStyleBackColor = true;
			this.buttonSel.Click += new System.EventHandler(this.buttonSel_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(5, 32);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(414, 150);
			this.dataGridView1.TabIndex = 2;
			this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.Info;
			this.textBox1.Location = new System.Drawing.Point(48, 6);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(371, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Buscar";
			// 
			// buttonCan
			// 
			this.buttonCan.Location = new System.Drawing.Point(5, 199);
			this.buttonCan.Name = "buttonCan";
			this.buttonCan.Size = new System.Drawing.Size(75, 23);
			this.buttonCan.TabIndex = 5;
			this.buttonCan.Text = "Cancelar";
			this.buttonCan.UseVisualStyleBackColor = true;
			this.buttonCan.Click += new System.EventHandler(this.buttonCan_Click);
			// 
			// FormBaseBusc
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(425, 226);
			this.Controls.Add(this.buttonNue);
			this.Controls.Add(this.buttonSel);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCan);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.KeyPreview = true;
			this.Name = "FormBaseBusc";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowIcon = false;
			this.Text = "FormBaseBusc";
			this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FormBaseBusc_PreviewKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNue;
        private System.Windows.Forms.Button buttonSel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCan;
	}
}