using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCarDal _creditCarDal;
        public CreditCardManager(ICreditCarDal creditCarDal)
        {
            _creditCarDal = creditCarDal;
        }
        public IResult AddCard(CreditCard creditCard)
        {
            SetTheCard(creditCard);
            IResult result = BusinessRules.Run(CheckIfHasCreditCarNumber(creditCard.CardId));
            if (result != null)
            {
                return result;
            }
            _creditCarDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);


        }

        public IResult DeleteCard(CreditCard creditCard)
        {
            _creditCarDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAllCard()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCarDal.GetAll());
        }

        public IDataResult<CreditCard> GetCardById(string id)
        {
            return new SuccessDataResult<CreditCard>(_creditCarDal.Get(c=>c.CardId==id));
        }
        public static CreditCard SetTheCard(CreditCard card)
        {
            DateTime date1 = new DateTime((DateTime.Now.Year + 10), DateTime.Now.Month, DateTime.Now.Day);
            card.CardId = CreateCreditCardNumber();
            card.Cvc = CreateCvc();
            card.ExpirationDate = date1;
            return card;
        }
        public static string CreateCreditCardNumber()
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                int sayi = random.Next(0, 9);
                sb.Append(sayi.ToString());
            }
            return sb.ToString();
        }
        public static string CreateCvc()
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                int sayi = random.Next(0, 9);
                sb.Append(sayi.ToString());
            }
            return sb.ToString();
        }
        private IResult CheckIfHasCreditCarNumber(string cardId)
        {
            var data = _creditCarDal.GetAll(c => c.CardId == cardId);
            if (data.Count==0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
            
        }

        public IDataResult<List<CreditCard>> GetAllCardByUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
