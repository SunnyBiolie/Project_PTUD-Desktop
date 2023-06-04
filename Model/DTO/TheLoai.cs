using Project_PTUD_Desktop.Model.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.Model.DTO
{
    public class TheLoai
    {
        private string maTheLoai;
        private string tenTheLoai;

        private ObservableCollection<Phim> dsPhims_TheLoaiChinh = new ObservableCollection<Phim>();
        private ObservableCollection<Phim> dsPhims_TheLoaiPhu = new ObservableCollection<Phim>();

        public string MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }

        public ObservableCollection<Phim> DsPhims_TheLoaiChinh { get => dsPhims_TheLoaiChinh; set => dsPhims_TheLoaiChinh = value; }
        public ObservableCollection<Phim> DsPhims_TheLoaiPhu { get => dsPhims_TheLoaiPhu; set => dsPhims_TheLoaiPhu = value; }

        //DsPhims_TheLoaiChinh = PhimDAO.Instance.GetListPhimsByMaTheLoaiChinh(maTheLoai);
        //DsPhims_TheLoaiPhu = PhimDAO.Instance.GetListPhimsByMaTheLoaiPhu(maTheLoai);

        public TheLoai(string maTheLoai, string tenTheLoai)
        {
            this.maTheLoai = maTheLoai;
            this.tenTheLoai = tenTheLoai;

        }
        public TheLoai(DataRow row)
        {
            maTheLoai = row["MaTheLoai"].ToString();
            tenTheLoai = row["TenTheLoai"].ToString();
        }
    }
}
