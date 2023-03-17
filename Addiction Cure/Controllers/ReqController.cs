﻿using Addiction_Cure.core.Data;
using Addiction_Cure.core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Addiction_Cure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReqController : ControllerBase
    {
        private readonly IReqService reqService;
        public ReqController(IReqService reqService)
        {
            this.reqService = reqService;
        }

        [HttpGet]
        [Route("doctor/{id}")]
        public Req getbydocid(int id)
        {
            return reqService.getbydocid(id);
        }

        [HttpGet]
        [Route("patient/{id}")]
        public Req getbypatid(int id)
        {
            return reqService.getbypatid(id);
        }

        [HttpPost]
       public void createReq(Req req)
        {
            reqService.createReq(req);
        }

        [HttpPut]
       public void updateReq(Req req)
        {
            reqService.updateReq(req);
        }
    }
}
