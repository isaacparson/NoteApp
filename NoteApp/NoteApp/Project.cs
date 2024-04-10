using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Класс проекта, позволяет работать со списком заметок
    /// </summary>
    public class Project
    {
        private List<Note> notes_;
        private Note currentNote_;

        public Note CurrentNote
        { 
            get 
            { 
                return currentNote_; 
            }
            set 
            {
                currentNote_ = value;
            }
        }

        private static int CompareNotes(Note n1, Note n2)
        {
            return n2.TimeOfModification.CompareTo(n1.TimeOfModification);
        }

        public List<Note> GetNotes() 
        {  
            return notes_; 
        }

        public void AddNote( Note note )
        {
            notes_.Add( note );
        }

        public Project(List<Note> notes)
        {
            notes_ = notes;
        }

        public List<Note> SortNotes()
        {
            notes_.Sort( CompareNotes );
            return notes_;
        }

        /// <summary>
        /// Отсортировать заметки с нужной категорией по времени изменения 
        /// </summary>
        /// <param name="category">Категория заметок для сортировки</param>
        /// <returns>Отсортированный список заметок</returns>
        public List<Note> SortNotes( NoteCategory category )
        {
            var notes = new List<Note>();

            foreach( Note note in notes_ )
            {
                if(note.Category == category)
                {
                    notes.Add( note );
                }
            }


            if (notes.Count == 0)
            {
                return notes;
            }

            notes.Sort( CompareNotes );
            return notes;
        }
    }
}
