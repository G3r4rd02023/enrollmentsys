﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace enrollmentsys.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile, string folder);
    }
}
