using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class FormAddEdit : Form
    {
        private Note remoteNote_;
        public FormAddEdit(Note note)
        {
            InitializeComponent();
            remoteNote_ = note;
        }

        private string[] categories = new string[7]{ "Работа",
                                                     "Дом",
                                                     "Здоровье и спорт",
                                                     "Люди",
                                                     "Документы",
                                                     "Финансы",
                                                     "Другое" };

        private void FormAddEdit_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.AddRange(categories);


            textBoxTitle.Text = remoteNote_.Name;
            comboBoxCategory.SelectedIndex = ((int)remoteNote_.Category);
            richTextBox1.Text = remoteNote_.Text;
        }

        private NoteCategory Category(string category)
        {
            switch (category)
            {
                case "Работа": return NoteCategory.Job;
                case "Дом": return NoteCategory.Home;
                case "Здоровье и спорт": return NoteCategory.HealthAndSprot;
                case "Люди": return NoteCategory.People;
                case "Документы": return NoteCategory.Docs;
                case "Финансы": return NoteCategory.Finance;
            }
            return NoteCategory.Other;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                remoteNote_.Name = textBoxTitle.Text;
                remoteNote_.Category = Category(comboBoxCategory.Text);
                remoteNote_.Text = richTextBox1.Text;

                this.Close();
            }
            catch
            {
                textBoxTitle.Text = "Слишком длинное название!!!";
            }
        }
    }
}
