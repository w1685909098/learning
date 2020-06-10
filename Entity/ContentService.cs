using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    class ContentService
    {
        
        public void Publish(Content content)
        {
            try
            {
                
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
                //throw new InnerException
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("求助的Reward为负数{_reward}");
            }
            catch (Exception)
            {

                throw ;
            }
            finally
            {
                Console.WriteLine($"{DateTime.Now.ToString ()},请求发布内容(Id=xxx)");
            }
            content.Publish();
            Console.WriteLine("保存至数据库");
        }
    }
}
