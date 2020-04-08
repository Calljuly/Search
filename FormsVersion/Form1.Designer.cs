namespace FormsVersion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lbxFileList = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.saveFileDialogue = new System.Windows.Forms.SaveFileDialog();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbxUnsortedWords = new System.Windows.Forms.ListBox();
            this.lbxSortedWords = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSortedList = new System.Windows.Forms.Label();
            this.lblUnsortedList = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.dataSearchResults = new System.Windows.Forms.DataGridView();
            this.WordColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatchesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSearchResults)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialogue
            // 
            this.openFileDialogue.FileName = "openFileDialog1";
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(15, 26);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(185, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "Choose files";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lbxFileList
            // 
            this.lbxFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxFileList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbxFileList.ForeColor = System.Drawing.Color.White;
            this.lbxFileList.FormattingEnabled = true;
            this.lbxFileList.Location = new System.Drawing.Point(26, 130);
            this.lbxFileList.Name = "lbxFileList";
            this.lbxFileList.Size = new System.Drawing.Size(780, 69);
            this.lbxFileList.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(16, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(252, 52);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Location = new System.Drawing.Point(15, 55);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(185, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove files";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbxUnsortedWords
            // 
            this.lbxUnsortedWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbxUnsortedWords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbxUnsortedWords.ForeColor = System.Drawing.Color.White;
            this.lbxUnsortedWords.FormattingEnabled = true;
            this.lbxUnsortedWords.Location = new System.Drawing.Point(26, 225);
            this.lbxUnsortedWords.Name = "lbxUnsortedWords";
            this.lbxUnsortedWords.Size = new System.Drawing.Size(382, 160);
            this.lbxUnsortedWords.TabIndex = 4;
            // 
            // lbxSortedWords
            // 
            this.lbxSortedWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxSortedWords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbxSortedWords.ForeColor = System.Drawing.Color.White;
            this.lbxSortedWords.FormattingEnabled = true;
            this.lbxSortedWords.Location = new System.Drawing.Point(425, 225);
            this.lbxSortedWords.Name = "lbxSortedWords";
            this.lbxSortedWords.Size = new System.Drawing.Size(381, 160);
            this.lbxSortedWords.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Search results";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(15, 56);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(228, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(15, 27);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(228, 20);
            this.tbxSearch.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(524, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 95);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save sorted list";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(26, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 95);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Load files";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox3.Controls.Add(this.tbxSearch);
            this.groupBox3.Controls.Add(this.btnSearch);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(256, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 95);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // lblSortedList
            // 
            this.lblSortedList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSortedList.AutoSize = true;
            this.lblSortedList.Location = new System.Drawing.Point(422, 209);
            this.lblSortedList.Name = "lblSortedList";
            this.lblSortedList.Size = new System.Drawing.Size(96, 13);
            this.lblSortedList.TabIndex = 9;
            this.lblSortedList.Text = "Sorted list of words";
            // 
            // lblUnsortedList
            // 
            this.lblUnsortedList.AutoSize = true;
            this.lblUnsortedList.Location = new System.Drawing.Point(23, 209);
            this.lblUnsortedList.Name = "lblUnsortedList";
            this.lblUnsortedList.Size = new System.Drawing.Size(108, 13);
            this.lblUnsortedList.TabIndex = 8;
            this.lblUnsortedList.Text = "Unsorted list of words";
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(23, 114);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(59, 13);
            this.lblFiles.TabIndex = 14;
            this.lblFiles.Text = "Added files";
            // 
            // dataSearchResults
            // 
            this.dataSearchResults.AllowUserToAddRows = false;
            this.dataSearchResults.AllowUserToDeleteRows = false;
            this.dataSearchResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataSearchResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataSearchResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataSearchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WordColumn,
            this.MatchesColumn,
            this.FileColumn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataSearchResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataSearchResults.Location = new System.Drawing.Point(26, 413);
            this.dataSearchResults.MultiSelect = false;
            this.dataSearchResults.Name = "dataSearchResults";
            this.dataSearchResults.ReadOnly = true;
            this.dataSearchResults.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataSearchResults.Size = new System.Drawing.Size(780, 130);
            this.dataSearchResults.TabIndex = 17;
            // 
            // WordColumn
            // 
            this.WordColumn.Frozen = true;
            this.WordColumn.HeaderText = "Word";
            this.WordColumn.Name = "WordColumn";
            this.WordColumn.ReadOnly = true;
            this.WordColumn.Width = 58;
            // 
            // MatchesColumn
            // 
            this.MatchesColumn.Frozen = true;
            this.MatchesColumn.HeaderText = "Matches";
            this.MatchesColumn.Name = "MatchesColumn";
            this.MatchesColumn.ReadOnly = true;
            this.MatchesColumn.Width = 73;
            // 
            // FileColumn
            // 
            this.FileColumn.Frozen = true;
            this.FileColumn.HeaderText = "File";
            this.FileColumn.Name = "FileColumn";
            this.FileColumn.ReadOnly = true;
            this.FileColumn.Width = 48;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(828, 559);
            this.Controls.Add(this.dataSearchResults);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSortedList);
            this.Controls.Add(this.lblUnsortedList);
            this.Controls.Add(this.lbxSortedWords);
            this.Controls.Add(this.lbxUnsortedWords);
            this.Controls.Add(this.lbxFileList);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.MinimumSize = new System.Drawing.Size(822, 0);
            this.Name = "Form1";
            this.Text = "Searchie Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSearchResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialogue;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ListBox lbxFileList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialogue;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbxUnsortedWords;
        private System.Windows.Forms.ListBox lbxSortedWords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSortedList;
        private System.Windows.Forms.Label lblUnsortedList;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.DataGridView dataSearchResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn WordColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchesColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileColumn;
    }
}

