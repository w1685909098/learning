using Entities;
using EntityFrameworkCoreSQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
     public sealed class Register : BaseEntity<Register>
    {
        public int FailedTry { get; set; }

        public Register()
        {

        }
        public Register(string name,string password )
        {
            UserName = name;
            Password = password;
        }
        public string InvitedBy { get; set; }
        public int InvitationCode { get; set; }

        private string _userName;

        private string[] Blackist = new string[] { "admin", "17bang", "管理员" };

        public string UserName
        {
            get
            {
                for (int i = 0; i < Blackist.Length; i++)
                {
                    if (_userName.Contains(Blackist[i]))
                    {
                        throw new ArgumentOutOfRangeException("用户（User）的昵称（Name）不能含有admin、17bang、管理员等敏感词");
                    }
                }
                return _userName;
            }
            set
            {
                if (value == "admin")
                {
                    value = "系统管理员";
                }
                _userName = value;
            }
        }
        private string WhiteList= "0123456789~!@#$%^&*()_+ABCDEFGabcdefg";

        private string _password;
        public string Password
        {
             get
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
                        throw new Exception("密码必须由大小写英语单词、数字和特殊符号（~!@#$%^&*()_+）组成");
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
        public DateTime CreateTime { get; set; }
        public int EmailId { get; set; }
        public Email Email { get; set; }
        //public IList<Appraise> Appraises { get; set; }
        //public IList<Article> Articles { get; set; }
        //public IList<Comment> Comments { get; set; }
        //public IList<Problem> Problems { get; set; }

        public void Create()
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
