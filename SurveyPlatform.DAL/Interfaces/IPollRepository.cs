﻿using SurveyPlatform.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyPlatform.DAL.Interfaces
{
    public interface IPollRepository
    {
        Task<Poll> GetPollByIdAsync(Guid id);
        Task<Poll> GetPollByOptionIdAsync(Guid optionId); 
        Task<Poll> GetPollWithResponsesAsync(Guid pollId); 
        Task<Poll> AddPollResponseAsync(PollResponse response);
        Task<IEnumerable<Poll>> GetAllPollsAsync();
        Task CreatePollAsync(Poll poll);
        Task UpdatePollAsync(Poll poll);
        Task DeletePollAsync(Guid id);
    }
}
