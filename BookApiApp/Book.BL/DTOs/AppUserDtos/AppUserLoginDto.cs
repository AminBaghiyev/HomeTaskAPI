using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.DTOs.AppUserDtos
{
    public record AppUserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
