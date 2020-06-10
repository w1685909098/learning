using EntityFrameworkSQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Content 
    {
        public Content( )
        {
           CreatTime = DateTime.Now ;
            PublishTime = DateTime.Now;
        }
        public Content(string kind):this()
        {
            this.kind = kind;
        }
       /* public*/ protected internal string kind { get; set; }
        public User Author { get; set; }
        public DateTime CreatTime { get; }
        public DateTime PublishTime {  get; }
         
        [HelpMoneyChanged(25,Message =" 发布")]
        public  virtual void Publish()
        {
            if (Author==null)
            {
                throw new NullReferenceException("Author不能为空");
            }
        }
    }
    public class EmailMessage : ISendMessage, IChat
    {
         void ISendMessage.Send()
        {
            Console.WriteLine();
        }
          void IChat.Send()
        {
            Console.WriteLine();
        }
    }
    public class DBMessage : ISendMessage, IChat
    {
        void ISendMessage.Send()
        {
            Console.WriteLine();
        }
        void IChat.Send()
        {
            Console.WriteLine();
        }
    }
    public interface ISendMessage
    {
         void Send();
    }
    public interface IChat
    {
         void Send();
    }

}
