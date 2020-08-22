using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModel.Password;

namespace ServiceInterface
{
   public interface IPasswordService
    {
        ChangeModel GetChangeModelById(int id);
        void UISaveChangeModel(ChangeModel changeModel);
        ForgetModel GetForgetModelByName(string name);
        void UISaveForgetModel(ForgetModel forgetModel);
        ResetModel GetResteModel/*ById*/(/*int id*/);
        void UISaveResetModel(ResetModel resteModel);

    }
}
