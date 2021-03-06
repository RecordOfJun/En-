using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    class BookDTO
    {
        private string id;
        private string name;
        private string publisher;
        private string author;
        private string price;
        private string isbn;
        private string description;
        private string pubdate;
        private int quantity;
        private int borrowed;
        public BookDTO(string name, string publisher, string author, string price, int quantity, string isbn, string description, string pubdate,string id)
        {
            this.name = name;
            this.publisher = publisher;
            this.author = author;
            this.price = price;
            this.quantity = quantity;
            this.isbn = isbn;
            this.description = description;
            this.pubdate = pubdate;
            this.id = id;
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
        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Pubdate
        {
            get { return pubdate; }
            set { pubdate = value; }
        }
    }
}