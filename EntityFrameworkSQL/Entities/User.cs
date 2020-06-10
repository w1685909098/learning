using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entities
{
     public sealed class User : BaseEntity<User>
    {
        //public int FailedTry { get; set; }
        
        //public User()
        //{

        //}
        public User(string name,string password )
        {
            Name = name;
            Password = password;
        }
        public string InvitedBy { get; set; }
        public int InvitationCode { get; set; }

        private string _name;

        private string[] Blackist = new string[] { "admin", "17bang", "管理员" };

        public string Name
        {
            get
            {
                for (int i = 0; i < Blackist.Length; i++)
                {
                    if (_name.Contains(Blackist[i]))
                    {
                        throw new ArgumentOutOfRangeException("用户（User）的昵称（Name）不能含有admin、17bang、管理员等敏感词");
                    }
                }
                return _name;
            }
            set
            {
                if (value == "admin")
                {
                    value = "系统管理员";
                }
                _name = value;
            }
        }
        private string WhiteList= "0123456789~!@#$%^&*()_+ABCDEFGabcdefg";

        private string _password;
        public string Password
        {
            private get
            { return _password; }
            set
            {
                if (value.Length<6)
                {
                    Console.WriteLine("密码长度不低于6");
                }
                for (int i = 0; i < value.Length; i++)
                {
                    if (!WhiteList.Contains(value[i]))
                    {
                        Console.WriteLine("密码必须由大小写英语单词、数字和特殊符号（~!@#$%^&*()_+）组成");
                    }//else nothing
                }
                _password = value;
            }
        }


        private int _verificationCode;
        public int VerificationCode { get; set; }
        //public TokenManager Tokens { get; set; }
        public int helpMoney { get; set; }
        public int HelpBean { get; set; }
        public int HelpCredit { get; set; }
        public void Register()
        {

        }
        public void Login()
        {

        }
        public void Forget()
        {

        }
    }
}
