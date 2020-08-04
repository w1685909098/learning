using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Personal;

namespace ServiceInterface
{
   public interface IPersonalInforService
    {
        PersonalInformationModel GetPersonalInforModelById(int id);
        void AddModelIcon(PersonalInformationModel model);
    }
}
