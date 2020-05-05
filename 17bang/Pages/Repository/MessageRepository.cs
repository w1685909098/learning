using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Entity;
using _17bang.Pages.ViewModel;

namespace _17bang.Pages.Repository
{
    public class MessageRepository
    {
        private static IList<MessageModel> _messages;
        static MessageRepository()
        {
            _messages = new List<MessageModel>
            {
               new MessageModel
                {
                    Id=1,Selected=false,DateTime=DateTime.Now,Content="你因为登录获得系统随机分配给你的 帮帮豆 1 枚。"
                },
                new MessageModel
                {
                    Id=2,Selected=false,DateTime=DateTime.Now,Content="你因为登录获得系统随机分配给你的 帮帮豆 2 枚。"
                },
                new MessageModel
                {
                    Id=3,Selected=false,DateTime=DateTime.Now,Content="你因为登录获得系统随机分配给你的 帮帮豆 3 枚。"
                },
                new MessageModel
                {
                    Id=4,Selected=false,DateTime=DateTime.Now,Content="你因为登录获得系统随机分配给你的 帮帮豆 4 枚。"
                },
            };
        }
        public IList<MessageModel> Get()
        {
            return _messages;
        }
        //public void Add()
        //{

        //}
        #region 自己写的
        //public void Delete(IList<MessageModel> messages)
        //{
        //    //IList<Entity.Message> messagesSelected = messages.Where(m => m.Selected == true).ToList();
        //    foreach (var item in messages.Where(m => m.Selected == true).ToList())
        //    {
        //        /*IList<Entity.Message> messagesSelected= */messages.Remove(item);
        //    }
        //    //return _messages;
        //}

        //public void IsRead(IList<MessageModel> messages)
        //{
        //    foreach (var item in messages.Where(m => m.Selected == true).ToList())
        //    {
        //        /*IList<Entity.Message> messagesSelected= */
        //        item.IsRead = true;
        //    }
        //}
        #endregion
        public MessageModel GetSingleMessage(int id)
        {
            return _messages.Where(m => m.Id == id).SingleOrDefault();
        }

        //public void Delete(MessageModel message)
        //{
        //    _messages.Remove(message);
        //}
        public void Delete(int id)
        {
            //MessageModel delete = GetSingleMessage(id);
            _messages.Remove(GetSingleMessage(id));
        }
    }
}
