using Project_PTUD_Desktop.ModelEntity.EntityDAO;
using Project_PTUD_Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.ModelEntity.EntityDTO
{
    public class FilmDTO : BaseViewModel
    {
        private string _maPhim;
        private string _tenPhim;
        private int _thoiLuong;
        private TheLoai _theLoaiChinh;
        private string _chuoiTenTheLoaiPhu;

        public string MaPhim { get => _maPhim; set { _maPhim = value; OnPropertyChanged(); } }
        public string TenPhim { get => _tenPhim; set { _tenPhim = value; OnPropertyChanged(); } }
        public int ThoiLuong { get => _thoiLuong; set { _thoiLuong = value; OnPropertyChanged(); } }
        public TheLoai TheLoaiChinh { get => _theLoaiChinh; set { _theLoaiChinh = value; OnPropertyChanged(); } }
        public string ChuoiTenTheLoaiPhu { get => _chuoiTenTheLoaiPhu; set { _chuoiTenTheLoaiPhu = value; OnPropertyChanged(); } }

        public FilmDTO(Phim phim)
        {
            MaPhim = phim.MaPhim;
            TenPhim = phim.TenPhim;
            ThoiLuong = (int)phim.ThoiLuong;
            TheLoaiChinh = DataProvider.Instance.Database.TheLoais.Where(theLoai => theLoai.MaTheLoai == phim.MaTheLoaiChinh).FirstOrDefault();
            ChuoiTenTheLoaiPhu = string.Join(", ", CategoryDAO.Instance.GetListTenTheLoaisFromListTheLoais(phim.TheLoais));
        }
    }
}
