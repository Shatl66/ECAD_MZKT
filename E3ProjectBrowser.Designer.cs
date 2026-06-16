namespace E3_WGM
{
    partial class E3ProjectBrowser
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.StructureBrowserPanel = new System.Windows.Forms.Panel();
            this.labelNameIzdWindchill = new System.Windows.Forms.Label();
            this.textBoxNameIzdWindchill = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.StructureBrowserPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // StructureBrowserPanel
            // 
            this.StructureBrowserPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StructureBrowserPanel.Controls.Add(this.labelNameIzdWindchill);
            this.StructureBrowserPanel.Controls.Add(this.textBoxNameIzdWindchill);
            this.StructureBrowserPanel.Controls.Add(this.button1);
            this.StructureBrowserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StructureBrowserPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StructureBrowserPanel.Location = new System.Drawing.Point(0, 0);
            this.StructureBrowserPanel.Name = "StructureBrowserPanel";
            this.StructureBrowserPanel.Size = new System.Drawing.Size(632, 234);
            this.StructureBrowserPanel.TabIndex = 3;
            // 
            // labelNameIzdWindchill
            // 
            this.labelNameIzdWindchill.AutoSize = true;
            this.labelNameIzdWindchill.Location = new System.Drawing.Point(9, 92);
            this.labelNameIzdWindchill.Name = "labelNameIzdWindchill";
            this.labelNameIzdWindchill.Size = new System.Drawing.Size(225, 17);
            this.labelNameIzdWindchill.TabIndex = 4;
            this.labelNameIzdWindchill.Text = "Наименование изделия Windchill";
            // 
            // textBoxNameIzdWindchill
            // 
            this.textBoxNameIzdWindchill.Location = new System.Drawing.Point(252, 92);
            this.textBoxNameIzdWindchill.Multiline = true;
            this.textBoxNameIzdWindchill.Name = "textBoxNameIzdWindchill";
            this.textBoxNameIzdWindchill.ReadOnly = true;
            this.textBoxNameIzdWindchill.Size = new System.Drawing.Size(349, 50);
            this.textBoxNameIzdWindchill.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(12, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "Выгрузить проект Е3";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonUploadProjectDoc_Click);
            // 
            // E3ProjectBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.StructureBrowserPanel);
            this.Name = "E3ProjectBrowser";
            this.Size = new System.Drawing.Size(632, 234);
            this.StructureBrowserPanel.ResumeLayout(false);
            this.StructureBrowserPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel StructureBrowserPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxNameIzdWindchill;
        private System.Windows.Forms.Label labelNameIzdWindchill;
    }
}
