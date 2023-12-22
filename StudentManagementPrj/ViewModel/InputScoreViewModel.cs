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
    public class InputScoreViewModel:BaseViewModel
    {
        public struct StudentScore
        {
            public int number { get; set; }
            public int studentID { get; set; }
            public string name { get; set; }
            public string[] score { get; set; }
        }

        public ICommand navBack { get; }
        public ICommand InputCommand { get; }
        //public ICommand changeDtgYear { get; }
        public ICommand changeDtgSub { get; }
        public ICommand InputCommnand { get; }
        public ICommand LoadUC { get; }


        private int _semester;
        public int semester { get => _semester; set { _semester = value; OnPropertyChanged(); } }

        private string _Title;
        public string Title { get => _Title; set { _Title = value; OnPropertyChanged(); } }
        private string _schoolYear;
        public string schoolYear { get => _schoolYear; set { _schoolYear = value; OnPropertyChanged(); } }
        private string _formTeacher;
        public string formTeacher { get => _formTeacher; set { _formTeacher = value; OnPropertyChanged(); } }
        private string _teachingTeacher;
        public string teachingTeacher { get => _teachingTeacher; set { _teachingTeacher = value; OnPropertyChanged(); } }
        private string _AmountSt;
        public string AmountSt { get => _AmountSt; set { _AmountSt = value; OnPropertyChanged(); } }
        private int _cbbSelected;
        public int cbbSelected { get => _cbbSelected; set { _cbbSelected = value; OnPropertyChanged(); } }
        private string _searchText;
        public string searchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged("searchText");
                OnPropertyChanged("MyFilterListSemester");
                OnPropertyChanged("MyFilterListYear");
            }
        }

        public IEnumerable<StudentScore> MyFilterListSemester
        {
            get
            {
                if (searchText == null || searchText == "")
                    return StudentScoreList;
                else
                    return StudentScoreList.Where(x => (x.name.ToUpper().Contains(searchText.ToUpper())));

            }
        }


        private List<StudentScore> _StudentScoreList = new List<StudentScore>();
        public List<StudentScore> StudentScoreList { get => _StudentScoreList; set { _StudentScoreList = value; OnPropertyChanged(); } }
        private ObservableCollection<HOCTAP> _LearningList;
        public ObservableCollection<HOCTAP> LearningList { get => _LearningList; set { _LearningList = value; OnPropertyChanged(); } }

        private ObservableCollection<THI> _TestList;
        public ObservableCollection<THI> TestList { get => _TestList; set { _TestList = value; OnPropertyChanged(); } }
        private ObservableCollection<TBMON> _avgSubList;
        public ObservableCollection<TBMON> avgSubList { get => _avgSubList; set { _avgSubList = value; OnPropertyChanged(); } }
        private ObservableCollection<KETQUA> _resultList;
        public ObservableCollection<KETQUA> resultList { get => _resultList; set { _resultList = value; OnPropertyChanged(); } }
        private ObservableCollection<GIANGDAY> _teachingList;
        public ObservableCollection<GIANGDAY> teachingList { get => _teachingList; set { _teachingList = value; OnPropertyChanged(); } }
    }
}
