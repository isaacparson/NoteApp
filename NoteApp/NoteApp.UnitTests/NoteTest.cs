using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NoteApp;

namespace NoteApp.UnitTests
{
    public class NoteTest
    {
        public void TestSetName_Incorrect_50()
        {
            Note note = new Note("", NoteCategory.Other, "");
            bool wasItThrow = false;
            try
            {
                note.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            }
            catch (ArgumentException)
            {
                wasItThrow = true;
            }
            Assert.Equals(wasItThrow, true);
        }

        public void TestSetName_Null()
        {
            Note note = new Note("", NoteCategory.Other, "");
            Assert.Equals(note.Name, "Без названия");
        }

        public void TestSetName()
        {
            Note note = new Note("Some name", NoteCategory.Other, "");
            Assert.Equals(note.Name, "Some name");
        }

        public void TestCategory()
        {
            Note note = new Note("Some name", NoteCategory.Other, "");
            Assert.Equals(note.Category, NoteCategory.Other);
        }

        public void TestText()
        {
            Note note = new Note("Some name", NoteCategory.Other, "Some text");
            Assert.Equals(note.Text, "Some text");
        }

        public void TestTimeOfCreation()
        {
            Note note = new Note("Some name", NoteCategory.Other, "");
            Assert.Equals(note.TimeOfCreation, DateTime.Now);
        }

        public void TestTimeOfModification()
        {
            Note note = new Note("Some name", NoteCategory.Other, "");
            Assert.Equals(note.TimeOfModification, DateTime.Now);
        }


    }


}
