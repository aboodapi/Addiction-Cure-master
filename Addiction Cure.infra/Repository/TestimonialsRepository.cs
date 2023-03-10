using Addiction_Cure.core.Common;
using Addiction_Cure.core.Data;
using Addiction_Cure.core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Addiction_Cure.infra.Repository
{
    public class TestimonialsRepository : ITestimonialsRepository
    {



        private readonly IDBContext _DbContext;





        // constructor with dependency injection from domain entity layer
        public TestimonialsRepository(IDBContext DbContext)
        {
            _DbContext = DbContext;
        }








        // IMPLEMENTAION OF  GetAllTestimonialAC


        public List<Testemonialac> GetAllTestimonialAC()
        {
            IEnumerable<Testemonialac> result = _DbContext.Connection.Query<Testemonialac>("TESTIMONIALAC_PACKAGE.GetAllTestimonialAC",
                                       commandType: CommandType.StoredProcedure);

            return result.ToList();
        }









        // IMPLEMENTAION OF  GetTestimonialByIdAC


        public Testemonialac GetTestimonialByIdAC(int id)
        {
            var p = new DynamicParameters();

            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Testemonialac> result = _DbContext.Connection.Query<Testemonialac>("TESTIMONIALAC_PACKAGE.GetTestimonialByIdAC", p,
                            commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }









        // IMPLEMENTAION OF  CreateTestimonialAC


        public void CreateTestimonialAC(Testemonialac testemonialac)
        {
            var p = new DynamicParameters();

            p.Add("NAMEAC", testemonialac.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEPATHAC", testemonialac.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STATUSAC", testemonialac.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MESSAGEUSERAC", testemonialac.Messageuser, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PATIENTIDAC", testemonialac.Patientid, dbType: DbType.Int32, direction: ParameterDirection.Input);
          

            // you can remove the var result its ok if you dont want to know number of rows affected 
            var result = _DbContext.Connection.Execute("TESTIMONIALAC_PACKAGE.CreateTestimonialAC", p,
                            commandType: CommandType.StoredProcedure);
        }









        // IMPLEMENTAION OF  UpdateTestimonialAC


        public void UpdateTestimonialAC(Testemonialac testemonialac)
        {
            var p = new DynamicParameters();

            p.Add("ID",testemonialac.Tesemonialid,dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("NAMEAC", testemonialac.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("IMAGEPATHAC", testemonialac.ImagePath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STATUSAC", testemonialac.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("MESSAGEUSERAC", testemonialac.Messageuser, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PATIENTIDAC", testemonialac.Patientid, dbType: DbType.Int32, direction: ParameterDirection.Input);


            // you can remove the var result its ok if you dont want to know number of rows affected 
            var result = _DbContext.Connection.Execute("TESTIMONIALAC_PACKAGE.UpdateTestimonialAC", p,
                            commandType: CommandType.StoredProcedure);
        }









        // IMPLEMENTAION OF  DeleteTestimonialAC


        public void DeleteTestimonialAC(int id)
        {
            var p = new DynamicParameters();
            p.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            _DbContext.Connection.Execute("TESTIMONIALAC_PACKAGE.DeleteTestimonialAC", p,
                commandType: CommandType.StoredProcedure);
        }

       

      

       
    }
}
