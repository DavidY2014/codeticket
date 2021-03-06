﻿using System;
using System.Collections.Generic;
using System.DrawingCore.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketCode.Helper.Verify;

namespace WebAPI.Areas.Dongfuh5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyCodeController : ControllerBase
    {
        /// <summary>
        /// 数字验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("NumberVerifyCode")]
        public FileContentResult NumberVerifyCode()
        {
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.NumberVerifyCode);
            byte[] codeImage = VerifyCodeHelper.GetSingleObj().CreateByteByImgVerifyCode(code, 100, 40);
            return File(codeImage, @"image/jpeg");
        }

        /// <summary>
        /// 字母验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("AbcVerifyCode")]
        public FileContentResult AbcVerifyCode()
        {
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.AbcVerifyCode);
            var bitmap = VerifyCodeHelper.GetSingleObj().CreateBitmapByImgVerifyCode(code, 100, 40);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            return File(stream.ToArray(), "image/png");
        }


        /// <summary>
        /// 混合验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("MixVerifyCode")]
        public FileContentResult MixVerifyCode()
        {
            string code = VerifyCodeHelper.GetSingleObj().CreateVerifyCode(VerifyCodeHelper.VerifyCodeType.MixVerifyCode);
            var bitmap = VerifyCodeHelper.GetSingleObj().CreateBitmapByImgVerifyCode(code, 100, 40);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");
        }





    }
}
