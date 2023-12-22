using StudentManagementPrj.Commands;
using StudentManagementPrj.Model;
using StudentManagementPrj.Store;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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

        public struct Subject
        {
            public string name { get; set; }
        }
        //private List<Subject> _SubjectList = new List<Subject>();
        //public List<Subject> SubjectList { get => _SubjectList; set { _SubjectList = value; OnPropertyChanged(); } }
        private ObservableCollection<MONHOC> _subjectList;
        public ObservableCollection<MONHOC> subjectList { get => _subjectList; set { _subjectList = value; OnPropertyChanged(); } }

        private ObservableCollection<THI> _testList;
        public ObservableCollection<THI> testList { get => _testList; set { _testList = value; OnPropertyChanged(); } }
        private ObservableCollection<TBMON> _avgList;
        public ObservableCollection<TBMON> avgList { get => _avgList; set { _avgList = value; OnPropertyChanged(); } }

        private ObservableCollection<GIANGDAY> _teachingList;
        public ObservableCollection<GIANGDAY> teachingList { get => _teachingList; set { _teachingList = value; OnPropertyChanged(); } }


        public EditScoreViewModel(NavigationStore navigationStore)
        {
            SemesterScoreViewModel.selectedStudent selectedStuddent = SemesterScoreViewModel.CurrentSelected;

            //navigate
            navBack = new NavigationCommand<ScoreDetailViewModel>(navigationStore, () => new ScoreDetailViewModel(navigationStore));

            //infor
            studentName = DataProvider.Ins.DB.HOCSINHs.Where(x => x.MAHS == selectedStuddent.mahs && x.DELETED == false).FirstOrDefault().HOTEN;
            var tempClass = DataProvider.Ins.DB.LOPs.Where(x => x.MALOP == selectedStuddent.malop && x.DELETED == false).FirstOrDefault();
            className = tempClass.TENLOP;
            formTeacher = DataProvider.Ins.DB.GIAOVIENs.Where(x => x.MAGV == tempClass.GVCN && x.DELETED == false).FirstOrDefault().HOTEN;
            schoolYear = "NIÊN KHÓA " + Const.SchoolYear;
            semester = Const.Semester;

            //list
            subjectList = new ObservableCollection<MONHOC>(DataProvider.Ins.DB.MONHOCs.Where(x => x.DELETED == false));
            testList = new ObservableCollection<THI>(DataProvider.Ins.DB.THIs.Where(x => x.DELETED == false));
            avgList = new ObservableCollection<TBMON>(DataProvider.Ins.DB.TBMONs.Where(x => x.DELETED == false));
            teachingList = new ObservableCollection<GIANGDAY>(DataProvider.Ins.DB.GIANGDAYs.Where(x => x.DELETED == false));

            //datagrid
            _UpdateScoreTable(selectedStuddent.mahs, selectedStuddent.malop);
            _UpdateScoreTable_Year(selectedStuddent.mahs, selectedStuddent.malop);

            //changeCbb
            //changeScoreTb = new RelayCommand<EditScore>((p) => { return true; }, (p) => _cbbChanged(p, selectedStuddent.mahs, selectedStuddent.malop));
            //showMessage = new RelayCommand<EditScore>((p) => { return true; }, (p) => { MessageBoxResult result = MessageBox.Show("Thông tin chưa được lưu.", "Confirmation"); });

            //Edit
            EditCommand = new RelayCommand<DataGrid>((p) =>
            {
                return true;

            }, (p) => _EditSave(p, selectedStuddent.mahs, selectedStuddent.malop));
        }
    }

}
