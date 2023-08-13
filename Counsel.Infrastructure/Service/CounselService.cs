using Counsel.DAL.Models;
using Counsel.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Counsel.Infrastructure.Service
{
    public interface IService
    {
        Measure InsertMeasure(Measure model);
        Measure DeleteMeasure(long id);
        Measure GetMeasureById(int id);
        IQueryable<Measure> GetMeasure();
        Vote InsertVote(Vote model);
        IEnumerable<string> GetVoterName();


        void Dispose();
    }

    public class CounselService : IService, IDisposable
    {
        private readonly ILogger<CounselService> logger;
        private readonly IRepository repository;

        public CounselService(
            ILogger<CounselService> logger,
            IRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        public Measure InsertMeasure(Measure model)
        {
            return repository.InsertMeasure(model);
        }


        public Measure DeleteMeasure(long id)
        {
            return repository.DeleteMeasure(id);
        }

        public Measure GetMeasureById(int id)
        {
            return repository.GetMeasureById(id);
        }

        public IQueryable<Measure> GetMeasure()
        {
            return repository.GetMeasure();
        }

        public Vote InsertVote(Vote model)
        {
            return repository.InsertVote(model);
        }

        public IEnumerable<string> GetVoterName()
        {
            return repository.GetVoterName();
        }
        public void Dispose()
        {
            repository.Dispose();
        }
    }
}