using StudentManagementPrj.Commands;
using StudentManagementPrj.Model;
using StudentManagementPrj.Store;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;
using StudentManagementPrj.ViewUCs;

namespace StudentManagementPrj.ViewModel
{
    public class AddStudentPro5ViewModel : BaseViewModel
    {
        private string _TenCha;
        public string TenCha { get => _TenCha; set { _TenCha = value; OnPropertyChanged(); } }
        private string _NgheCha;
        public string NgheCha { get => _NgheCha; set { _NgheCha = value; OnPropertyChanged(); } }
        private string _SDTCha;
        public string SDTCha { get => _SDTCha; set { _SDTCha = value; OnPropertyChanged(); } }
        private string _TenMe;
        public string TenMe { get => _TenMe; set { _TenMe = value; OnPropertyChanged(); } }
        private string _NgheMe;
        public string NgheMe { get => _NgheMe; set { _NgheMe = value; OnPropertyChanged(); } }
        private string _SDTMe;
        public string SDTMe { get => _SDTMe; set { _SDTMe = value; OnPropertyChanged(); } }
        private string _MaHS;
        public string MaHS { get => _MaHS; set { _MaHS = value; OnPropertyChanged(); } }
        private string _Lop;
        public string Lop { get => _Lop; set { _Lop = value; OnPropertyChanged(); } }
        private string _ChinhSach;
        public string ChinhSach { get => _ChinhSach; set { _ChinhSach = value; OnPropertyChanged(); } }
        private string _HoTen;
        public string HoTen { get => _HoTen; set { _HoTen = value; OnPropertyChanged(); } }
        private string _NgaySinh;
        public string NgaySinh { get => _NgaySinh; set { _NgaySinh = value; OnPropertyChanged(); } }
        private string _NoiSinh;
        public string NoiSinh { get => _NoiSinh; set { _NoiSinh = value; OnPropertyChanged(); } }
        private string _SDT;
        public string SDT { get => _SDT; set { _SDT = value; OnPropertyChanged(); } }
        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }
        private string _GioiTinh;
        public string GioiTinh { get => _GioiTinh; set { _GioiTinh = value; OnPropertyChanged(); } }
        private string _DanToc;
        public string DanToc { get => _DanToc; set { _DanToc = value; OnPropertyChanged(); } }
        private string _TonGiao;
        public string TonGiao { get => _TonGiao; set { _TonGiao = value; OnPropertyChanged(); } }
        private string _Ava;
        public string Ava { get => _Ava; set { _Ava = value; OnPropertyChanged(); } }
        public string[] GTList { get; set; } = { "Nam", "Nữ" };
        public string[] ClassList { get; set; }

