using GoldLoanFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Application.Interfaces
{
    public interface IRepledgeRepository
    {
        bool CreateRepledge(RepledgeMaster repladgeMaster);
        List<RepledgeMaster> GetAllRepledged();
        RepledgeMaster? GetRepledgeItemsById(int id);
        bool UpdateRepledge(RepledgeMaster repladgeMaster);
        List<RepledgeDetails> GetArticleByRepledgeId(int id);
        bool DeleteRepledge(int id);
    }
}
