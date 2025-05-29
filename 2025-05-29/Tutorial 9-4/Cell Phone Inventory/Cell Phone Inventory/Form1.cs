using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存所有 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();
        private object myPhone;
        private object myphone;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 取得使用者輸入的手機資料，並指派給傳入的 CellPhone 物件屬性。
        /// </summary>
        /// <param name="phone">要指派資料的 CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存手機價格的變數
            decimal price;

            // 取得使用者輸入的品牌，並指派給 CellPhone 物件的 Brand 屬性
            phone.Brand = brandTextBox.Text;

            // 取得使用者輸入的型號，並指派給 CellPhone 物件的 Model 屬性
            phone.Model = modelTextBox.Text;

            // 取得使用者輸入的價格，並嘗試轉換為 decimal 型別
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 顯示錯誤訊息，提醒使用者價格輸入無效
                MessageBox.Show("價格格式無效，請重新輸入。");
            }
        }

        /// <summary>
        /// 當使用者點擊「新增手機」按鈕時觸發，將輸入的手機資料新增至清單並顯示於 ListBox。
        /// </summary>
        private void addPhoneButton_Click(object sender, EventArgs e)
        {
          List<CellPhone> phoneList = new List<CellPhone>();
            // 建立新的 CellPhone 物件
            CellPhone phone = new CellPhone();
            // 取得使用者輸入的手機資料
            GetPhoneData(phone);
            // 將新的手機物件加入清單
            phoneList.Add(phone);
            // 清空 ListBox，準備顯示最新的手機清單
           phoneListBox.Items.Add(myPhone.Brand + " " + myphone.Model);

            // 清空輸入欄位，方便使用者輸入下一個手機資料
            brandTextBox.Text = "";
            modelTextBox.Text = "";
            priceTextBox.Text = "";
        }

        /// <summary>
        /// 當使用者於 ListBox 選取不同手機時觸發，可於此顯示詳細資訊或進行其他操作。
        /// </summary>
        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        int index = phoneListBox.SelectedIndex;

            MessageBox.Show(phoneList[index].Price.ToString("C"));
        }

        /// <summary>
        /// 當使用者點擊「離開」按鈕時觸發，關閉視窗並結束程式。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單，結束應用程式
            this.Close();
        }
    }
}