        public ICommand navBack { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateAva { get; set; }

        public AddStudentPro5ViewModel(NavigationStore navigationStore)
        {
            //navigate
            navBack = new NavigationCommand<ClassListViewModel>(navigationStore, () => new ClassListViewModel(navigationStore));

            // update ava
            UpdateAva = new RelayCommand<Image>((p) => { return true; }, (p) => _updateAva(p));

            //classList
            var classList = DataProvider.Ins.DB.LOPs.Where(x => x.DELETED == false).ToList();
            ClassList = new string[classList.Count()];
            for (int i = 0; i < classList.Count(); i++)
                ClassList[i] = classList[i].TENLOP.ToString();

            //value 
            MaHS = " ";
            HoTen = " ";
            NgaySinh = " ";
            GioiTinh = "Nam";
            NoiSinh = " ";
            DanToc = " ";
            TonGiao = " ";
            SDT = " ";
            DiaChi = " ";
            ChinhSach = " ";
            Ava = " ";
            Lop = " ";

            TenCha = " ";
            TenMe = " ";
            NgheCha = " ";
            NgheMe = " ";
            SDTCha = " ";
            SDTMe = " ";

            //HOCSINH newStd = new HOCSINH();
            //newStd.HOTEN = HoTen;
            //newStd.NTNS = DateTime.Parse(NgaySinh);
            //newStd.NOISINH = NoiSinh;
            //newStd.DANTOC = DanToc;
            //newStd.TONGIAO = TonGiao;
            //newStd.SDT = SDT;
            //newStd.DIACHI = DiaChi;
            //newStd.CHINHSACH = ChinhSach;
            //if (GioiTinh == "Nam")
            //    newStd.GIOITINH = false;
            //else newStd.GIOITINH = true;
            //newStd.AVA = Ava;

            //PHUHUYNH newPh = new PHUHUYNH();
            //newPh.HOTENBO = TenCha;
            //newPh.HOTENME = TenMe;
            //newPh.NGHEBO = NgheCha;
            //newPh.NGHEME = NgheMe;
            //newPh.SDTBO = SDTCha;
            //newPh.SDTME = SDTMe;
            //var ht = DataProvider.Ins.DB.HOCTAPs.Where(x => x.MAHS == ClassListViewModel.CurrentSelected.ID && x.DELETED == false).SingleOrDefault();
            //var lop = DataProvider.Ins.DB.LOPs.Where(x => x.DELETED == false && x.TENLOP == Lop).SingleOrDefault().MALOP;
            //ht.MALOP = lop; 

            //Add command
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (String.IsNullOrEmpty(HoTen) || String.IsNullOrEmpty(NgaySinh) || String.IsNullOrEmpty(NoiSinh) || String.IsNullOrEmpty(DanToc) || String.IsNullOrEmpty(TonGiao) || String.IsNullOrEmpty(SDT) || String.IsNullOrEmpty(DiaChi) || String.IsNullOrEmpty(TenCha) || String.IsNullOrEmpty(TenMe) || String.IsNullOrEmpty(NgheCha) || String.IsNullOrEmpty(NgheMe) || String.IsNullOrEmpty(SDTCha) || String.IsNullOrEmpty(SDTMe))
                {
                    MessageBox.Show("Bạn phải điền đầy đủ thông tin!");
                    return false;
                }
                return true;
            }, (p) =>
            {
                //var std = DataProvider.Ins.DB.HOCSINHs.Where(x => x.MAHS == ClassListViewModel.CurrentSelected.ID && x.DELETED == false).SingleOrDefault();
                //std.HOTEN = HoTen;
                //std.NTNS = DateTime.Parse(NgaySinh);
                //std.NOISINH = NoiSinh;
                //std.DANTOC = DanToc;
                //std.TONGIAO = TonGiao;
                //std.SDT = SDT;
                //std.DIACHI = DiaChi;
                //std.CHINHSACH = ChinhSach;
                //if (GioiTinh == "Nam")
                //    std.GIOITINH = false;
                //else std.GIOITINH = true;
                //std.AVA = Ava;

                //var phhs = DataProvider.Ins.DB.PHUHUYNHs.Where(x => x.MAHS == ClassListViewModel.CurrentSelected.ID && x.DELETED == false).SingleOrDefault();
                //phhs.HOTENBO = TenCha;
                //phhs.HOTENME = TenMe;
                //phhs.NGHEBO = NgheCha;
                //phhs.NGHEME = NgheMe;
                //phhs.SDTBO = SDTCha;
                //phhs.SDTME = SDTMe;

                //var ht = DataProvider.Ins.DB.HOCTAPs.Where(x => x.MAHS == ClassListViewModel.CurrentSelected.ID && x.DELETED == false).SingleOrDefault();
                //var lop = DataProvider.Ins.DB.LOPs.Where(x => x.DELETED == false && x.TENLOP == Lop).SingleOrDefault().MALOP;
                //ht.MALOP = lop;

                HOCSINH newStd = new HOCSINH();
                newStd.HOTEN = HoTen;
                newStd.NTNS = DateTime.Parse(NgaySinh);
                newStd.NOISINH = NoiSinh;
                newStd.DANTOC = DanToc;
                newStd.TONGIAO = TonGiao;
                newStd.SDT = SDT;
                newStd.DIACHI = DiaChi;
                newStd.CHINHSACH = ChinhSach;
                if (GioiTinh == "Nam")
                    newStd.GIOITINH = false;
                else newStd.GIOITINH = true;
                newStd.AVA = Ava;
                newStd.DELETED = false;
                DataProvider.Ins.DB.HOCSINHs.Add(newStd);
                //
                PHUHUYNH newPh = new PHUHUYNH();
                newPh.HOTENBO = TenCha;
                newPh.HOTENME = TenMe;
                newPh.NGHEBO = NgheCha;
                newPh.NGHEME = NgheMe;
                newPh.SDTBO = SDTCha;
                newPh.SDTME = SDTMe;
                newPh.DELETED = false;
                DataProvider.Ins.DB.PHUHUYNHs.Add(newPh);
                DataProvider.Ins.DB.SaveChanges();
                //
                var currentStd = DataProvider.Ins.DB.HOCSINHs.SqlQuery("SELECT TOP 1 * FROM HOCSINH ORDER BY MAHS DESC;").SingleOrDefault();
                var lop = DataProvider.Ins.DB.LOPs.Where(x => x.DELETED == false && x.TENLOP == Lop).SingleOrDefault().MALOP;
                HOCTAP newHt = new HOCTAP();
                newHt.MALOP = lop;
                newHt.MAHS = currentStd.MAHS;
                newHt.DELETED = false;
                DataProvider.Ins.DB.HOCTAPs.Add(newHt);
                var currentLop = DataProvider.Ins.DB.LOPs.Where(x => x.DELETED == false && x.TENLOP == Lop).SingleOrDefault();
                currentLop.SISO++;
                MessageBox.Show("Lưu thông tin thành công!");
                DataProvider.Ins.DB.SaveChanges();
            });

        }
        void _updateAva(Image p)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.png)|*.jpg; *.png";
            if (open.ShowDialog() == true)
            {
                var linkImg = open.FileName;
                p.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(linkImg);
                Ava = linkImg.ToString();
            }
        }
    }
}
