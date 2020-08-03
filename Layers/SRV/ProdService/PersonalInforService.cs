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
            User user = userRepository.Find(id);
            return mapper.Map<PersonalInformationModel>(user);
        }
    }
}
