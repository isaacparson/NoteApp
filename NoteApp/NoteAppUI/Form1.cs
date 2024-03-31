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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var people = NoteCategory.People;

            var sonia = new Note("Соня", people, "Очень хороший человек");
            var kirill = new Note("Кирилл", people, "Тоже очень хороший человек");
            var vova = new Note("Вова", people, "Очень хороший повар");
            var laba = new Note("Лаба 2", NoteCategory.Docs, "Норм лаба");

            List<Note> notes = new List<Note> { sonia, kirill, vova, laba };

            Project project = new Project(notes);

            var sortedPeople = project.SortNotes(people);

            label1.Text = "People: ";

            foreach ( Note note in sortedPeople )
            {
                label1.Text += note.Name + " ";
            }

            ProjectManager.SaveProject( project );
            var deserializedProject = ProjectManager.LoadProject();

            var deserializedNotes = deserializedProject.GetNotes();

            label2.Text = "Deserialized project: ";

            foreach ( Note note in deserializedNotes)
            {
                label2.Text += note.Name + " ";
            }
        }
    }
}
