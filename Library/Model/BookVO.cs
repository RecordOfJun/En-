using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class BookVO
    {
        private string id;
        private string name;
        private string publisher;
        private string author;
        private string price;
        private string isbn;
        private string publishDate;
        private string description;
        private int quantity;
        private int borrowed;
        public BookVO()
        {    
        }
        public BookVO(string id, string name, string publisher, string author, string price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
            this.quantity = quantity;
        }
        public bool IsNotNull()//도서 추가 시 빠뜨린 것 없는지 확인
        {//정보 하나라도 없으면 예외처리
            if (id != Constant.EMPTY && name != Constant.EMPTY && publisher != Constant.EMPTY && author != Constant.EMPTY && price != Constant.EMPTY && quantity>0)
                return true;
            return false;
        }
        public void Init()
        {
            id = Constant.EMPTY;
            name = Constant.EMPTY;
            publisher = Constant.EMPTY;
            author = Constant.EMPTY;
            price = Constant.EMPTY;
            quantity = 0;
            borrowed = 0;
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public int Borrowed
        {
            get { return borrowed; }
            set { borrowed = value; }
        }
    }
}