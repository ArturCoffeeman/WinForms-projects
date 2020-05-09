using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // создаем элементы меню
            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            //fileItem.DropDownItems.Add("Создать");Внимание это заготовки для меню, чтобы обрабатывался клик на меню нужно 
            //fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));//создавать переменную типа ToolStripMenuItem и добавлять обработчик событий

            ToolStripMenuItem openItem = new ToolStripMenuItem("Открыть");
            openItem.Click += openItem_Click;
            fileItem.DropDownItems.Add(openItem);

            ToolStripMenuItem saveItem = new ToolStripMenuItem("Сохранить");
            saveItem.Click += saveItem_Click;
            fileItem.DropDownItems.Add(saveItem);
            //menuStrip1.Items.Add(fileItem);

            ToolStripMenuItem quitItem = new ToolStripMenuItem("Выход");
            quitItem.Click += quitItem_Click;
            quitItem.ShortcutKeys = Keys.Control | Keys.Q; //горячие клавиши, которые будут привязаны к обработчику события клика мыши
            fileItem.DropDownItems.Add(quitItem);
            menuStrip1.Items.Add(fileItem);


            ToolStripMenuItem formatItem = new ToolStripMenuItem("Формат");

            ToolStripMenuItem fontItem = new ToolStripMenuItem("Шрифт"); //переменная с обработчиком
            fontItem.Click += fontItem_Click;                           //события по щелчку мыши
            formatItem.DropDownItems.Add(fontItem);

            ToolStripMenuItem colorItem = new ToolStripMenuItem("Цвет");
            colorItem.Click += colorItem_Click;
            formatItem.DropDownItems.Add(colorItem);
            menuStrip1.Items.Add(formatItem);


            
            ToolStripMenuItem copyMenuItem = new ToolStripMenuItem("Копировать");
            ToolStripMenuItem pasteMenuItem = new ToolStripMenuItem("Вставить");
            
            contextMenuStrip1.Items.AddRange(new[] { copyMenuItem, pasteMenuItem });
            
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
           
            copyMenuItem.Click += copyMenuItem_Click;
            pasteMenuItem.Click += pasteMenuItem_Click;

        }

        // вставка текста
        void pasteMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        // копирование текста
        void copyMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        void saveItem_Click(object sender, EventArgs e)
        {
            //string path = @""
            //richTextBox1.SaveFile(Environment.CurrentDirectory,".rtf");
            SaveFileDialog saveFile1 = new SaveFileDialog();
            saveFile1.DefaultExt = "*.rtf";
            
            if(saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile1.FileName.Length > 0)
            {
                richTextBox1.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        void openItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            if (openFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFile1.FileName.Length > 0)
                richTextBox1.LoadFile(openFile1.FileName, RichTextBoxStreamType.PlainText);
        }

        
        void quitItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //диалог выбора шрифта
        void fontItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
            
        }
        //диалог выбора цвета шрифта
        void colorItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor =colorDialog1.Color;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.ToUpper();
        }
    }
}
