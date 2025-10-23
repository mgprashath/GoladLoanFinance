using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Domain.Entities;
using GoldLoanFinance.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Infrastructure.Repositories
{
    public class RepledgeRepository: IRepledgeRepository
    {
        private readonly ApplicationDbContext _db;

        public RepledgeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateRepledge(RepledgeMaster repladgeMaster)
        {
            _db.RepledgeMaster.Add(repladgeMaster);
            return _db.SaveChanges() > 0;
        }

        public bool UpdateRepledge(RepledgeMaster repladgeMaster)
        {
            var oldRepledgeDetails = _db.RepledgeDetails.Where(x => x.RepledgeId == repladgeMaster.RepledgeId);
            _db.RepledgeDetails.RemoveRange(oldRepledgeDetails);
            _db.RepledgeMaster.Update(repladgeMaster);
            return _db.SaveChanges() > 0;
        }

        public bool DeleteRepledge(int id)
        {
            RepledgeMaster? repledgeMaster =_db.RepledgeMaster.Find(id);

            if (repledgeMaster != null)
            {
                _db.Remove(repledgeMaster);
            }

            return _db.SaveChanges() > 0;
        }

        public List<RepledgeMaster> GetAllRepledged()
        {
            return _db.RepledgeMaster.Include(u => u.RepledgeDetails).Include(u => u.Bank).ToList();
        }

        public RepledgeMaster? GetRepledgeItemsById(int id)
        {
            return _db.RepledgeMaster.Where(u=>u.RepledgeId==id).Include(u=>u.RepledgeDetails)
                .ThenInclude(u=>u.LoanDetails).ThenInclude(u=>u.LoanMaster).FirstOrDefault();
        }

        public List<RepledgeDetails> GetArticleByRepledgeId(int id)
        {
            return _db.RepledgeDetails.Where(u => u.RepledgeId==id).ToList();
        }
    }
}
