﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _17bang.Pages.Password
{
    [BindProperties]
    public class ForgetModel : PageModel
    {
       public PasswordForgetModel Model { get; set; }
        public void OnGet()
        {

        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                return;
            }

        }
    }
}