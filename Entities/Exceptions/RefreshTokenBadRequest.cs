﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class RefreshTokenBadRequest : BadRequestException
    {
        public RefreshTokenBadRequest() : base("Invalid Client Request. The tokenDto has invalid values") { }
        
    }
}