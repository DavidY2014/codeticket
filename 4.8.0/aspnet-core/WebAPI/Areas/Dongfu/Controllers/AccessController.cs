﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketCode.GiftCard;
using TicketCode.GiftCard.Model;

namespace WebAPI.Areas.Dongfu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly IAccessService _accessService;
        public AccessController(IAccessService accessService)
        {
            _accessService = accessService;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>

        [HttpPost("Login")]
        public ReturnResult Login(string Username,string Password)
        {
            var ret =  _accessService.Login(Username, Password);

            return ret;
        }

        [HttpPost("Register")]
        public ReturnResult Register(string username, string password, string activationCode)
        {
            var ret =  _accessService.Register( username,  password,  activationCode);
            return ret;

        }

        /// <summary>
        /// 提货券兑换
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("ExchangeGiftCard")]
        public ReturnResult ExchangeGiftCard(string GiftCardId, string GiftCardSecret, int CustomCode)
        {

            return _accessService.ExchangeGiftCard(GiftCardId, GiftCardSecret, CustomCode);
        }

        /// <summary>
        /// 获取用户的礼品卡信息s
        /// </summary>
        /// <param name="customCode"></param>
        /// <returns></returns>
        [HttpGet("GetAllGiftCards")]
        public List<GiftCardModel> GetAllGiftCards(int CustomCode)
        {

            return _accessService.GetGiftCard(CustomCode);
        }

        /// <summary>
        /// 获取用户的发货信息
        /// </summary>
        /// <param name="customCode"></param>
        /// <returns></returns>
        [HttpGet("GetCustomerInfo")]
        public CustomDeliveryModel GetCustomerInfo(int CustomerCode)
        {

            return _accessService.GetCustomerDetail(CustomerCode);
        }

        /// <summary>
        /// 为用户增加新的地址
        /// </summary>
        /// <param name="model"></param>
        /// <param name="CustomCode"></param>
        /// <returns></returns>
        [HttpPost("AddNewAddressInfo")]
        public ReturnResult AddNewAddressInfo(int customerId, int index, string province, string city, string district, string address)
        {

            return _accessService.InsertNewAddress(customerId, index, province, city, district, address);
        }


    }
}
