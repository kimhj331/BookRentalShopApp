using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace BookRentalShopApp20.Items
{
    public partial class RentalMngForm : MetroForm
    {

        #region 멤버변수 영역
        BaseMode MyMode = BaseMode.NONE;    // 최초에는 기본상태
        readonly string strTblName = "membertbl";
        #endregion

        #region 생성자 영역
        public RentalMngForm()
        {
            InitializeComponent();
        }

        private void RentalMngForm_Load(object sender, EventArgs e)
        {
            UpdateData();
            InitControls();
            UpdateComboBook();
            UpdateComboMember();
           
        }
        #endregion

        #region 이벤트 핸들러 영역
        //그리드 셀클릭 시 컨트롤에 셀 정보 띄우기


        // Btn삭제 클릭
        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (MyMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }
            MyMode = BaseMode.DELETE;
            SaveData();
            //InitControls();
        }



        // Btn취소 클릭
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (MyMode == BaseMode.NONE)
            {
                var result = MetroMessageBox.Show(this, "회원관리 창을 닫으시겠습니까?", "작업 취소", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            //InitControls();

        }
        #endregion

        #region 커스텀 영역
        private void UpdateComboMember()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $"SELECT Idx, Names FROM membertbl ";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read())
                {
                    temps.Add(reader[1].ToString(), reader[0].ToString());
                }
                CboMember.DataSource = new BindingSource(temps, null);

                CboMember.DisplayMember = "Key";
                CboMember.ValueMember = "Value";
                CboMember.SelectedIndex = 0;

            }
        }
        private void UpdateComboBook()
        {

            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = $" SELECT Idx, Names, (SELECT Names FROM divtbl WHERE Division = b.Division) as Division " +
                                    "FROM BooksTbl as b ";
                conn.Open();

                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, string> temps = new Dictionary<string, string>();
                temps.Add("선택", "");

                while (reader.Read())
                {
                    temps.Add($"[{reader[2]}] {reader[1]}", $"{reader[0]}");

                }
                CboBook.DataSource = new BindingSource(temps, null);

                CboBook.DisplayMember = "Key";
                CboBook.ValueMember = "Value";
                CboBook.SelectedIndex = 0;

            }

        }

        private void UpdateData()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
            {
                string strQuery = "    SELECT r.idx AS '번호', " +
                                  "           m.Names AS '대여회원', " +
                                  "           b.Names AS '대여책제목', " +
                                  "           b.ISBN, " +
                                  "           r.rentalDate AS '대여일', " +
                                  "           r.returnDate AS '반납일', " +
                                  "           r.memberIdx, " +
                                  "           r.bookIdx " +
                                  "      FROM rentaltbl AS r " +
                                  " INNER JOIN membertbl AS m " +
                                  "        ON r.memberIdx = m.Idx " +
                                  "INNER JOIN bookstbl AS b " +
                                  "        ON r.bookIdx = b.Idx ";

                conn.Open();

                MySqlDataAdapter adapter = new MySqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, strTblName);

                Rentaltbl.DataSource = ds;
                Rentaltbl.DataMember = strTblName;
            }

            SetColumnHeaders();
        }

        private void SetColumnHeaders()
        {
           DataGridViewColumn column;

            column = Rentaltbl.Columns[0];
            column.Width = 50;
            column.HeaderText = "번호";

            column = Rentaltbl.Columns[1];
            column.Width = 100;
            column.HeaderText = "대여회원";

            column = Rentaltbl.Columns[2];
            column.Width = 150;
            column.HeaderText = "대여책제목";

            column = Rentaltbl.Columns[3];
            column.Width = 100;
            column.HeaderText = "ISBN";

            column = Rentaltbl.Columns[4];
            column.Width = 90;

            column = Rentaltbl.Columns[6];
            column.Visible = false; //memberIDX

            column = Rentaltbl.Columns[7];
            column.Visible = false; //bookIDX
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MyMode != BaseMode.UPDATE)
            {
                MetroMessageBox.Show(this, "삭제할 데이터를 선택하세요", "알림");
                return;
            }
            MyMode = BaseMode.DELETE;
            SaveData();
            InitControls();
        }

        private void InitControls()
        {
            TxtIdx.Text = String.Empty;
            TxtIdx.Focus();
            TxtIdx.ReadOnly = true;


            CboMember.SelectedIndex = CboBook.SelectedIndex = 0;

            DtpRentalDate.CustomFormat = "yyyy-MM-dd";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;
            DtpRentalDate.Value = DateTime.Now;

            DtpReturnDate.CustomFormat = " ";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;

            MyMode = BaseMode.NONE;
        }

        private void SaveData()
        {
            if (CboBook.SelectedIndex < 1 ||
                CboMember.SelectedIndex < 1)
            {
                MetroMessageBox.Show(this, " 빈값은 넣을 수 없습니다", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else 
            {
                if (MyMode == BaseMode.NONE)
                {
                    MetroMessageBox.Show(this, "신규등록버튼을 누르고 신규등록하세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(Commons.CONNSTR))
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conn;

                        if (MyMode == BaseMode.UPDATE)
                        {
                            cmd.CommandText = "UPDATE rentaltbl " +
                                              "   SET memberIdx    = @memberIdx " +
                                              "       , bookIdx    = @bookIdx " +
                                              "       , rentalDate = @rentalDate " +
                                              "       , returnDate = @returnDate " +
                                              " WHERE          Idx = @Idx ";

                        }
                        else if (MyMode == BaseMode.INSERT)
                        {
                            cmd.CommandText = "INSERT INTO rentaltbl " +
                                     "( " +
                                         "            memberIdx " +
                                         "         ,  bookIdx " +
                                         "         ,  rentalDate " +
                                         "         ,  returnDate " +
                                                                  ") " +
                                        "VALUES " +
                                                "( " +
                                        "            @memberIdx " +
                                        "         ,  @bookIdx " +
                                        "         ,  @rentalDate " +
                                        "         ,  @returnDate " +
                                                                   ") ";
                        }
                        MySqlParameter paraMemberIdx = new MySqlParameter("@memberIdx", MySqlDbType.Int32);
                        paraMemberIdx.Value = CboMember.SelectedValue;
                        cmd.Parameters.Add(paraMemberIdx);

                        MySqlParameter parabookIdx = new MySqlParameter("@bookIdx", MySqlDbType.Int32);
                        parabookIdx.Value = CboBook.SelectedValue;
                        cmd.Parameters.Add(parabookIdx);

                        MySqlParameter paraRentalDate = new MySqlParameter("@rentalDate", MySqlDbType.Date);
                        paraRentalDate.Value = DtpRentalDate.Value;
                        cmd.Parameters.Add(paraRentalDate);

                        if (string.IsNullOrWhiteSpace(DtpReturnDate.Value.ToString()))
                        {
                            MySqlParameter paraReturnDate = new MySqlParameter("@returnDate", MySqlDbType.Date);
                            paraReturnDate.Value = string.Empty;
                            cmd.Parameters.Add(paraReturnDate);
                        }
                        else 
                        {
                            MySqlParameter paraReturnDate = new MySqlParameter("@returnDate", MySqlDbType.Date);
                            paraReturnDate.Value = DtpReturnDate.Value;
                            cmd.Parameters.Add(paraReturnDate);
                        }

                        if (MyMode == BaseMode.UPDATE)
                        {
                            MySqlParameter paraIdx = new MySqlParameter("@Idx", MySqlDbType.Int32);
                            paraIdx.Value = TxtIdx.Text;
                            cmd.Parameters.Add(paraIdx);
                        }

                        var result = cmd.ExecuteNonQuery();

                        if (MyMode == BaseMode.INSERT)
                        {
                            MetroMessageBox.Show(this, $"{result}건이 신규입력되었습니다", "신규입력");
                        }
                        else if (MyMode == BaseMode.UPDATE)
                        {
                            MetroMessageBox.Show(this, $"{result}건이 수정변경되었습니다", "수정변경");
                        }
                        else if (MyMode == BaseMode.DELETE)
                        {
                            MetroMessageBox.Show(this, $"{result}건이 삭제변경되었습니다", "삭제변경");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, $"에러발생 : {ex.Message}", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    InitControls();
                    UpdateData();
                }

            }
        }


        private void Rentaltbl_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                DataGridViewRow data = Rentaltbl.Rows[e.RowIndex];
                //TODO : 클릭 시 입력 컨트롤에 데이터 할당
                TxtIdx.Text = data.Cells[0].Value.ToString();
                CboMember.SelectedValue = data.Cells[6].Value.ToString();
                CboBook.SelectedValue = data.Cells[7].Value.ToString();
                DtpRentalDate.Value = DateTime.Parse(data.Cells[4].Value.ToString());
                if (!string.IsNullOrEmpty(data.Cells[5].Value.ToString()))
                {
                    DtpReturnDate.CustomFormat = "yyyy-MM-dd";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                    DtpReturnDate.Value = DateTime.Parse(data.Cells[5].Value.ToString());
                }
                else
                {
                    DtpReturnDate.CustomFormat = " ";
                    DtpReturnDate.Format = DateTimePickerFormat.Custom;
                    
                }

                MyMode = BaseMode.UPDATE;       // 수정모드로 변경
            }
        }

        private void BtnNew_Click_1(object sender, EventArgs e)
        {
            InitControls();
            MyMode = BaseMode.INSERT;
        }

        private void DtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            DtpReturnDate.CustomFormat = "yyyy-MM-dd";
            DtpReturnDate.Format = DateTimePickerFormat.Custom;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet1 = workbook.CreateSheet("sheet1");
            sheet1.CreateRow(0).CreateCell(0).SetCellValue("Tental Book Data");

            DataSet ds = Rentaltbl.DataSource as DataSet;
            for (int i = 0; i < ds.Tables[0].Rows.Count ; i++)
            {
                IRow row = sheet1.CreateRow(i);
                for (int j = 0; j < ds.Tables[0].Rows[0].ItemArray.Length; j++)
                {
                    if (j == 4 || j == 5)
                    {
                        var value = string.IsNullOrEmpty(ds.Tables[0].Rows[i].ItemArray[j].ToString()) ? "" : ds.Tables[0].Rows[i].ItemArray[j].ToString().Substring(0, 10);
                        row.CreateCell(j).SetCellValue(value);
                    }
                    else if (j > 5) { break; }
                    else
                    {
                        row.CreateCell(j).SetCellValue(ds.Tables[0].Rows[i].ItemArray[j].ToString());
                    }
                        
                }
            }
            FileStream file = File.Create(Environment.CurrentDirectory + $@"\exprot.xlsx");
            workbook.Write(file);
            file.Close();

            MessageBox.Show("Exprot Done!!");
          
        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            SaveData();
        }
    }
    #endregion
}