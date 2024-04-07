using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    internal class ProjectTest
    {
        public void TestNotes()
        {
            Note note = new Note("name", NoteCategory.Other, "");
            List<Note> list = new List<Note> { note };
            Project project = new Project(list);

            var stillThatList = project.GetNotes();
            Assert.Equals(list, stillThatList);
        }

        public void TestAddNote()
        {
            Note note = new Note("name", NoteCategory.Other, "");
            List<Note> list = new List<Note> { note };
            Project project = new Project(list);

            Note otherNote = new Note("other", NoteCategory.Other, "");
            project.AddNote(otherNote);
            Assert.Equals(project.GetNotes()[1], otherNote);
        }

        public void TestSortNotes1()
        {
            Note note = new Note("name", NoteCategory.Other, "");
            note.TimeOfModification = (new DateTime(2024, 4, 7, 10, 0, 0)).ToString();

            Note note2 = new Note("name2", NoteCategory.Other, "");
            note2.TimeOfModification = (new DateTime(2024, 4, 7, 11, 0, 0)).ToString();

            List<Note> list = new List<Note> { note2, note };
            Project project = new Project(list);

            List<Note> correctList = new List<Note> { note, note2 };

            Assert.Equals( project.SortNotes(), correctList );
        }

        public void TestSortNotes2()
        {
            Note note = new Note("name", NoteCategory.Job, "");
            note.TimeOfModification = (new DateTime(2024, 4, 7, 10, 0, 0)).ToString();

            Note note2 = new Note("name2", NoteCategory.Home, "");
            note2.TimeOfModification = (new DateTime(2024, 4, 7, 11, 0, 0)).ToString();

            List<Note> incorrectList = new List<Note> { note2, note };
            Project project = new Project(incorrectList);

            List<Note> correctList = new List<Note> { note };
            Assert.Equals(correctList, project.SortNotes(NoteCategory.Job));
        }

        public void TestSortNotes3()
        {
            List<Note> voidList = new List<Note>();

            Project project = new Project(voidList);
            Assert.Equals( project.SortNotes(NoteCategory.Job), voidList );
        }
    }
}
