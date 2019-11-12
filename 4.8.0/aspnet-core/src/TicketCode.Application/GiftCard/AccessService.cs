using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicketCode.GiftCard.Model;
using WebAPI.ORM.GiftCardModels;

namespace TicketCode.GiftCard
{
    public class AccessService : IAccessService
    {
        public ReturnResult ExchangeGiftCard(string GiftCardId, string GiftCardSecret, int CustomCode)
        {
            throw new NotImplementedException();
        }

        public CustomDeliveryModel GetCustomerDetail(int CustomerCode)
        {
            throw new NotImplementedException();
        }

        public List<GiftCardModel> GetGiftCard(int CustomerCode)
        {
            throw new NotImplementedException();
        }

        public ReturnResult InsertNewAddress(int customerId, int index, string province, string city, string district, string address)
        {
            throw new NotImplementedException();
        }

        public ReturnResult Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public ReturnResult Register(string username, string password, string activationCode)
        {
            throw new NotImplementedException();
        }

        public ReturnResult RemoveAddress(int customerId, int index)
        {
            throw new NotImplementedException();
        }

        public ReturnResult UpdateAddress(int customerId, int index, string province, string city, string district, string address)
        {
            throw new NotImplementedException();
        }
    }
}
