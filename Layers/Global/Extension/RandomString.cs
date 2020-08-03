using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
   public  class RandomString
    {
        public static int length = 4;
        public static string singleCode, invitingCode;
        public static string GetRandomCode()
        {
            invitingCode = null;
            string whiteList = "0123456789";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                //int random = Convert.ToInt32(new Random().Next(9).ToString());
                //singleCode = new Random().Next(random).ToString();//四个一样的邀请码
                int charrandom = random.Next(whiteList.Length);
                char singleCode = whiteList[charrandom];
                invitingCode += singleCode;
            }
            return invitingCode;
        }
    }
}
