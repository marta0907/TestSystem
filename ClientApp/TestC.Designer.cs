
namespace ClientApp
{
    partial class TestC
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_newT = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_resT = new System.Windows.Forms.DataGridView();
            this.Column21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column24 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label_newT = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_resT = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_getT = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_newT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resT)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_newT, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_resT, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_newT, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1359, 774);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView_newT
            // 
            this.dataGridView_newT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_newT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView_newT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_newT.Location = new System.Drawing.Point(6, 106);
            this.dataGridView_newT.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView_newT.Name = "dataGridView_newT";
            this.dataGridView_newT.RowHeadersWidth = 82;
            this.dataGridView_newT.RowTemplate.Height = 25;
            this.dataGridView_newT.Size = new System.Drawing.Size(1347, 274);
            this.dataGridView_newT.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Test Id";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Title";
            this.Column2.MinimumWidth = 10;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Description";
            this.Column3.MinimumWidth = 10;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "Min Pass percentage";
            this.Column4.MinimumWidth = 10;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Max Points";
            this.Column5.MinimumWidth = 10;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 200;
            // 
            // dataGridView_resT
            // 
            this.dataGridView_resT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_resT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column21,
            this.Column23,
            this.Column24});
            this.dataGridView_resT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_resT.Location = new System.Drawing.Point(6, 492);
            this.dataGridView_resT.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView_resT.Name = "dataGridView_resT";
            this.dataGridView_resT.RowHeadersWidth = 82;
            this.dataGridView_resT.RowTemplate.Height = 25;
            this.dataGridView_resT.Size = new System.Drawing.Size(1347, 276);
            this.dataGridView_resT.TabIndex = 1;
            // 
            // Column21
            // 
            this.Column21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column21.HeaderText = "User Test Id";
            this.Column21.MinimumWidth = 10;
            this.Column21.Name = "Column21";
            // 
            // Column23
            // 
            this.Column23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column23.HeaderText = "Resut";
            this.Column23.MinimumWidth = 10;
            this.Column23.Name = "Column23";
            // 
            // Column24
            // 
            this.Column24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column24.HeaderText = "Passed";
            this.Column24.MinimumWidth = 10;
            this.Column24.Name = "Column24";
            this.Column24.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // label_newT
            // 
            this.label_newT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_newT.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_newT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_newT.Location = new System.Drawing.Point(6, 17);
            this.label_newT.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_newT.Name = "label_newT";
            this.label_newT.Size = new System.Drawing.Size(360, 66);
            this.label_newT.TabIndex = 2;
            this.label_newT.Text = "New test for user:";
            this.label_newT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.02632F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.18421F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.65789F));
            this.tableLayoutPanel2.Controls.Add(this.label_resT, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_refresh, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.button_getT, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 392);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1347, 88);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label_resT
            // 
            this.label_resT.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label_resT.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_resT.Location = new System.Drawing.Point(6, 18);
            this.label_resT.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_resT.Name = "label_resT";
            this.label_resT.Size = new System.Drawing.Size(297, 51);
            this.label_resT.TabIndex = 0;
            this.label_resT.Text = "Result test:";
            this.label_resT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_refresh
            // 
            this.button_refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_refresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_refresh.ForeColor = System.Drawing.Color.Green;
            this.button_refresh.Location = new System.Drawing.Point(705, 6);
            this.button_refresh.Margin = new System.Windows.Forms.Padding(6);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(236, 76);
            this.button_refresh.TabIndex = 1;
            this.button_refresh.Text = "Refresh";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_getT
            // 
            this.button_getT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.button_getT.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_getT.ForeColor = System.Drawing.Color.Blue;
            this.button_getT.Location = new System.Drawing.Point(1074, 6);
            this.button_getT.Margin = new System.Windows.Forms.Padding(6);
            this.button_getT.Name = "button_getT";
            this.button_getT.Size = new System.Drawing.Size(199, 76);
            this.button_getT.TabIndex = 2;
            this.button_getT.Text = "Get tested";
            this.button_getT.UseVisualStyleBackColor = true;
            this.button_getT.Click += new System.EventHandler(this.button_getT_Click);
            // 
            // TestC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1359, 774);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "TestC";
            this.Text = "TestClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestC_FormClosing);
            this.Load += new System.EventHandler(this.TestC_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_newT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_resT)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView_newT;
        private System.Windows.Forms.DataGridView dataGridView_resT;
        private System.Windows.Forms.Label label_newT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_resT;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_getT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column21;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column23;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column24;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}