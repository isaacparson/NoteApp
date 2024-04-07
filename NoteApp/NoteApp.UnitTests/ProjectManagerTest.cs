using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Compatibility;
using NUnit.Framework.Legacy;
using NoteApp;

namespace NoteApp.UnitTests
{
    [TestFixture]
    internal class ProjectManagerTest
    {
        [Test]
        public void TestSaveLoadProject()
        {
            List<Note> list = new List<Note>();
            Note note = new Note("name", NoteCategory.Other, "");
            list.Add(note);

            Project project = new Project(list);
            ProjectManager.SaveProject(project);

            var loadedProject = ProjectManager.LoadProject();
            ClassicAssert.AreEqual(loadedProject.GetNotes()[0].Name, project.GetNotes()[0].Name);
        }
    }
}
