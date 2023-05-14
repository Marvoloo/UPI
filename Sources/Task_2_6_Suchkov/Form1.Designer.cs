namespace Task_2_6_Suchkov
{
    partial class Form1
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
            Students_table = new DataGridView();
            Path_box = new TextBox();
            readb = new Button();
            Fallstudents_table = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Students_table).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Fallstudents_table).BeginInit();
            SuspendLayout();
            // 
            // Students_table
            // 
            Students_table.AllowUserToAddRows = false;
            Students_table.AllowUserToDeleteRows = false;
            Students_table.AllowUserToResizeColumns = false;
            Students_table.AllowUserToResizeRows = false;
            Students_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Students_table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Students_table.BackgroundColor = SystemColors.Info;
            Students_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Students_table.Location = new Point(8, 0);
            Students_table.Name = "Students_table";
            Students_table.RowTemplate.Height = 25;
            Students_table.Size = new Size(805, 191);
            Students_table.TabIndex = 0;
            // 
            // Path_box
            // 
            Path_box.Location = new Point(8, 394);
            Path_box.Name = "Path_box";
            Path_box.Size = new Size(656, 23);
            Path_box.TabIndex = 1;
            // 
            // readb
            // 
            readb.AutoSize = true;
            readb.Location = new Point(670, 394);
            readb.Name = "readb";
            readb.Size = new Size(143, 44);
            readb.TabIndex = 2;
            readb.Text = "Прочитать файл";
            readb.UseVisualStyleBackColor = true;
            readb.Click += readb_Click;
            // 
            // Fallstudents_table
            // 
            Fallstudents_table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Fallstudents_table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Fallstudents_table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Fallstudents_table.Location = new Point(8, 197);
            Fallstudents_table.Name = "Fallstudents_table";
            Fallstudents_table.RowTemplate.Height = 25;
            Fallstudents_table.Size = new Size(805, 191);
            Fallstudents_table.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(819, 450);
            Controls.Add(Fallstudents_table);
            Controls.Add(readb);
            Controls.Add(Path_box);
            Controls.Add(Students_table);
            Name = "Form1";
            Text = "Задание 2 (Вариант 23) Сучков Василий";
            Load += Form1_Load;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)Students_table).EndInit();
            ((System.ComponentModel.ISupportInitialize)Fallstudents_table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Students_table;
        private TextBox Path_box;
        private Button readb;
        private DataGridView Fallstudents_table;
    }
}