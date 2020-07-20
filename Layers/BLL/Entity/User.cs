using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User : BaseEntity
    {
        public User Inviter { get; set; }
        [MaxLength(10)]
        public string Name { get; set; }
        public string Password { get; set; }
        public string InvitingCode { get; set; }
        public int Credit { get; set; }
        public int BMoney { get; set; }

        public int ArticleId { get; set; }
        public IList<Article> Articles { get; set; }
        public static void Register(User register)  //考虑使用静态还是实例       应该使用静态由类进行调用，否则会出现xx注册tt
        {
            register.Credit += 10;
            register.Inviter.Credit += new Random().Next(3) + 2;
            register.InvitingCode = RandomString.GetRandomCode();
            //register.InvitingCode = new Random().Next(9999).ToString(); //这样不能保证为四位数
        }
    }
}
