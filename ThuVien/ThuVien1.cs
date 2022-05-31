using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ThuVien
{
    public class ThuVien1
    {
        private SqlConnection _conn;
        private string _strConnect, _strServerName, _strDBName, _strUserID, _strPassword;
        private DataSet _dset; //Tạo một đối tượng CL:\Đang Học\Congnghe.Net\ADK\DoAnMonCongNgheNET\ThuVien\ThuVien1.csSDL ảo trên Client

        public DataSet DSet
        {
            get { return _dset; }
            set { _dset = value; }
        }

        public SqlConnection conn
        {
            get { return _conn; }
            set { _conn = value; }
        }
        public string strConnect
        {
            get { return _strConnect; }
            set { _strConnect = value; }
        }
        public string strServerName
        {
            get { return _strServerName; }
            set { _strServerName = value; }
        }
        public string strDBName
        {
            get { return _strDBName; }
            set { _strDBName = value; }
        }
        public string strUserID
        {
            get { return _strUserID; }
            set { _strUserID = value; }
        }
        public string strPassword
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }
        public ThuVien1()
        {
            strServerName = @"LAPTOP-QC6HGMRG\CLIENT1"; //Tên máy server của mình (tên máy của SV)
            //strServerName = @"DESKTOP-AUFE1Q8\SQLEXPRESS";
            strDBName = "ShopQuanAo";
            //Dùng với quyền của của Windows
            strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName + ";Integrated Security=true";
            //Dùng với quyền của SQL Server
            strUserID = "sa";
            strPassword = "123";
            strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName + ";User ID=" + strUserID + ";Password=" + strPassword;
            conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
            DSet = new DataSet(strConnect);
        }
        public ThuVien1(string pServerName, string pDBName)
        { //Dùng với quyền của của Windows
            strServerName = pServerName;
            strDBName = pDBName;
            strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName + ";Integrated Security=true";
            conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
            DSet = new DataSet(strConnect);
        }
        ////public ThuVien1(string pServerName, string pDBName, string pUserID, string pPassword)
        ////{ //Dùng với quyền của SQL Server
        ////    strServerName = pServerName;
        ////    strDBName = pDBName;            
        ////    strUserID = pUserID;
        ////    strPassword = pPassword;
        ////    strConnect = @"Data Source=" + strServerName + ";Initial Catalog=" + strDBName + ";User ID=" + strUserID + ";Password=" + strPassword;
        ////    conn = new SqlConnection(strConnect); //Khởi tạo đối tượng kết nối đến CSDL
        ////    DSet = new DataSet(strConnect);
        ////}
        public void openConnect()
        { //Mở kết nối
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        public void closeConnect()
        { //Đóng kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }
        public void disposeConnect()
        { //Hủy đối tượng kết nối
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Dispose();  //Giải phóng vùng nhớ đã cấp phát cho conn
        }
        public void updateToDataBase(string strSQL)
        { //Cho phép cập nhật CSDL với các thao tác gồm: Thêm, Xóa, Sửa
            openConnect(); //Mở kết nối
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL; //Câu truy vấn đưa vào
            cmd.ExecuteNonQuery(); //Thực thi
            closeConnect(); //Đóng kết nối
        }

        public int getCount(string strSQL)
        {
            openConnect(); //Mở kết nối
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL; //Câu truy vấn đưa vào
            if(cmd.ExecuteScalar() == null)
            {
                return 0;
            }
            int count = (int)cmd.ExecuteScalar(); //Thực thi
            closeConnect(); //Đóng kết nối
            return count;
        }

        public bool checkExist(string tableName, string fieldName, string fieldValue)
        {
            string strSQL = "SELECT COUNT(*) FROM " + tableName + " WHERE " + fieldName + "='" + fieldValue + "'";
            return getCount(strSQL) > 0 ? true : false;
        }

        public SqlDataReader getDataReader(string strSQL)
        { //Trả về 1 DataReader
            openConnect(); //Mở kết nối
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = strSQL; //Câu truy vấn đưa vào
            SqlDataReader dataReader = cmd.ExecuteReader(); //Thực thi
            return dataReader;
        }

        public SqlDataAdapter getDataAdapter(string strSQL, string tableName)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQL, conn);
            ada.Fill(DSet, tableName);
            closeConnect();
            return ada;
        }

        public DataTable getDataTable(string strSQL, string tableName)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQL, conn);
            ada.Fill(DSet, tableName);
            closeConnect();
            return DSet.Tables[tableName];
        }

        public DataTable getDataTable(string strSQL, string tableName, params string[] keyNames)
        {
            openConnect();
            SqlDataAdapter ada = new SqlDataAdapter(strSQL, conn);
            ada.Fill(DSet, tableName);
            //Tao khoa chinh cho DataTable
            int n = keyNames.Length;
            DataColumn[] primaryKey = new DataColumn[n];
            for (int i = 0; i < n; i++)
                primaryKey[i] = DSet.Tables[tableName].Columns[keyNames[i]];
            DSet.Tables[tableName].PrimaryKey = primaryKey;
            closeConnect();
            return DSet.Tables[tableName];
        }
    }
}
