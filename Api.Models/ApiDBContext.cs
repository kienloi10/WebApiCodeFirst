using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
	public class ApiDBContext : DbContext
	{
		public ApiDBContext() : base("ApiConnection")
		{

		}
		static ApiDBContext()
		{
			Database.SetInitializer<ApiDBContext>(new IdentityDbInit());
		}

		public static ApiDBContext Create()
		{
			return new ApiDBContext();
		}

		//public DbSet<Course> Courses { get; set; }
		
		//public DbSet<MonHoc> Mon { get; set; }
		//public DbSet<SinhVienMonHoc> SinhVienMonHocs { get; set; }
        public DbSet<ChuNhiem> ChuNhiems { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<GiaoVien> GiaoViens { get; set; }

        public override int SaveChanges()
		{
			//

			return base.SaveChanges();
		}
	}

	internal class IdentityDbInit : DropCreateDatabaseIfModelChanges<ApiDBContext>
	{
		/*public void Seed(ApiDBContext context)
		{
			PerformInit();
			base.Seed(context);
		}*/

		public void PerformInit()
		{

		}
	}
}
