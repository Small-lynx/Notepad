using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class NotepadForm : Form
    {
        private string fileName;
        private int countCharacter;
        public NotepadForm()
        {
            InitializeComponent();
            var menuItem = new ToolStripMenuItem[3]
            {
                new ToolStripMenuItem("Файл"),
                new ToolStripMenuItem("Сохранить"),
                new ToolStripMenuItem("Вид")
            };
            menuItem[0].DropDownItems.Add("Создать", null, newFile_Clik);
            menuItem[0].DropDownItems.Add("Открыть", null, openFile_Clik);
            menuItem[0].DropDownItems.Add("Закрыть", null, closeFile_Clik);
            menuItem[1].DropDownItems.Add("Сохранить", null, saveFile_Clik);
            menuItem[1].DropDownItems.Add("Сохранить как ...", null, saveAsFile_Clik);
            menuItem[2].DropDownItems.Add("Шрифт", null, fontFile_Clik);
            menuItem[2].DropDownItems.Add("Фон", null, backgraundFile_Clik);
            menuStripNotepad.Items.AddRange(menuItem);

            var statusMenuItem = new ToolStripMenuItem[3]
            {
                new ToolStripMenuItem("Строка: Символ: "),
                new ToolStripMenuItem("Количество символов"),
                new ToolStripMenuItem("Скорость печати")
            };
            statusStripNotepad.Items.AddRange(statusMenuItem);
            fileName = "";
            countCharacter = 0;
        }

        /// <summary>
        /// Создание файла
        /// </summary>
        private void newFile_Clik(object sender, EventArgs e)
        {
            saveFile_Clik(sender, e);
            textBox.Text = "";
        }

        /// <summary>
        /// Открытие файла
        /// </summary>
        private void openFile_Clik(object sender, EventArgs e)
        {
            var openFile = new OpenFileDialog()
            {
                Filter = "Текстовые файлы(*.txt)|*.txt"
            };
            if (openFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            saveFile_Clik(sender, e);
            fileName = openFile.FileName;
            Text = $"Блокнот - {fileName}";
            textBox.Text = System.IO.File.ReadAllText(openFile.FileName);
        }

        /// <summary>
        /// Закрытие файла
        /// </summary>
        private void closeFile_Clik(object sender, EventArgs e)
        {
            var closeResult = MessageBox.Show("Хотители вы сохранить изменения в файле?", "Блокнот",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
            switch (closeResult)
            {
                case DialogResult.Cancel:
                    return;
                case DialogResult.Yes:
                    saveFile_Clik(sender, e);
                    Close();
                    break;
                case DialogResult.No:
                    Close();
                    break;
            }
        }

        /// <summary>
        /// Сохранение файла
        /// </summary>
        private void saveFile_Clik(object sender, EventArgs e)
        {
            if (fileName == "")
            {
                saveAsFile_Clik(sender, e);
            }
            else
            {
                System.IO.File.WriteAllText(fileName, textBox.Text);
            }
        }

        /// <summary>
        /// Сохранение файла в другом месте
        /// </summary>
        private void saveAsFile_Clik(object sender, EventArgs e)
        {
            var saveFile = new SaveFileDialog()
            {
                DefaultExt = "Текстовые файлы(*.txt)|*.txt",
                Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*",
                AddExtension = true,
                OverwritePrompt = true
            };
            if (saveFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            System.IO.File.WriteAllText(saveFile.FileName, textBox.Text);
        }

        /// <summary>
        /// Шрифт файла
        /// </summary>
        private void fontFile_Clik(object sender, EventArgs e)
        {
            var fontFile = new FontDialog();
            if (fontFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            textBox.Font = fontFile.Font;
        }

        /// <summary>
        /// Фон файла
        /// </summary>
        private void backgraundFile_Clik(object sender, EventArgs e)
        {
            var colorFile = new ColorDialog();
            if (colorFile.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            textBox.BackColor = colorFile.Color;
        }

        /// <summary>
        /// Подсчет символов
        /// </summary>
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            statusStripNotepad.Items[1].Text = textBox.Text.Length.ToString() + " символов";
            countCharacter += 1;
        }

        /// <summary>
        /// Расчет скорости печати
        /// </summary>
        private void timerSpeed_Tick(object sender, EventArgs e)
        {
            countCharacter *= 20;
            statusStripNotepad.Items[2].Text = countCharacter.ToString() + " зн./мин";
            countCharacter = 0;
        }

        /// <summary>
        /// Расчет позиции курсора
        /// </summary>
        private void cursorPosition()
        {
            var lineIndex = textBox.GetLineFromCharIndex(textBox.SelectionStart);
            var colIndex = textBox.SelectionStart - textBox.GetFirstCharIndexFromLine(lineIndex);
            statusStripNotepad.Items[0].Text = $"Столбец: {lineIndex + 1} Стока: {colIndex}";
        }

        /// <summary>
        /// Вывод позиции курсора
        /// </summary>
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            cursorPosition();
        }
    }
}
