using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        private string input;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>  
        /// 此方法 `IsValidFormat` 接受一個字串參數，並判斷該字串是否符合台灣電話號碼的格式。  
        /// 格式要求如下：(XXX)XXX-XXXX，其中：  
        /// - `XXX` 表示三位數字。  
        /// - 中間無空格，括號和連字號必須正確放置。  
        /// 如果字串符合格式，則返回 `true`，否則返回 `false`。  
        /// </summary>  
        /// <param name="str">要檢查的字串。</param>  
        /// <returns>如果格式正確，返回 `true`；否則返回 `false`。</returns>  
        private bool IsValidFormat(string str)
        {
            if (str.Length == 13 && // 修正括號位置，確保條件正確連接  
                str[0] == '(' &&
                str[3] == ')' && // 修正索引，括號應在第 3 個位置  
                str[8] == '-')
            {
                string areaCode = str.Substring(1, 2);
                string firstPart = str.Substring(4, 3); // 修正索引和長度，確保提取正確部分  
                string secondPart = str.Substring(9, 4);
                if (IsAllDigits(areaCode) &&
                    IsAllDigits(firstPart) &&
                    IsAllDigits(secondPart))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool IsAllDigits(string firstPart)
        {
            foreach (char c in firstPart)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 此方法 `Unformat` 接受一個參考字串參數，該字串假設為格式化的電話號碼。
        /// 格式為：(XXX)XXX-XXXX。
        /// 方法的功能是移除字串中的括號和連字號，將其轉換為純數字格式。
        /// </summary>
        /// <param name="str">要取消格式化的字串（以參考方式傳遞）。</param>
        private void Unformat(ref string str)
        {
            str = str.Remove(0, 1);
            str = str.Remove(2, 1);
            str = str.Remove(6, 1);
        }

        /// <summary>
        /// 當使用者點擊「取消格式化」按鈕時觸發此事件。
        /// 此方法負責調用 `Unformat` 方法，對輸入的電話號碼進行取消格式化處理。
        /// </summary>
        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text;
            input = input.Trim();
            if (IsValidFormat(input))
            {
                Unformat(ref input);
                MessageBox.Show("取消格式化後的電話號碼為：" + input, "結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("請輸入正確格式的電話號碼！", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                numberTextBox.Text = "string.Empty";
                numberTextBox.Focus();
            }
        }

        /// <summary>
        /// 當使用者點擊「退出」按鈕時觸發此事件。
        /// 此方法負責關閉目前的表單，結束應用程式。
        /// </summary>
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉目前的表單。
            this.Close();
        }
    }
}
