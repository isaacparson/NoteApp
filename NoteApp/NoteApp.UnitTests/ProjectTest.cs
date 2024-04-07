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

        }
    }
}
