using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagementPrj.ViewModel
{
    public class EditScoreViewModel:BaseViewModel
    {
        public struct scoreTable
        {
            public int subjectID { get; set; }
            public string subject { get; set; }
            //public string[] otherScore { get; set; }  //1: mieng, 2: thi, 3: tbhk
            //public string[] min15 { get; set; }
            //public string[] min45 { get; set; }
            public string[] score { get; set; }

        }


        public struct scoreTable_Year
        {
            public int subjectID { get; set; }
            public string subject { get; set; }
            //public string avg_1 { get; set; }
            //public string avg_2 { get; set; }
            public string[] avg { get; set; }
            public string avg_Year { get; set; }

        }
        //commnand
        public ICommand navBack { get; }
        public ICommand navEdit { get; }
        public ICommand changeScoreTb { get; }
        public ICommand EditCommand { get; }
        public ICommand showMessage { get; }


        //List
        private List<scoreTable> _scoreTableList = new List<scoreTable>();
        public List<scoreTable> scoreTableList { get => _scoreTableList; set { _scoreTableList = value; OnPropertyChanged(); } }
        private List<scoreTable_Year> _scoreTableList_Year = new List<scoreTable_Year>();
        public List<scoreTable_Year> scoreTableList_Year { get => _scoreTableList_Year; set { _scoreTableList_Year = value; OnPropertyChanged(); } }

        //variable binding
        private string _studentName;
        public string studentName { get => _studentName; set { _studentName = value; OnPropertyChanged(); } }
        private string _className;
        public string className { get => _className; set { _className = value; OnPropertyChanged(); } }
        private string _formTeacher;
        public string formTeacher { get => _formTeacher; set { _formTeacher = value; OnPropertyChanged(); } }

        private string _schoolYear;
        public string schoolYear { get => _schoolYear; set { _schoolYear = value; OnPropertyChanged(); } }

        //0: ca nam, 1: hk1, 2: hk2
        private int _semester;
        public int semester { get => _semester; set { _semester = value; OnPropertyChanged(); } }
        private string _avgSemester;
        public string avgSemester { get => _avgSemester; set { _avgSemester = value; OnPropertyChanged(); } }
        private string _conduct;
        public string conduct { get => _conduct; set { _conduct = value; OnPropertyChanged(); } }
        private string _rank;
        public string rank { get => _rank; set { _rank = value; OnPropertyChanged(); } }
        private string _achievements;
        public string achievements { get => _achievements; set { _achievements = value; OnPropertyChanged(); } }
        private string _comment;
        public string comment { get => _comment; set { _comment = value; OnPropertyChanged(); } }

        private int _cbbSelected;
        public int cbbSelected { get => _cbbSelected; set { _cbbSelected = value; OnPropertyChanged(); } }
    }

}
