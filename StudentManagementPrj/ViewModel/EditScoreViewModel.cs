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
    }
}
