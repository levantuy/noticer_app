﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Noticer.Api.Models
{
    public class TokenModel
    {        
        public string Token { get; set; }     
        public DateTime Expiration { get; set; }
    }
}