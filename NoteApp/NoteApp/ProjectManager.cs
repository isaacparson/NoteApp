using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс для сохранения и загрузки состояния проекта
    /// </summary>
    public static class ProjectManager
    {
        //private const string path_ = "C:\\Users\\Dani\\Documents\\docs\\NoteApp.notes";
        private const string path_ = "NoteApp.notes";


        /// <summary>
        /// Сохранить проект, путь сохранения указан в закрытом поле класса
        /// </summary>
        /// <param name="project"></param>
        public static void SaveProject(Project project)
        {
            var json = JsonSerializer.Serialize(project.GetNotes());
            File.WriteAllText(path_, json);
            var current = JsonSerializer.Serialize(project.CurrentNote);
            File.AppendAllText(path_, "\n");
            File.AppendAllText(path_, current);
        }

        /// <summary>
        /// Загрузить проект, путь загрузки указан в закрытом поле класса
        /// </summary>
        /// <returns>Загруженный проект</returns>
        public static Project LoadProject()
        {
            if (!File.Exists(path_))
            {
                File.Create(path_).Close();
            }

            var json = File.ReadLines(path_);

            if (json.Any())
            {
                List<Note> notes = JsonSerializer.Deserialize<List<Note>>(json.ElementAt(0));
                Project newProject = new Project(notes);
                Note current = JsonSerializer.Deserialize<Note>(json.ElementAt(1));
                newProject.CurrentNote = current;

                return newProject;
            }
            List<Note> notes2 = new List<Note> { };
            Project project = new Project(notes2);
            return project;



        }
    }
}
