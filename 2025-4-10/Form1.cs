using System;
using System.Windows.Forms;

namespace ArrayEquality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 定義兩個整數陣列
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 5 };

            // 比較兩個陣列是否相等
            if (isArraysEqual(array1, array2))
            {
                MessageBox.Show("陣列相等");
            }
            else
            {
                MessageBox.Show("陣列不相等");
            }
        }

        private bool isArraysEqual(int[] array1, int[] array2)
        {
            // 檢查陣列長度是否相等
            if (array1.Length != array2.Length)
            {
                return false;
            }

            // 檢查每個元素是否相等
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
