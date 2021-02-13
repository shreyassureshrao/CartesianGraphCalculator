namespace WindowsFormsApp1
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnCalcGraph = new System.Windows.Forms.Button();
            this.lbl1DType = new System.Windows.Forms.Label();
            this.cmCGType = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnNode = new System.Windows.Forms.Button();
            this.txtNodeCount = new System.Windows.Forms.TextBox();
            this.lblNodeCount = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.btnWeights = new System.Windows.Forms.Button();
            this.cmbGraphType = new System.Windows.Forms.ComboBox();
            this.lblCartesianType = new System.Windows.Forms.Label();
            this.btnInputMatrix = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.txtCols = new System.Windows.Forms.TextBox();
            this.lblColumns = new System.Windows.Forms.Label();
            this.txtRows = new System.Windows.Forms.TextBox();
            this.lblRows = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnExport = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(176, 27);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1085, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.dataGridView2);
            this.tabPage1.Controls.Add(this.btnCalcGraph);
            this.tabPage1.Controls.Add(this.lbl1DType);
            this.tabPage1.Controls.Add(this.cmCGType);
            this.tabPage1.Controls.Add(this.btnNode);
            this.tabPage1.Controls.Add(this.txtNodeCount);
            this.tabPage1.Controls.Add(this.lblNodeCount);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1077, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "One-Dimensional Cartesian Graphs";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView2.Location = new System.Drawing.Point(594, 137);
            this.dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView2.Size = new System.Drawing.Size(442, 126);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // btnCalcGraph
            // 
            this.btnCalcGraph.Location = new System.Drawing.Point(737, 95);
            this.btnCalcGraph.Name = "btnCalcGraph";
            this.btnCalcGraph.Size = new System.Drawing.Size(149, 21);
            this.btnCalcGraph.TabIndex = 6;
            this.btnCalcGraph.Text = "Compute Total Weights";
            this.btnCalcGraph.UseVisualStyleBackColor = true;
            this.btnCalcGraph.Click += new System.EventHandler(this.btnCalcGraph_Click);
            // 
            // lbl1DType
            // 
            this.lbl1DType.AutoSize = true;
            this.lbl1DType.Location = new System.Drawing.Point(646, 53);
            this.lbl1DType.Name = "lbl1DType";
            this.lbl1DType.Size = new System.Drawing.Size(168, 13);
            this.lbl1DType.TabIndex = 5;
            this.lbl1DType.Text = "Enter the Type of Cartesian Graph";
            // 
            // cmCGType
            // 
            this.cmCGType.FormattingEnabled = true;
            this.cmCGType.Items.AddRange(new object[] {
            "Sequential or P Structure",
            "Cyclic or C Structure",
            "Intertwined or K Structure"});
            this.cmCGType.Location = new System.Drawing.Point(843, 50);
            this.cmCGType.Name = "cmCGType";
            this.cmCGType.Size = new System.Drawing.Size(150, 21);
            this.cmCGType.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(16, 131);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView1.Size = new System.Drawing.Size(469, 121);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnNode
            // 
            this.btnNode.Location = new System.Drawing.Point(186, 95);
            this.btnNode.Name = "btnNode";
            this.btnNode.Size = new System.Drawing.Size(119, 21);
            this.btnNode.TabIndex = 2;
            this.btnNode.Text = "Create Input Matrix";
            this.btnNode.UseVisualStyleBackColor = true;
            this.btnNode.Click += new System.EventHandler(this.btnNode_Click);
            // 
            // txtNodeCount
            // 
            this.txtNodeCount.Location = new System.Drawing.Point(281, 56);
            this.txtNodeCount.Name = "txtNodeCount";
            this.txtNodeCount.Size = new System.Drawing.Size(91, 20);
            this.txtNodeCount.TabIndex = 1;
            this.txtNodeCount.TextChanged += new System.EventHandler(this.txtNodeCount_TextChanged);
            // 
            // lblNodeCount
            // 
            this.lblNodeCount.AutoSize = true;
            this.lblNodeCount.Location = new System.Drawing.Point(81, 56);
            this.lblNodeCount.Name = "lblNodeCount";
            this.lblNodeCount.Size = new System.Drawing.Size(135, 13);
            this.lblNodeCount.TabIndex = 0;
            this.lblNodeCount.Text = "Enter the number of nodes:";
            this.lblNodeCount.Click += new System.EventHandler(this.lblNodeCount_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.dataGridView4);
            this.tabPage2.Controls.Add(this.cmbGraphType);
            this.tabPage2.Controls.Add(this.lblCartesianType);
            this.tabPage2.Controls.Add(this.btnInputMatrix);
            this.tabPage2.Controls.Add(this.dataGridView3);
            this.tabPage2.Controls.Add(this.txtCols);
            this.tabPage2.Controls.Add(this.lblColumns);
            this.tabPage2.Controls.Add(this.txtRows);
            this.tabPage2.Controls.Add(this.lblRows);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1077, 488);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Two-Dimensional Cartesian Graphs";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView4.Location = new System.Drawing.Point(597, 171);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(443, 197);
            this.dataGridView4.TabIndex = 9;
            // 
            // btnWeights
            // 
            this.btnWeights.Location = new System.Drawing.Point(178, 109);
            this.btnWeights.Name = "btnWeights";
            this.btnWeights.Size = new System.Drawing.Size(160, 23);
            this.btnWeights.TabIndex = 8;
            this.btnWeights.Text = "Compute Total Weights";
            this.btnWeights.UseVisualStyleBackColor = true;
            this.btnWeights.Click += new System.EventHandler(this.btnWeights_Click);
            // 
            // cmbGraphType
            // 
            this.cmbGraphType.FormattingEnabled = true;
            this.cmbGraphType.Items.AddRange(new object[] {
            "Pm*Pn",
            "Pm*Cn",
            "Pm*Kn",
            "Cm*Pn",
            "Cm*Cn",
            "Cm*Kn",
            "Km*Pn",
            "Km*Cn",
            "Km*Kn"});
            this.cmbGraphType.Location = new System.Drawing.Point(823, 65);
            this.cmbGraphType.Name = "cmbGraphType";
            this.cmbGraphType.Size = new System.Drawing.Size(165, 21);
            this.cmbGraphType.TabIndex = 7;
            // 
            // lblCartesianType
            // 
            this.lblCartesianType.AutoSize = true;
            this.lblCartesianType.Location = new System.Drawing.Point(654, 69);
            this.lblCartesianType.Name = "lblCartesianType";
            this.lblCartesianType.Size = new System.Drawing.Size(150, 13);
            this.lblCartesianType.TabIndex = 6;
            this.lblCartesianType.Text = "Enter Type of Cartesian Graph";
            // 
            // btnInputMatrix
            // 
            this.btnInputMatrix.Location = new System.Drawing.Point(172, 127);
            this.btnInputMatrix.Name = "btnInputMatrix";
            this.btnInputMatrix.Size = new System.Drawing.Size(132, 23);
            this.btnInputMatrix.TabIndex = 5;
            this.btnInputMatrix.Text = "Create Input Matrix";
            this.btnInputMatrix.UseVisualStyleBackColor = true;
            this.btnInputMatrix.Click += new System.EventHandler(this.btnInputMatrix_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView3.Location = new System.Drawing.Point(26, 166);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(455, 202);
            this.dataGridView3.TabIndex = 4;
            // 
            // txtCols
            // 
            this.txtCols.Location = new System.Drawing.Point(253, 84);
            this.txtCols.Name = "txtCols";
            this.txtCols.Size = new System.Drawing.Size(100, 20);
            this.txtCols.TabIndex = 3;
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(112, 90);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(120, 13);
            this.lblColumns.TabIndex = 2;
            this.lblColumns.Text = "Enter no. of Columns (n)";
            // 
            // txtRows
            // 
            this.txtRows.Location = new System.Drawing.Point(253, 41);
            this.txtRows.Name = "txtRows";
            this.txtRows.Size = new System.Drawing.Size(100, 20);
            this.txtRows.TabIndex = 1;
            // 
            // lblRows
            // 
            this.lblRows.AutoSize = true;
            this.lblRows.Location = new System.Drawing.Point(119, 44);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(109, 13);
            this.lblRows.TabIndex = 0;
            this.lblRows.Text = "Enter no. of Rows (m)";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(213, 366);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(101, 23);
            this.btnExportExcel.TabIndex = 11;
            this.btnExportExcel.Text = "Export to Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 401);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(194, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "INPUT BOX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "INPUT FIELD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(783, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "OUTPUT BOX";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnWeights);
            this.panel2.Controls.Add(this.btnExportExcel);
            this.panel2.Location = new System.Drawing.Point(570, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 400);
            this.panel2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "INPUT BOX";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(775, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "OUTPUT BOX";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Location = new System.Drawing.Point(17, 7);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(503, 299);
            this.panel3.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnExport);
            this.panel4.Location = new System.Drawing.Point(567, 7);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(489, 299);
            this.panel4.TabIndex = 11;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(196, 268);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(116, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 547);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Cartesian Graph Calculator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cmCGType;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnCalcGraph;
        private System.Windows.Forms.Label lbl1DType;
        private System.Windows.Forms.Button btnNode;
        private System.Windows.Forms.TextBox txtNodeCount;
        private System.Windows.Forms.Label lblNodeCount;
        private System.Windows.Forms.Button btnInputMatrix;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TextBox txtCols;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.TextBox txtRows;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.ComboBox cmbGraphType;
        private System.Windows.Forms.Label lblCartesianType;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button btnWeights;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnExport;
    }
}

