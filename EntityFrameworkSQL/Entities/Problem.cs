using EntityFrameworkSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Problem :Content
    {
        public Problem(string body) : base("problem")

        {
             _body = body;
        }
        //private string _author;
        public User Author { get; set; }

        //private string _title;
        public string Title { get; set; }

        private string _body;
        public string Body { get; set; }

        private int _reward;
        public int Reward
        {
            get
            {
                return _reward;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Reward不能为负数");
                }//else
                _reward = value;

            }

        }

        public  DateTime PublishDateTime { get; set; }
        private string[] _keyword = new string[10];
        public string this[int index]
        {
            get { return _keyword[index]; }
            set { _keyword[index] = value; }
        }
        
        public void Load(int Id)
        {
            Console.WriteLine("获取一条求助");
        }
        public void Delete(int Id)
        {
            Console.WriteLine("删除某条求助");
        }
        public override void Publish()
        {
            base.Publish();
            Author.helpMoney -= _reward;
        }
    }
}
