
using Counsel.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Counsel.Infrastructure.Repository
{
    public interface IRepository
    {
        Measure InsertMeasure(Measure model);
        Measure DeleteMeasure(long id);
        Measure GetMeasureById(int id);
        IQueryable<Measure> GetMeasure();
        Vote InsertVote(Vote model);
        IEnumerable<string> GetVoterName();
        void Dispose();
    }

    public class Repository : IRepository, IDisposable
    {
        private readonly TribcouncilmeasuresContext _context;
        private readonly DbSet<Measure> _dbSetMeasure;
        private readonly DbSet<Vote> _dbSetVote;

        public Repository()
        {
            _context = new TribcouncilmeasuresContext();
            _dbSetMeasure = _context.Measures;
            _dbSetVote = _context.Votes;
        }

        public Measure InsertMeasure(Measure model)
        {
            _dbSetMeasure.Add(model);
            _context.SaveChanges();
            return model;
        }

     

        public Measure DeleteMeasure(long id)
        {
            var found = _dbSetMeasure.Find(id);
            if (found != null)
            {
                _dbSetMeasure.Remove(found);
                _context.SaveChanges();
                return found;
            }

            return null;
        }

        public Measure GetMeasureById(int id)
        {
            return _dbSetMeasure.Find(id);
        }

        public IQueryable<Measure> GetMeasure()
        {
            return _dbSetMeasure;
        }

        public Vote InsertVote(Vote model)
        {
            _dbSetVote.Add(model);
            _context.SaveChanges();
            return model;
        }

        public IEnumerable<string> GetVoterName()
        {
            return _dbSetVote.Select(x => x.VoterName).ToList();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}