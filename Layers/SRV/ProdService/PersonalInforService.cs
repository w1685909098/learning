using Entity;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Personal;

namespace ProdService
{
    public class PersonalInforService : BaseService, IPersonalInforService
    {
        public PersonalInformationModel GetPersonalInforModelById(int id)
        {
            User user = userRepository.FindEntity(id);
            return mapper.Map<PersonalInformationModel>(user);
        }

        #region 低耦合   减少方法对传入参数的依赖
        public PersonalInformationModel GetPersonalInforModelById( )
        {
            //User user = userRepository.Find((int)CurrentUserId);
            User user = CurrentUser;
            return mapper.Map<PersonalInformationModel>(user);
        }
        #endregion

        public void AddModelIcon(PersonalInformationModel model)
        {
            User user = mapper.Map<User>(model);
            userRepository.UserSaveChanges(user);
        }
    }
}
