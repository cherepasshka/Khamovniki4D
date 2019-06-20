namespace Khamovniki4D
{
    partial class GraphCreator
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.year = new System.Windows.Forms.TrackBar();
            this.create = new System.Windows.Forms.Button();
            this.go = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.ComboBox();
            this.currentYear = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.hint = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chooseInputFile = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseUri = new System.Windows.Forms.ToolStripMenuItem();
            this.openInputFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.year)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // year
            // 
            this.year.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.year.Location = new System.Drawing.Point(59, 75);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(491, 45);
            this.year.TabIndex = 0;
            this.year.Scroll += new System.EventHandler(this.Year_Scroll);
            this.year.MouseEnter += new System.EventHandler(this.Year_MouseEnter);
            this.year.MouseLeave += new System.EventHandler(this.Year_MouseLeave);
            // 
            // create
            // 
            this.create.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.create.Location = new System.Drawing.Point(164, 126);
            this.create.Name = "create";
            this.create.Size = new System.Drawing.Size(277, 28);
            this.create.TabIndex = 1;
            this.create.Text = "Сделать граф";
            this.create.UseVisualStyleBackColor = true;
            this.create.Click += new System.EventHandler(this.Create_Click);
            this.create.MouseEnter += new System.EventHandler(this.Create_MouseEnter);
            this.create.MouseLeave += new System.EventHandler(this.Create_MouseLeave);
            // 
            // go
            // 
            this.go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.go.Location = new System.Drawing.Point(164, 175);
            this.go.Name = "go";
            this.go.Size = new System.Drawing.Size(277, 29);
            this.go.TabIndex = 2;
            this.go.Text = "Перейти в Neo4j браузер";
            this.go.UseVisualStyleBackColor = true;
            this.go.Click += new System.EventHandler(this.Go_Click);
            this.go.MouseEnter += new System.EventHandler(this.Go_MouseEnter);
            this.go.MouseLeave += new System.EventHandler(this.Go_MouseLeave);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.status.FormattingEnabled = true;
            this.status.Location = new System.Drawing.Point(79, 227);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(447, 21);
            this.status.TabIndex = 3;
            // 
            // currentYear
            // 
            this.currentYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.currentYear.AutoSize = true;
            this.currentYear.Location = new System.Drawing.Point(262, 46);
            this.currentYear.Name = "currentYear";
            this.currentYear.Size = new System.Drawing.Size(35, 13);
            this.currentYear.TabIndex = 4;
            this.currentYear.Text = "label1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hint});
            this.statusStrip1.Location = new System.Drawing.Point(0, 271);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(639, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // hint
            // 
            this.hint.Name = "hint";
            this.hint.Size = new System.Drawing.Size(118, 17);
            this.hint.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseInputFile,
            this.chooseUri});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chooseInputFile
            // 
            this.chooseInputFile.Name = "chooseInputFile";
            this.chooseInputFile.Size = new System.Drawing.Size(147, 20);
            this.chooseInputFile.Text = "Выбрать входной файл";
            this.chooseInputFile.Click += new System.EventHandler(this.ChooseInputFile_Click);
            this.chooseInputFile.MouseEnter += new System.EventHandler(this.ChooseInputFile_MouseEnter);
            this.chooseInputFile.MouseLeave += new System.EventHandler(this.ChooseInputFile_MouseLeave);
            // 
            // chooseUri
            // 
            this.chooseUri.Name = "chooseUri";
            this.chooseUri.Size = new System.Drawing.Size(145, 20);
            this.chooseUri.Text = "Выбрать URI для графа";
            this.chooseUri.Click += new System.EventHandler(this.ChooseUri_Click);
            this.chooseUri.MouseEnter += new System.EventHandler(this.ChooseUri_MouseEnter);
            this.chooseUri.MouseLeave += new System.EventHandler(this.ChooseUri_MouseLeave);
            // 
            // GraphCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 293);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.currentYear);
            this.Controls.Add(this.status);
            this.Controls.Add(this.go);
            this.Controls.Add(this.create);
            this.Controls.Add(this.year);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GraphCreator";
            this.Text = "Создатель графов";
            ((System.ComponentModel.ISupportInitialize)(this.year)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar year;
        private System.Windows.Forms.Button create;
        private System.Windows.Forms.Button go;
        private System.Windows.Forms.ComboBox status;
        private System.Windows.Forms.Label currentYear;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel hint;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chooseInputFile;
        private System.Windows.Forms.ToolStripMenuItem chooseUri;
        private System.Windows.Forms.OpenFileDialog openInputFile;
    }
}

