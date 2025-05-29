using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GetPhoneData 方法會接收一個 CellPhone 物件作為參數，
        /// 並將使用者輸入的資料指派給該物件的屬性。
        /// </summary>
        /// <param name="phone">要設定資料的 CellPhone 物件</param>
        private void GetPhoneData(CellPhone phone)
        {
            decimal price;

            phone.Brand = brandTextBox.Text; // 從品牌文字方塊取得品牌名稱
            phone.Model = modelTextBox.Text; // 從型號文字方塊取得型號 

            // 嘗試將價格文字方塊中的文字轉換為 decimal 型別
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                // 如果轉換成功，設定手機物件的價格
                phone.Price = price;
            }
            else
            {
                // 如果轉換失敗，顯示錯誤訊息並清除價格文字方塊
                MessageBox.Show("請輸入有效的價格。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                priceTextBox.Clear();
            }
        }


        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone myphone = new CellPhone(); // 建立一個新的 CellPhone 物件

            GetPhoneData(myphone); // 呼叫 GetPhoneData 方法，將使用者輸入的資料設定到物件中

            // 將物件的屬性顯示在對應的文字方塊中
            brandLabel.Text = myphone.Brand;   // 顯示品牌
            modelLabel.Text = myphone.Model;   // 顯示型號
            priceLabel.Text = myphone.Price.ToString("C2");   // 顯示價格
        }

        /// <summary>
        /// 當使用者按下「離開」按鈕時執行此事件處理方法。
        /// 會關閉目前的表單。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
