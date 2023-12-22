using StudentManagementPrj.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagementPrj.ViewModel
{
    public class GradeViewModel:BaseViewModel
    {
        public struct AvailableClass
        {
            public int ClassID { get; set; }
            public string Grade { get; set; }
            public string Class { get; set; }
            public int NumofAttendants { get; set; }
            public string Teacher { get; set; }
        }
        public static AvailableClass CurrentSelected { get; set; }


        public ICommand navScoreTable { get; }
        public ICommand navCchangeColorlassListUC { get; }
        public ICommand dtGrid_ScrollChanged { get; }
        public ICommand getDetail { get; }
        public ICommand navInputscore { get; }
        public ICommand Detail { get; }


        private List<AvailableClass> _HomeroomList = new List<AvailableClass>();
        public List<AvailableClass> HomeroomList { get => _HomeroomList; set { _HomeroomList = value; OnPropertyChanged(); } }
        private List<AvailableClass> _TeachingList = new List<AvailableClass>();
        public List<AvailableClass> TeachingList { get => _TeachingList; set { _TeachingList = value; OnPropertyChanged(); } }

        private ObservableCollection<LOP> _ClassList;
        public ObservableCollection<LOP> ClassList { get => _ClassList; set { _ClassList = value; OnPropertyChanged(); } }
        private ObservableCollection<GIAOVIEN> _Teacher;
        public ObservableCollection<GIAOVIEN> Teacher { get => _Teacher; set { _Teacher = value; OnPropertyChanged(); } }
        private ObservableCollection<GIANGDAY> _Teaching;
        public ObservableCollection<GIANGDAY> Teaching { get => _Teaching; set { _Teaching = value; OnPropertyChanged(); } }

        private string _schoolYear;
        public string schoolYear { get => _schoolYear; set { _schoolYear = value; OnPropertyChanged(); } }
        private string _email;
        public string email { get => _email; set { _email = value; OnPropertyChanged(); } }
        private string _address;
        public string address { get => _address; set { _address = value; OnPropertyChanged(); } }
        private string _school;
        public string school { get => _school; set { _school = value; OnPropertyChanged(); } }
        private string _group;
        public string group { get => _group; set { _group = value; OnPropertyChanged(); } }
        private string _visLine1;
        public string visLine1 { get => _visLine1; set { _visLine1 = value; OnPropertyChanged(); } }
        private string _visLine2;
        public string visLine2 { get => _visLine2; set { _visLine2 = value; OnPropertyChanged(); } }
        private string _semester;
        public string semester { get => _semester; set { _semester = value; OnPropertyChanged(); } }

    }
}
