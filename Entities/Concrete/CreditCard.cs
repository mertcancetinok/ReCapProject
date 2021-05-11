using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public string CardId { get; set; }
        public string Cvc { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }
    }
}
