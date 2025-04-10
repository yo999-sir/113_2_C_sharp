using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; // 定義陣列的大小，表示我們將產生 5 個樂透號碼
            int[] lotteryNumbers = new int[SIZE]; // 宣告一個整數陣列來儲存樂透號碼
            Random rand = new Random(); // 創建一個 Random 類別的實例，用於生成隨機數

            // 使用迴圈產生 5 個 1 到 42 之間的隨機數，並存入 lotteryNumbers 陣列中
            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                // 產生 1 到 42 的隨機數 (包含 1 和 42)
                int numberer;
                do
                {
                    numberer = rand.Next(1, 43);//產生1到42之檢的隨機數
                } while (lotteryNumbers.Contains(numberer));//檢查是否已經存在陣列中
                lotteryNumbers[i] = numberer;//將隨機數存入陣列
            }
            //將 lotteryNumbers 陣列中的數字進行排序
            Array.Sort(lotteryNumbers);//將陣列中的數字進行排序
            // 將產生的樂透號碼顯示在對應的標籤上 (註解掉的原始程式碼，這一段將樂透號碼直接顯示在對應的標籤上)
            // firstLabel.Text = lotteryNumbers[0].ToString();
            // secondLabel.Text = lotteryNumbers[1].ToString();
            // thirdLabel.Text = lotteryNumbers[2].ToString();
            // fourthLabel.Text = lotteryNumbers[3].ToString();
            // fifthLabel.Text = lotteryNumbers[4].ToString();

            // 使用迴圈將樂透號碼顯示在對應的標籤上
            // 首先，將視窗上的標籤控制項存入一個 Label 陣列中
            Label[] showLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };
            // 然後，使用迴圈將 lotteryNumbers 陣列中的數字轉換為字串，並顯示在對應的標籤上
            for (int i = 0; i < showLabels.Length; i++)
            {
                showLabels[i].Text = lotteryNumbers[i].ToString(); // 將樂透號碼轉換為字串並顯示
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
