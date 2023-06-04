using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_PTUD_Desktop.Model.DTO
{
    public class SuatChieu
    {
        private string maSuat;
        private int gioBatDau;
        private int phutBatDau;

        public string MaSuat { get => maSuat; set => maSuat = value; }
        public int GioBatDau { get => gioBatDau; set => gioBatDau = value; }
        public int PhutBatDau { get => phutBatDau; set => phutBatDau = value; }

        public SuatChieu(string maSuat, int gioBatDau, int phutBatDau)
        {
            this.maSuat = maSuat;
            this.gioBatDau = gioBatDau;
            this.phutBatDau = phutBatDau;
        }
        public SuatChieu(DataRow row)
        {
            maSuat = row["MaSuat"].ToString();
            gioBatDau = (int)row["GioBatDau"];
            phutBatDau = (int)row["PhutBatDau"];
        }
    }
}
