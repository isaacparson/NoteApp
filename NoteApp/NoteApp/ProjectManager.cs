//using Newtonsoft.Json;
//using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс для сохранения и загрузки состояния проекта
    /// </summary>
    public static class ProjectManager
    {
        private const string path_ = "C:\\Users\\Dani\\Documents\\docs\\NoteApp.notes";

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
