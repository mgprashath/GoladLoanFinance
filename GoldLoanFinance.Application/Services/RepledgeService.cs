using GoldLoanFinance.Application.Interfaces;
using GoldLoanFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldLoanFinance.Application.Services
{
    public class RepledgeService
    {
        private readonly IRepledgeRepository _repledgeRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RepledgeService(IRepledgeRepository repledgeRepository, ILoanRepository loanRepository, IUnitOfWork unitOfWork)
        {
            _repledgeRepository = repledgeRepository;
            _loanRepository = loanRepository;
            _unitOfWork = unitOfWork;
        }

        public bool CreateRepledge(RepledgeMaster repladgeMaster, List<RepledgeDetails> articleIds)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                _repledgeRepository.CreateRepledge(repladgeMaster);
                _loanRepository.MarkAsPledged(articleIds);

                _unitOfWork.CommitTransaction();
                return true;

            }
            catch (Exception)
            {
                _unitOfWork.RollbackTransaction();
                return false;
            }
        }

        public bool UpdateRepledge(RepledgeMaster repladgeMaster, List<RepledgeDetails> selected, List<RepledgeDetails> notSelected)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                _repledgeRepository.UpdateRepledge(repladgeMaster);
                _loanRepository.MarkAsPledged(selected);
                _loanRepository.RemovePledged(notSelected);

                _unitOfWork.CommitTransaction();
                return true;

            }
            catch (Exception)
            {
                _unitOfWork.RollbackTransaction();
                return false;
            }
        }

        public bool DeleteRepledge(int id)
        {
            try
            {
                List<RepledgeDetails> reset = _repledgeRepository.GetArticleByRepledgeId(id)
                   .Select(u => new RepledgeDetails { ArticleId = u.ArticleId }).ToList();
                _unitOfWork.BeginTransaction();

                _repledgeRepository.DeleteRepledge(id);
                _loanRepository.RemovePledged(reset);

                _unitOfWork.CommitTransaction();
                return true;

            }
            catch (Exception)
            {
                _unitOfWork.RollbackTransaction();
                return false;
            }
        }

        public List<RepledgeMaster> GetAllRepledged()
        {
            return _repledgeRepository.GetAllRepledged();
        }

        public RepledgeMaster? GetRepledgeItemsById(int id)
        {
            return _repledgeRepository.GetRepledgeItemsById(id);
        }
    }
}
