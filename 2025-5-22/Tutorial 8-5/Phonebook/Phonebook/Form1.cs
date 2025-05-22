using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Phonebook
{
    // 聯絡人結構：包含姓名與電話
    struct PhoneBookEntry
    {
        public string name;
        public string phone;
    }

    public partial class Form1 : Form
    {
        // 儲存所有聯絡人的清單
        private List<PhoneBookEntry> phoneList = new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent(); // 初始化元件
        }

        // 表單載入時讀取檔案並顯示姓名
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();      // 讀取聯絡人資料
            DisplayNames();  // 顯示聯絡人姓名
        }

        // 讀取聯絡人資料檔案
        private void ReadFile()
        {
            StreamReader inputFile;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputFile = File.OpenText(openFile.FileName);
                    string line;
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine().Trim();
                        string[] parts = line.Split(',');

                        if (parts.Length == 2)
                        {
                            PhoneBookEntry entry;
                            entry.name = parts[0].Trim();
                            entry.phone = parts[1].Trim();
                            phoneList.Add(entry);
                        }
                        else
                        {
                            MessageBox.Show("檔案格式錯誤");
                        }
                    }

                    inputFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message);
                }
            }
        }

        // 將聯絡人姓名顯示在 ListBox 中
        private void DisplayNames()
        {
            nameListBox.Items.Clear(); // 清除原有項目
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name); // 加入清單
            }
        }

        // 點選 ListBox 項目時顯示該聯絡人電話
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index >= 0)
            {
                phoneTextBox.Text = phoneList[index].phone;
            }
            else
            {
                phoneTextBox.Text = "";
            }
        }

        // 離開按鈕：關閉程式
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 新增聯絡人
        private void addButton_Click(object sender, EventArgs e)
        {
            string newName = newNameTextBox.Text.Trim();
            string newPhone = newPhoneTextBox.Text.Trim();

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newPhone))
            {
                MessageBox.Show("請輸入姓名與電話");
                return;
            }

            // 建立新聯絡人並加入清單
            PhoneBookEntry newEntry;
            newEntry.name = newName;
            newEntry.phone = newPhone;

            phoneList.Add(newEntry);                // 加入清單
            nameListBox.Items.Add(newName);         // 加入畫面清單

            // 清空輸入欄
            newNameTextBox.Clear();
            newPhoneTextBox.Clear();
        }
    }
}