using Addiction_Cure.core.Common;
using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Dapper;
using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Addiction_Cure.infra.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDBContext dbContext;
        public PaymentRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

      public  List<Paymentac> GetAllPayment()
        {
            IEnumerable<Paymentac> result = dbContext.Connection.Query<Paymentac>("paymentac_pack.GetAllpaymentac", commandType:CommandType.StoredProcedure);
            return result.ToList();
        }
      public  void CreatePayment(Paymentac paymentac)
        {
            var p = new DynamicParameters();
            p.Add("Amountac", paymentac.Amount, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Paydateac", paymentac.Paydate, dbType: DbType.Date, ParameterDirection.Input);
            p.Add("Patientidac", paymentac.Patientid, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("paymentac_pack.Createpaymentac", p, commandType: CommandType.StoredProcedure);
        }
      public  void UpdatePayment(Paymentac paymentac)
        {

            var p = new DynamicParameters();
            p.Add("Paymentidac", paymentac.Paymentid, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Amountac", paymentac.Amount, dbType: DbType.Int32, ParameterDirection.Input);
            p.Add("Paydateac", paymentac.Paydate, dbType: DbType.Date, ParameterDirection.Input);
            p.Add("Patientidac", paymentac.Patientid, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("paymentac_pack.Updatepaymentac", p, commandType: CommandType.StoredProcedure);

        }
      public  void DeletePayment(int id)
        {
            var p = new DynamicParameters();
            p.Add("Paymentidac", id, dbType: DbType.Int32, ParameterDirection.Input);
            dbContext.Connection.Execute("paymentac_pack.Deletepaymentac", p, commandType: CommandType.StoredProcedure);
        }
    }
}
