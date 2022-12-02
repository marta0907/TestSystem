using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    public class ResultService : IResultService
    {

        private readonly IUnitOfWork unitOfWork;
        public ResultService(IUnitOfWork work)
        {
            unitOfWork = work;
        }
        public ResultService():this(new UnitOfWork()) { }

        public IList<Result> GetAllResults()
        {
            try
            {
                return unitOfWork.Results.GetAll().ToList();
            }
            catch { }
            return null;
        }

        public IList<Result> GetGroupResults(Group group)
        {
            try
            {
                return unitOfWork.Results.Find(x => group.GroupUsers.Any(g => g.UserId == x.UserTest.UserId)).ToList();
            }
            catch { }
            return null;
        }

        public IList<Result> GetUserResults(User user)
        {
            try
            {
                return unitOfWork.Results.Find(x => user.Id == x.UserTest.UserId).ToList();
            }
            catch { }
            return null;
        }

        public bool SaveResult(Result result)
        {
            bool saved;
            try
            {
                unitOfWork.Results.Add(result);
                unitOfWork.Save();
                saved = true;
            }
            catch(Exception e) { 
                saved = false;
            }
            return saved;
        }

        public Result CalculateResult(int userId, int testId, Test actualTest, DateTime date)
        {
            var testUser = unitOfWork
                .UserTests
                .Find(x => x.TestId == testId && x.UserId == userId)
                .FirstOrDefault();

            if (testUser == null) return null;

            var expectedTest = unitOfWork.Tests.Get(testId);
            var points = 0.0;

            Result result = new Result();
            result.UserAnswers = new List<Report>();

            for (int i = 0; i < expectedTest.Questions.Count; i++)
            {
                for (int j = 0; j < actualTest.Questions.Count; j++)
                {
                    if (i != j) continue;

                    var actualAnswer = new StringBuilder();
                    actualTest
                        .Questions[j]
                        .Answers
                        .Where(x => x.IsTrue == true)
                        .ToList()
                        .ForEach(x => actualAnswer.Append(x.AnswerText));

                    var expectedAnswer = new StringBuilder();
                    expectedTest
                        .Questions[j]
                        .Answers
                        .Where(x => x.IsTrue == true)
                        .ToList()
                        .ForEach(x => expectedAnswer.Append(x.AnswerText));

                    points += actualAnswer.ToString() == expectedAnswer.ToString() ? expectedTest.Questions[j].NumOfPoints : 0;

                    Report report = new Report()
                    {
                        ActualAnswer = actualAnswer.ToString(),
                        ExpectedAnswer = expectedAnswer.ToString()
                    };
                    result.UserAnswers.Add(report);
                }
            }
            int maxPoints = 0;
            expectedTest.Questions.ToList().ForEach(x => maxPoints += x.NumOfPoints);
            var passed = ((float)points / (float)maxPoints) >= expectedTest.MinPassPercentage;

            result.PointsGained = (int)points;
            result.IsPassed = passed;
            result.UserTestId = testUser.Id;
            result.Date = date;

            return result;
        }
    }
}
