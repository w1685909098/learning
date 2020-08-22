using Entity;
using ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Password;

namespace ProdService
{
    class PasswordService : BaseService, IPasswordService
    {
        public ChangeModel GetChangeModelById(int id)
        {
            User user = userRepository.FindEntity(id);
            return mapper.Map<ChangeModel>(user);
            //return mapper.Map<ChangeModel>(CurrentUser);
        }

        public ForgetModel GetForgetModelByName(string name)
        {
            User user = userRepository.GetUserByName(name);
            return mapper.Map<ForgetModel>(user);
        }

        public ResetModel GetResteModel/*ById*/(/*int id*/)
        {
            return mapper.Map<ResetModel>(CurrentUser);
        }

        public void UISaveChangeModel(ChangeModel changeModel)
        {
            User user = mapper.Map<User>(userRepository.FindEntity((int)changeModel.Id));
            //CurrentUser.BindingEmail = new Email();
            //CurrentUser.Password = changeModel.UpdatePassword;//调用currentuser出现的问题
            user.BindingEmail = new Email();
            user.Password = changeModel.UpdatePassword;
            userRepository.UserSaveChanges(user); //更改密码出现问题cookie里面的密码与更改的密码发生冲突，试试出现添加cookie
        }

        public void UISaveForgetModel(ForgetModel forgetModel)
        {
            User user = mapper.Map<User>(forgetModel);
            user.BindingEmail = new Email();
            userRepository.UserSaveChanges(user);
        }

        public void UISaveResetModel(ResetModel resetModel)
        {
            User user =CurrentUser;
            user.BindingEmail = new Email();
            user.Password = resetModel.UpdatePassword;
            userRepository.UserSaveChanges(user);
        }
    }
}
