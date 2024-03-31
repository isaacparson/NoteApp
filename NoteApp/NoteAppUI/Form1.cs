using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    public partial class FormNoteApp : Form
    {
        private string path_ = "C:\\Users\\Isaac\\OneDrive\\Документы\\docs\\NoteApp.notes";
        private Project project_;
        public FormNoteApp()
        {
            InitializeComponent();

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Note note = new Note("", NoteCategory.Other, "");
            FormAddEdit form = new FormAddEdit(note);
            form.ShowDialog();
            project_.AddNote(note);
            listBox1.Items.Add(note.Name);
        }

        private string Category(NoteCategory category)
        {
            switch (category)
            {
                case NoteCategory.Job: return "Работа";
                case NoteCategory.Home: return "Дом";
                case NoteCategory.HealthAndSprot: return "Здоровье и спорт";
                case NoteCategory.People: return "Люди";
                case NoteCategory.Docs: return "Документы";
                case NoteCategory.Finance: return "Финансы";
            }
            return "Другое";
        }

        private void FormNoteApp_Load(object sender, EventArgs e)
        {
            var file = File.ReadAllText(path_);
            if (file.Length != 0)
            {
                project_ = ProjectManager.LoadProject();

                string[] categories = new string[7]{ "Работа", 
                                                     "Дом",
                                                     "Здоровье и спорт",
                                                     "Люди",
                                                     "Документы",
                                                     "Финансы",
                                                     "Другое" };
                comboBox1.Items.AddRange(categories);

                foreach (Note note in project_.GetNotes())
                {
                    listBox1.Items.Add(note.Name);
                }
            }
            else
            {
                List<Note> list = new List<Note>();
                project_ = new Project(list);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Note currentNote = project_.GetNotes().ElementAt(listBox1.SelectedIndex);

            Header.Text = currentNote.Name;
            labelCategory.Text = Category(currentNote.Category);
            dateTimePickerCreated.Text = currentNote.TimeOfCreation;
            dateTimePickerModified.Text = currentNote.TimeOfModification;
            richTextBox.Text = currentNote.Text;
        }
    }
}
