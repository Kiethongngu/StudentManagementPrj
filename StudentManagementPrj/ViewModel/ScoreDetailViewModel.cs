using StudentManagementPrj.Commands;
using StudentManagementPrj.Model;
using StudentManagementPrj.Store;
using StudentManagementPrj.ViewUCs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentManagementPrj.ViewModel
{
    public class ScoreDetailViewModel:BaseViewModel
    {
        //struct
        public struct scoreTable
        {
            public string subject { get; set; }
            public string mieng { get; set; }
            public string min15_1 { get; set; }
            public string min15_2 { get; set; }
            public string min15_3 { get; set; }
            public string min45_1 { get; set; }
            public string min45_2 { get; set; }
            public string test { get; set; }
            public string avg { get; set; }

        }
        public struct scoreTable_Year
        {
            public string subject { get; set; }
            public string avg_1 { get; set; }
            public string avg_2 { get; set; }
            public string avg_Year { get; set; }

        }
        //commnand
        public ICommand navBack { get; }
        public ICommand navEdit { get; }
        public ICommand changeScoreTb { get; }


        //List
        private List<scoreTable> _scoreTableList = new List<scoreTable>();
        public List<scoreTable> scoreTableList { get => _scoreTableList; set { _scoreTableList = value; OnPropertyChanged(); } }
        private List<scoreTable_Year> _scoreTableList_Year = new List<scoreTable_Year>();
        public List<scoreTable_Year> scoreTableList_Year { get => _scoreTableList_Year; set { _scoreTableList_Year = value; OnPropertyChanged(); } }


        //variable binding
        private string _name;
        public string name { get => _name; set { _name = value; OnPropertyChanged(); } }
        private string _className;
        public string className { get => _className; set { _className = value; OnPropertyChanged(); } }
        private string _formTeacher;
        public string formTeacher { get => _formTeacher; set { _formTeacher = value; OnPropertyChanged(); } }

        private string _schoolYear;
        public string schoolYear { get => _schoolYear; set { _schoolYear = value; OnPropertyChanged(); } }

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
        private ObservableCollection<MONHOC> _subjectList;
        public ObservableCollection<MONHOC> subjectList { get => _subjectList; set { _subjectList = value; OnPropertyChanged(); } }

        private ObservableCollection<THI> _testList;
        public ObservableCollection<THI> testList { get => _testList; set { _testList = value; OnPropertyChanged(); } }
        private ObservableCollection<TBMON> _avgList;
        public ObservableCollection<TBMON> avgList { get => _avgList; set { _avgList = value; OnPropertyChanged(); } }

        public ScoreDetailViewModel(NavigationStore navigationStore)
        {
            SemesterScoreViewModel.selectedStudent selectedStuddent = SemesterScoreViewModel.CurrentSelected;

            //navigate
            navBack = new NavigationCommand<SemesterScoreViewModel>(navigationStore, () => new SemesterScoreViewModel(navigationStore));
            navEdit = new NavigationCommand<EditScoreViewModel>(navigationStore, () => new EditScoreViewModel(navigationStore));

            //infor
            name = DataProvider.Ins.DB.HOCSINHs.Where(x => x.MAHS == selectedStuddent.mahs && x.DELETED == false).FirstOrDefault().HOTEN;
            var tempClass = DataProvider.Ins.DB.LOPs.Where(x => x.MALOP == selectedStuddent.malop && x.DELETED == false).FirstOrDefault();
            className = tempClass.TENLOP;
            formTeacher = DataProvider.Ins.DB.GIAOVIENs.Where(x => x.MAGV == tempClass.GVCN && x.DELETED == false).FirstOrDefault().HOTEN;
            schoolYear = "NIÊN KHÓA " + Const.SchoolYear;
            semester = 1;

            //list
            subjectList = new ObservableCollection<MONHOC>(DataProvider.Ins.DB.MONHOCs.Where(x => x.DELETED == false));
            testList = new ObservableCollection<THI>(DataProvider.Ins.DB.THIs.Where(x => x.DELETED == false));
            avgList = new ObservableCollection<TBMON>(DataProvider.Ins.DB.TBMONs.Where(x => x.DELETED == false));

            //datagrid
            _UpdateScoreTable(selectedStuddent.mahs, selectedStuddent.malop);
            _UpdateScoreTable_Year(selectedStuddent.mahs, selectedStuddent.malop);

            //changeCbb
            changeScoreTb = new RelayCommand<ScoreDetail>((p) => { return true; }, (p) => _cbbChanged(p, selectedStuddent.mahs, selectedStuddent.malop));

        }
    }
}
