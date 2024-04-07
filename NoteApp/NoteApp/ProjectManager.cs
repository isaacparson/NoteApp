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
        }

        /// <summary>
        /// Загрузить проект, путь загрузки указан в закрытом поле класса
        /// </summary>
        /// <returns>Загруженный проект</returns>
        public static Project LoadProject()
        {
            string json = File.ReadAllText(path_);

            List<Note> notes = JsonSerializer.Deserialize<List<Note>>(json);

            return new Project(notes);

        }
    }
}
