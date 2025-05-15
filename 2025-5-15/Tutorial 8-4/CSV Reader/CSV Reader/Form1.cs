using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 設定表單標題為繁體中文  
            this.Text = "CSV 檔案讀取器";

            // 設定按鈕的 Text 屬性為繁體中文  
            getScoresButton.Text = "取得分數";
            exitButton.Text = "離開";
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inputFile = null; // 初始化 inputFile 為 null  
                string line; // 儲存讀取的行  
                char[] delimiter = { ',', ' ' }; // 分隔字元  

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);
                }

                if (inputFile != null)
                {
                    averagesListBox.Items.Clear(); // 清空列表

                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine().Trim();
                        string[] tokens = line.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);

                        if (tokens.Length < 2)
                            continue; // 如果少於姓名+一個分數，就跳過

                        string name = tokens[0]; // 第一欄是人名
                        int total = 0;

                        for (int i = 1; i < tokens.Length; i++)
                        {
                            total += int.Parse(tokens[i]);
                        }

                        double average = (double)total / (tokens.Length - 1);
                        averagesListBox.Items.Add($"{name} 的平均分數為: {average:F2}");
                    }

                    inputFile.Close();
                }
                else
                {
                    MessageBox.Show("未選擇任何檔案");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("檔案讀取錯誤: " + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

