﻿using Addiction_Cure.core.Common;
using Addiction_Cure.core.Data;
using Addiction_Cure.core.DTO;
using Addiction_Cure.core.Repository;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Addiction_Cure.infra.Repository
{
    public class ReqRepository : IReqRepository
    {

        private readonly IDBContext dbContext;
        public ReqRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Req getbydocid(int id){
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, ParameterDirection.Input);
            var x = dbContext.Connection.Query<Req>("req_pack.getbydocId", p, commandType: CommandType.StoredProcedure);
            return x.FirstOrDefault();
        }

        public Req getbypatid(int id) {
            var p = new DynamicParameters();
            p.Add("id", id, dbType: DbType.Int32, ParameterDirection.Input);
            var x = dbContext.Connection.Query<Req>("req_pack.getbypatId", p, commandType: CommandType.StoredProcedure);
            return x.FirstOrDefault();
        }

       public void createReq(Req req)
        {
            var p = new DynamicParameters();
            p.Add("statusac", req.Status, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Patientidac", req.Patientid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Doctoridac", req.Doctorid, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("patientac_package.CreatePatient", p, commandType: CommandType.StoredProcedure);

        }
       public void updateReq(Req req){
            var p = new DynamicParameters();
            p.Add("id", req.Reqid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("statusac", req.Status, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Patientidac", req.Patientid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Doctoridac", req.Doctorid, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("patientac_package.CreatePatient", p, commandType: CommandType.StoredProcedure);

        }

    }
}