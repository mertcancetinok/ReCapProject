using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<List<CreditCard>> GetAllCard();
        IDataResult<List<CreditCard>> GetAllCardByUser(int id);
        IResult AddCard(CreditCard creditCard);
        IDataResult<CreditCard> GetCardById(string cardId);
        IResult DeleteCard(CreditCard creditCard);
    }
}
