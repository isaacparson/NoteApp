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
        private string path_ = "C:\\Users\\Dani\\Documents\\docs\\NoteApp.notes";
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

        private void FormNoteApp_Load(object sender, EventArgs e)
        {
            string[] categories = new string[8]{ "Работа",
                                                 "Дом",
                                                 "Здоровье и спорт",
                                                 "Люди",
                                                 "Документы",
                                                 "Финансы",
                                                 "Другое",
                                                 "Все"};
            comboBox1.Items.AddRange(categories);
            comboBox1.SelectedText = categories[7];

            var file = File.ReadAllText(path_);
            if (file.Length != 0)
            {
                project_ = ProjectManager.LoadProject();

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

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                Note currentNote = project_.GetNotes().ElementAt(listBox1.SelectedIndex);

                Header.Text = currentNote.Name;
                labelCategory.Text = Category(currentNote.Category);
                dateTimePickerCreated.Text = currentNote.TimeOfCreation;
                dateTimePickerModified.Text = currentNote.TimeOfModification;
                richTextBox.Text = currentNote.Text;
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            ProjectManager.SaveProject(project_);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Note currentNote = project_.GetNotes().ElementAt(listBox1.SelectedIndex);
            project_.GetNotes().Remove(currentNote);
            listBox1.Items.Remove(currentNote.Name);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Note currentNote = project_.GetNotes().ElementAt(listBox1.SelectedIndex);
            FormAddEdit form = new FormAddEdit(currentNote);
            form.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Все")
            {
                listBox1.Items.Clear();
                foreach (Note note in project_.GetNotes())
                {
                    listBox1.Items.Add(note.Name);
                }
            }
            else
            {
                var sortedNotes = project_.SortNotes(Category(comboBox1.SelectedItem.ToString()));

                listBox1.Items.Clear();
                foreach (Note note in sortedNotes)
                {
                    listBox1.Items.Add(note.Name);
                }
            }
        }
    }
}
