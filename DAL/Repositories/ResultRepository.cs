using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repositories
{
    class ResultRepository : ICRUD<Result>
    {
        private readonly TSDBContext tSDBContext;
        public ResultRepository(TSDBContext context)
        {
            tSDBContext = context;
        }
        public void Add(Result item)
        {
            tSDBContext.Results.Add(item);
        }

        public void Delete(int id)
        {
            var result = tSDBContext.Results.FirstOrDefault(x => x.Id == id);
            tSDBContext.Results.Remove(result);
        }

        public IEnumerable<Result> Find(Func<Result, bool> predicate)
        {
            return tSDBContext.Results.Include(x => x.UserTest).Include(x=>x.UserAnswers).Where(predicate);
        }

        public Result Get(int id)
        {
            return tSDBContext.Results.Include(x => x.UserTest).Include(x => x.UserAnswers).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Result> GetAll()
        {
            return tSDBContext.Results.Include(x => x.UserTest).Include(x => x.UserAnswers).AsEnumerable();
        }

        public void Update(Result item)
        {
            tSDBContext.Entry(item).State = EntityState.Modified;
        }
    }
}
