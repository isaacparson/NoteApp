using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.UnitTests
{
    internal class ProjectManagerTest
    {
        public void TestSaveLoadProject()
        {
            Note note = new Note("name", NoteCategory.Other, "");
            note.TimeOfModification = (new DateTime(2024, 4, 7, 10, 0, 0)).ToString();

            Note note2 = new Note("name2", NoteCategory.Other, "");
            note2.TimeOfModification = (new DateTime(2024, 4, 7, 11, 0, 0)).ToString();

            List<Note> list = new List<Note> { note2, note };
            Project project = new Project(list);

            ProjectManager.SaveProject(project);

            var loadedProject = ProjectManager.LoadProject();

            Assert.Equals(loadedProject, project);
        }
    }
}
