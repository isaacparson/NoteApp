using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NUnit.Compatibility;
using NoteApp;
using NUnit.Framework.Legacy;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTest
    {
        [Test]
        public void TestSetName_Incorrect_50()
        {
            Note note = new Note("", NoteCategory.Other, "");
            bool wasItThrow = false;
            try
            {
                note.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            }
            catch (ArgumentException)
            {
                wasItThrow = true;
            }
            ClassicAssert.AreEqual(wasItThrow, true);
        }

        [Test]
        public void TestSetName_Null()
        {
            Note note = new Note("", NoteCategory.Other, "");
            ClassicAssert.AreEqual(note.Name, "Без названия");
        }

        [Test]
        public void TestSetName()
        {
            Note note = new Note("Some name", NoteCategory.Other, "");
            ClassicAssert.AreEqual(note.Name, "Some name");
        }

        [Test]
        public void TestCategory()
        {
            Note note = new Note("Some name", NoteCategory.Other, "");
            ClassicAssert.AreEqual(note.Category, NoteCategory.Other);
        }

        [Test]
        public void TestText()
        {
            Note note = new Note("Some name", NoteCategory.Other, "Some text");
            ClassicAssert.AreEqual(note.Text, "Some text");
        }

        [Test]
        public void TestTimeOfCreation()
        {
            Note note = new Note("Some name", NoteCategory.Other, "");
            ClassicAssert.AreEqual(note.TimeOfCreation, DateTime.Now.ToString());
        }

        [Test]
        public void TestTimeOfModification()
        {
            Note note = new Note("Some name", NoteCategory.Other, "");
            ClassicAssert.AreEqual(note.TimeOfModification, DateTime.Now.ToString());
        }


    }


}
