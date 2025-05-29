using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Test
{
    /// <summary>
    /// CellPhone 類別用來表示一支手機，包含品牌、型號與價格等屬性。
    /// </summary>
    class CellPhone
    {
        // 儲存手機品牌的私有欄位
        private string brand;

        // 儲存手機型號的私有欄位
        private string model;

        // 儲存手機價格的私有欄位
        private decimal price;

        public CellPhone() // 建構函式
        {
            // 初始化手機的品牌、型號與價格
            this.brand = "";
            this.model = "";
            this.Price = 0m;
        }

        // 屬性：取得或設定手機品牌
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        // 屬性：取得或設定手機型號
        public decimal Price
        {
            get { return price; }
            set
            {
                // 確保價格不能為負數
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative.");
                }
                price = value;
            }
        }

        public string Model { get; internal set; }
    }
}
