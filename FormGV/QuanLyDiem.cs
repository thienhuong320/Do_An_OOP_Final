﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thiet_ke.Objects;

namespace Thiet_ke
{
    public partial class QuanLyDiem : Form
    {
        public QuanLyDiem()
        {
            InitializeComponent();
        }

        private void grbDsLop_Enter(object sender, EventArgs e)
        {

        }

        private void GiaoVien_Load(object sender, EventArgs e)
        {
            string filePath = "students.json";

            // Đọc dữ liệu từ tệp JSON
            HocSinh[] danhSachHocSinhs = DocFile<HocSinh[]>(filePath);

            // Hiển thị dữ liệu trong ListView
            foreach (HocSinh hocSinh in danhSachHocSinhs)
            {
                ListViewItem item = new ListViewItem(hocSinh.maHS);
                item.SubItems.Add(hocSinh.hoVaTenLot);
                item.SubItems.Add(hocSinh.ten);
                item.SubItems.Add(hocSinh.gioiTinh.ToString());
                item.SubItems.Add(hocSinh.soDienThoai);
                item.SubItems.Add(hocSinh.tenDangNhap);
                item.SubItems.Add(hocSinh.matKhau);

                lvSinhVien.Items.Add(item);
            }
        }
        static T DocFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                T data = JsonConvert.DeserializeObject<T>(json);
                return data;
            }
            else
            {
                Console.WriteLine("File không tồn tại.");
                return default(T);
            }
        }

        private void btnNhapDiem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSuaSv_Click(object sender, EventArgs e)
        {
            if (lvSinhVien.SelectedItems.Count > 0)
            {
                // Lấy học sinh được chọn trong listViewStudents
                ListViewItem selectedItem = lvSinhVien.SelectedItems[0];
                string maHocSinh = selectedItem.SubItems[0].Text;

                // Hiển thị form EditForm và truyền maHocSinh vào
                SuaHs suaHS = new SuaHs(maHocSinh);
                suaHS.ShowDialog();

                // Sau khi form EditForm đóng, bạn có thể cập nhật hoặc làm gì đó với dữ liệu đã chỉnh sửa
                // Ví dụ: cập nhật lại dữ liệu trong listViewStudents
                // danhSachHocSinhs = ... (cập nhật lại danh sách học sinh từ nguồn dữ liệu)
                // Hiển thị lại danh sách học sinh trong listViewStudents
                // ...
            }
        }
    }
}
