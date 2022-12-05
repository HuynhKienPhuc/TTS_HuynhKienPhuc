using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAnThucTap.ViewModel
{
    public class PhieuThu
    {
        #region variables
        public string soPhieu { get; set; }
        public string Mssv { get; set; }
        public string hoTenSV { get; set; }
        public string matKhau { get; set; }
        public string noiDung { get; set; }
        public DateTime? ngayThanhToan { get; set; }
        public Nullable<decimal> soTienThu { get; set; }
        public string donViThu { get; set; }
        public string trangThai { get; set; }
        #endregion
    }
}