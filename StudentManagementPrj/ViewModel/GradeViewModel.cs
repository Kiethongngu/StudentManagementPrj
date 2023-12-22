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
    }
}
