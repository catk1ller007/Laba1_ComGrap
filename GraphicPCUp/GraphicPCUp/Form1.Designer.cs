using System.Windows.Forms;
using System.Drawing;

namespace GraphicPCUp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.точечныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инверсияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.черноБелоеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сепияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уменьшениеЯркостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.увеличениеЯркостиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.стеклоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.горизонтальныеВолныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вертикальныеВолныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.переносToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.локальныематричныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размытиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гауссToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.увеличениеЯркостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.собельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поворотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.резкостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motionBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.глобальныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.глобальноеРастяжениеГистограммыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.матМорфологияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dilatonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Отмена = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(32, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(526, 554);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(688, 46);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(529, 554);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1285, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // фильтрToolStripMenuItem
            // 
            this.фильтрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.точечныеToolStripMenuItem,
            this.локальныематричныеToolStripMenuItem,
            this.глобальныеToolStripMenuItem,
            this.матМорфологияToolStripMenuItem});
            this.фильтрToolStripMenuItem.Name = "фильтрToolStripMenuItem";
            this.фильтрToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.фильтрToolStripMenuItem.Text = "Фильтр";
            // 
            // точечныеToolStripMenuItem
            // 
            this.точечныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.инверсияToolStripMenuItem,
            this.черноБелоеToolStripMenuItem,
            this.сепияToolStripMenuItem,
            this.уменьшениеЯркостиToolStripMenuItem,
            this.увеличениеЯркостиToolStripMenuItem1,
            this.стеклоToolStripMenuItem,
            this.горизонтальныеВолныToolStripMenuItem,
            this.вертикальныеВолныToolStripMenuItem,
            this.переносToolStripMenuItem1});
            this.точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            this.точечныеToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.точечныеToolStripMenuItem.Text = "Точечные ";
            // 
            // инверсияToolStripMenuItem
            // 
            this.инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            this.инверсияToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.инверсияToolStripMenuItem.Text = "Инверсия";
            this.инверсияToolStripMenuItem.Click += new System.EventHandler(this.инверсияToolStripMenuItem_Click);
            // 
            // черноБелоеToolStripMenuItem
            // 
            this.черноБелоеToolStripMenuItem.Name = "черноБелоеToolStripMenuItem";
            this.черноБелоеToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.черноБелоеToolStripMenuItem.Text = "Черно-Белое";
            this.черноБелоеToolStripMenuItem.Click += new System.EventHandler(this.черноБелоеToolStripMenuItem_Click);
            // 
            // сепияToolStripMenuItem
            // 
            this.сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            this.сепияToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.сепияToolStripMenuItem.Text = "Сепия";
            this.сепияToolStripMenuItem.Click += new System.EventHandler(this.сепияToolStripMenuItem_Click);
            // 
            // уменьшениеЯркостиToolStripMenuItem
            // 
            this.уменьшениеЯркостиToolStripMenuItem.Name = "уменьшениеЯркостиToolStripMenuItem";
            this.уменьшениеЯркостиToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.уменьшениеЯркостиToolStripMenuItem.Text = "Уменьшение яркости";
            this.уменьшениеЯркостиToolStripMenuItem.Click += new System.EventHandler(this.уменьшениеЯркостиToolStripMenuItem_Click);
            // 
            // увеличениеЯркостиToolStripMenuItem1
            // 
            this.увеличениеЯркостиToolStripMenuItem1.Name = "увеличениеЯркостиToolStripMenuItem1";
            this.увеличениеЯркостиToolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.увеличениеЯркостиToolStripMenuItem1.Text = "Увеличение яркости";
            this.увеличениеЯркостиToolStripMenuItem1.Click += new System.EventHandler(this.увеличениеЯркостиToolStripMenuItem1_Click);
            // 
            // стеклоToolStripMenuItem
            // 
            this.стеклоToolStripMenuItem.Name = "стеклоToolStripMenuItem";
            this.стеклоToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.стеклоToolStripMenuItem.Text = "Стекло ";
            this.стеклоToolStripMenuItem.Click += new System.EventHandler(this.стеклоToolStripMenuItem_Click_1);
            // 
            // горизонтальныеВолныToolStripMenuItem
            // 
            this.горизонтальныеВолныToolStripMenuItem.Name = "горизонтальныеВолныToolStripMenuItem";
            this.горизонтальныеВолныToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.горизонтальныеВолныToolStripMenuItem.Text = "Горизонтальные волны";
            this.горизонтальныеВолныToolStripMenuItem.Click += new System.EventHandler(this.горизонтальныеВолныToolStripMenuItem_Click);
            // 
            // вертикальныеВолныToolStripMenuItem
            // 
            this.вертикальныеВолныToolStripMenuItem.Name = "вертикальныеВолныToolStripMenuItem";
            this.вертикальныеВолныToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.вертикальныеВолныToolStripMenuItem.Text = "Вертикальные волны";
            this.вертикальныеВолныToolStripMenuItem.Click += new System.EventHandler(this.вертикальныеВолныToolStripMenuItem_Click);
            // 
            // переносToolStripMenuItem1
            // 
            this.переносToolStripMenuItem1.Name = "переносToolStripMenuItem1";
            this.переносToolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.переносToolStripMenuItem1.Text = "Перенос ";
            this.переносToolStripMenuItem1.Click += new System.EventHandler(this.переносToolStripMenuItem1_Click);
            // 
            // локальныематричныеToolStripMenuItem
            // 
            this.локальныематричныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размытиеToolStripMenuItem,
            this.гауссToolStripMenuItem,
            this.увеличениеЯркостиToolStripMenuItem,
            this.собельToolStripMenuItem,
            this.поворотToolStripMenuItem,
            this.резкостьToolStripMenuItem,
            this.motionBlurToolStripMenuItem});
            this.локальныематричныеToolStripMenuItem.Name = "локальныематричныеToolStripMenuItem";
            this.локальныематричныеToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.локальныематричныеToolStripMenuItem.Text = "Локальные(матричные)";
            // 
            // размытиеToolStripMenuItem
            // 
            this.размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            this.размытиеToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.размытиеToolStripMenuItem.Text = "Размытие";
            this.размытиеToolStripMenuItem.Click += new System.EventHandler(this.размытиеToolStripMenuItem_Click);
            // 
            // гауссToolStripMenuItem
            // 
            this.гауссToolStripMenuItem.Name = "гауссToolStripMenuItem";
            this.гауссToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.гауссToolStripMenuItem.Text = "Гаусс ";
            this.гауссToolStripMenuItem.Click += new System.EventHandler(this.гауссToolStripMenuItem_Click);
            // 
            // увеличениеЯркостиToolStripMenuItem
            // 
            this.увеличениеЯркостиToolStripMenuItem.Name = "увеличениеЯркостиToolStripMenuItem";
            this.увеличениеЯркостиToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.увеличениеЯркостиToolStripMenuItem.Text = "Увеличение Яркости";
            // 
            // собельToolStripMenuItem
            // 
            this.собельToolStripMenuItem.Name = "собельToolStripMenuItem";
            this.собельToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.собельToolStripMenuItem.Text = "Собель";
            this.собельToolStripMenuItem.Click += new System.EventHandler(this.собельToolStripMenuItem_Click);
            // 
            // поворотToolStripMenuItem
            // 
            this.поворотToolStripMenuItem.Name = "поворотToolStripMenuItem";
            this.поворотToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.поворотToolStripMenuItem.Text = "Поворот ";
            this.поворотToolStripMenuItem.Click += new System.EventHandler(this.поворотToolStripMenuItem_Click);
            // 
            // резкостьToolStripMenuItem
            // 
            this.резкостьToolStripMenuItem.Name = "резкостьToolStripMenuItem";
            this.резкостьToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.резкостьToolStripMenuItem.Text = "Резкость";
            this.резкостьToolStripMenuItem.Click += new System.EventHandler(this.резкостьToolStripMenuItem_Click);
            // 
            // motionBlurToolStripMenuItem
            // 
            this.motionBlurToolStripMenuItem.Name = "motionBlurToolStripMenuItem";
            this.motionBlurToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.motionBlurToolStripMenuItem.Text = "Motion Blur";
            this.motionBlurToolStripMenuItem.Click += new System.EventHandler(this.motionBlurToolStripMenuItem_Click);
            // 
            // глобальныеToolStripMenuItem
            // 
            this.глобальныеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.глобальноеРастяжениеГистограммыToolStripMenuItem});
            this.глобальныеToolStripMenuItem.Name = "глобальныеToolStripMenuItem";
            this.глобальныеToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.глобальныеToolStripMenuItem.Text = "Глобальные";
            // 
            // глобальноеРастяжениеГистограммыToolStripMenuItem
            // 
            this.глобальноеРастяжениеГистограммыToolStripMenuItem.Name = "глобальноеРастяжениеГистограммыToolStripMenuItem";
            this.глобальноеРастяжениеГистограммыToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.глобальноеРастяжениеГистограммыToolStripMenuItem.Text = "линейное растяжение Гистограммы";
            this.глобальноеРастяжениеГистограммыToolStripMenuItem.Click += new System.EventHandler(this.глобальноеРастяжениеГистограммыToolStripMenuItem_Click);
            // 
            // матМорфологияToolStripMenuItem
            // 
            this.матМорфологияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.erosionToolStripMenuItem,
            this.dilatonToolStripMenuItem});
            this.матМорфологияToolStripMenuItem.Name = "матМорфологияToolStripMenuItem";
            this.матМорфологияToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.матМорфологияToolStripMenuItem.Text = "Мат морфология ";
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.erosionToolStripMenuItem.Text = "Erosion";
            // 
            // dilatonToolStripMenuItem
            // 
            this.dilatonToolStripMenuItem.Name = "dilatonToolStripMenuItem";
            this.dilatonToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.dilatonToolStripMenuItem.Text = "Dilaton";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(32, 619);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(626, 32);
            this.progressBar1.TabIndex = 3;
            // 
            // Отмена
            // 
            this.Отмена.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Отмена.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Отмена.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Отмена.Location = new System.Drawing.Point(688, 619);
            this.Отмена.Name = "Отмена";
            this.Отмена.Size = new System.Drawing.Size(130, 32);
            this.Отмена.TabIndex = 4;
            this.Отмена.Text = "Отмена";
            this.Отмена.UseVisualStyleBackColor = false;
            this.Отмена.Click += new System.EventHandler(this.Отмена_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(848, 619);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 32);
            this.button1.TabIndex = 5;
            this.button1.Text = "Очистка";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(1019, 619);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "Поменять местами";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 665);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Отмена);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фильтрToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem точечныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem локальныематричныеToolStripMenuItem;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Отмена;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem инверсияToolStripMenuItem;
        private ToolStripMenuItem черноБелоеToolStripMenuItem;
        private ToolStripMenuItem сепияToolStripMenuItem;
        private ToolStripMenuItem размытиеToolStripMenuItem;
        private ToolStripMenuItem гауссToolStripMenuItem;
        private ToolStripMenuItem увеличениеЯркостиToolStripMenuItem;
        private ToolStripMenuItem собельToolStripMenuItem;
        private Button button1;
        private Button button2;
        private ToolStripMenuItem поворотToolStripMenuItem;
        private ToolStripMenuItem уменьшениеЯркостиToolStripMenuItem;
        private ToolStripMenuItem увеличениеЯркостиToolStripMenuItem1;
        private ToolStripMenuItem резкостьToolStripMenuItem;
        private ToolStripMenuItem глобальныеToolStripMenuItem;
        private ToolStripMenuItem глобальноеРастяжениеГистограммыToolStripMenuItem;
        private ToolStripMenuItem стеклоToolStripMenuItem;
        private ToolStripMenuItem горизонтальныеВолныToolStripMenuItem;
        private ToolStripMenuItem вертикальныеВолныToolStripMenuItem;
        private ToolStripMenuItem переносToolStripMenuItem1;
        private ToolStripMenuItem матМорфологияToolStripMenuItem;
        private ToolStripMenuItem erosionToolStripMenuItem;
        private ToolStripMenuItem motionBlurToolStripMenuItem;
        private ToolStripMenuItem dilatonToolStripMenuItem;
    }
}

