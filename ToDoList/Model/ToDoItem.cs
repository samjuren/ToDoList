using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoList.Model
{
    [Table("ToDoList")]
    public class ToDoItem : INotifyPropertyChanged
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        private string? title;
        public string? Title 
        { 
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            } 
        }

        private string? description;
        public string? Description 
        { 
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            } 
        }

        private bool isConcluded;
        public bool IsConcluded
        {
            get => isConcluded;
            set 
            {
                isConcluded = value;
                OnPropertyChanged();
            }
        }
        private string? status;
        public string? Status 
        { 
            get => status;
            set
            {
                status = value;
                OnPropertyChanged();
            } 
        }
        
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
