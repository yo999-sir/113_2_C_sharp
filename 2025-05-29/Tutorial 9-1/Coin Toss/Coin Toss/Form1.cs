using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coin_Toss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tossButton_Click(object sender, EventArgs e)
        {
            Coin 我的硬幣 = new Coin(); // 建立 Coin 類別的實例。
                                    // 清除 ListBox。
            outputListBox.Items.Clear();
            // 擲硬幣五次。
            for (int i = 0; i < 5; i++)
            {
                我的硬幣.Toss();
                // 將結果加入 ListBox。
                outputListBox.Items.Add(我的硬幣.GetSideUp());
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}

