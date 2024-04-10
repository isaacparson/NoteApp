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
        private const string path_ = "C:\\Users\\Isaac\\OneDrive\\Документы\\docs\\NoteApp.notes";

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

            List<Note> notes = JsonSerializer.Deserialize<List<Note>>(json.ElementAt(0));
            Note current = JsonSerializer.Deserialize<Note>(json.ElementAt(1));
            Project newProject = new Project(notes);
            newProject.CurrentNote = current;

            return newProject;

        }
    }
}
