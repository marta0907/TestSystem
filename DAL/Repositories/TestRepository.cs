using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    class TestRepository : ICRUD<Test>
    {
        private readonly TSDBContext tSDBContext;
        public TestRepository(TSDBContext context)
        {
            tSDBContext = context;
        }
        public void Add(Test item)
        {
            tSDBContext.Tests.Add(item);
            foreach(var q in item.Questions)
            {
                tSDBContext.Questions.Add(q);
                foreach(var a in q.Answers)
                {
                    tSDBContext.Answers.Add(a);
                }
            }
        }

        public void Delete(int id)
        {
            var item = tSDBContext.Tests.FirstOrDefault(x => x.Id == id);
            foreach (var q in item.Questions)
            {
                foreach (var a in q.Answers)
                {
                    tSDBContext.Answers.Remove(a);
                }

                tSDBContext.Questions.Remove(q);
            }
            tSDBContext.Tests.Remove(item);
        }

        public IEnumerable<Test> Find(Func<Test, bool> predicate)
        {
            var tests = tSDBContext.Tests.Include(x => x.Questions).Include(x => x.UserTests).Where(predicate);
            foreach (var test in tests)
            {
                foreach (var question in test.Questions)
                {
                    question.Answers = tSDBContext.Questions.Include(x => x.Answers).FirstOrDefault(x => x.Id == question.Id).Answers;
                }
            }
            return tests;
        }

        public Test Get(int id)
        {
            var test = tSDBContext.Tests.Include(x => x.Questions).Include(x => x.UserTests).FirstOrDefault(x => x.Id == id);
            foreach(var question in test.Questions)
            {
                question.Answers = tSDBContext.Questions.Include(x => x.Answers).FirstOrDefault(x => x.Id == question.Id).Answers;
            }
            return test;
        }

        public IEnumerable<Test> GetAll()
        {
            var tests = tSDBContext.Tests.Include(x => x.Questions).Include(x => x.UserTests);
            foreach (var test in tests)
            {
                foreach (var question in test.Questions)
                {
                    question.Answers = tSDBContext.Questions.Include(x => x.Answers).FirstOrDefault(x => x.Id == question.Id).Answers;
                }
            }
            return tests;
        }

        public void Update(Test item)
        {
           tSDBContext.Entry(item).State = EntityState.Modified;
        }
    }
}
