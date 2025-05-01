using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // NumberLowerCase 方法接受一個字串參數，
        // 並回傳其中包含的小寫字母數量。
        private int NumberUpperCase(string str)
        {
            int upperCaseCount = 0;
            foreach (char c in str)
            {
                if (char.IsLower(c))
                {
                    upperCaseCount++;
                }
            }
            return upperCaseCount;
        }
        // NumberDigits 方法接受一個字串參數，
        // 並回傳其中包含的數字字元數量。
        private int NumberLowerCase(string str)
        {
            int upperCaseCount = 0;
            foreach (char c in str)
            {
                if (char.IsLower(c))
                {
                    upperCaseCount++;
                }
            }
            return upperCaseCount;
        }

        // The NumberDigits method accepts a string argument
        // and returns the number of numeric digits it contains.
        private int NumberDigits(string str)
        {
            
        }

        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MIN_LENGTH = 8;
            string password = passwordTextBox.Text;
            if (password.Length >=MIN_LENGTH &&
                NumberUpperCase(password) > 0&&
                NumberLowerCase(password) > 0 &&
                NumberDigits(password) > 0 )
          {
            MessageBox.Show("密碼有效"，"密碼檢查結果")
          }  
        

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單
            this.Close();
        }
    }
}
