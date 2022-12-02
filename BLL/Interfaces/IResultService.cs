using DAL.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    interface IResultService
    {
        bool SaveResult(Result result);

        IList<Result> GetAllResults();

        IList<Result> GetGroupResults(Group group);

        IList<Result> GetUserResults(User user);

        Result CalculateResult(int userId, int testId, Test actualTest, DateTime date);
    }
}
