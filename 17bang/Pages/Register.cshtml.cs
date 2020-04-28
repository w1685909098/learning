using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using _17bang.Pages.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _17bang.Pages
{
    [BindProperties]
    public class RegisterModel : PageModel
    {
       
        private readonly ILogger<IndexModel> _logger;

        public RegisterModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public User User { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public void OnGet()
        {
            
        }
        public void OnPost()
        {

        }
    }
}
