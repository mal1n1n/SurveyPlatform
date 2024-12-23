﻿namespace SurveyPlatform.API.DTOs.Requests;
public class CreatePollRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Options { get; set; }
    public Guid AuthorID { get; set; }
}
