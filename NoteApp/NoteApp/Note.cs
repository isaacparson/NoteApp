using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace NoteApp
{
    /// <summary>
    /// Класс Заметка для хранения разной информации
    /// </summary>
    public class Note
    {
        private string name_;
        private NoteCategory category_;
        private string text_;

        /// <summary>
        /// Время создания заметки, заполняется автоматически
        /// </summary>
        private string timeOfCreation_;

        /// <summary>
        /// Время изменения заметки, заполняется автоматически
        /// </summary>
        private string timeOfModification_;

        public Note( string name, NoteCategory category, string text )
        {
            Name = name;
            Category = category;
            Text = text;
            TimeOfCreation = DateTime.Now.ToString();
            TimeOfModification = DateTime.Now.ToString();
        }

        public string Name
        {
            get
            {
                return name_;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException();
                }
                if (value.Length == 0)
                {
                    name_ = "Без названия";
                }
                else
                {
                    name_ = value;
                }
                
                timeOfModification_ = DateTime.Now.ToString();
            }
        }

        public NoteCategory Category
        {
            get
            {
                return category_;
            }
            set
            {
                category_ = value;
                timeOfModification_ = DateTime.Now.ToString();
            }
        }

        public string Text
        {
            get
            {
                return text_;
            }
            set
            {
                text_ = value;
                timeOfModification_ = DateTime.Now.ToString();
            }
        }

        public string TimeOfCreation
        {
            get
            {
                return timeOfCreation_;
            }
            set
            {
                timeOfCreation_ = value;
            }
        }

        public string TimeOfModification
        {
            get
            {
                return timeOfModification_;
            }
            set
            {
                timeOfModification_ = value;
            }
        }
    }
}
