using System;
using System.Collections.Generic;
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



    }
}
