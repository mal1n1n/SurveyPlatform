﻿using System.ComponentModel.DataAnnotations;

namespace SurveyPlatform.Models.Requests
{
    public class LoginUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
