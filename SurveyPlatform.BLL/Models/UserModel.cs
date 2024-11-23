﻿using SurveyPlatform.DAL.Entities;

namespace SurveyPlatform.BLL.Models;

public class UserModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<string> Roles { get; set; } = new List<string> { "User" };
    public ICollection<PollResponse>? Responses { get; set; }
    public ICollection<Poll>? Polls { get; set; }
}