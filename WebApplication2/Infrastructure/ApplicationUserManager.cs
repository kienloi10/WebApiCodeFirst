using Api.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Infrastructure
{
	//public class ApplicationUserManager : UserManager<Account>
	//{
	//	public ApplicationUserManager(IUserStore<Account> store)
	//		: base(store)
	//	{
	//	}

	//	public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
	//	{
	//		ApiDBContext db = context.Get<ApiDBContext>();
	//		ApplicationUserManager userManager = new ApplicationUserManager(new UserStore<Account>(db));

	//		userManager.PasswordValidator = new ApplicationPasswordValidator
	//		{
	//			RequiredLength = 6,
	//			RequireNonLetterOrDigit = false,
	//			RequireDigit = false,
	//			RequireLowercase = true,
	//			RequireUppercase = true
	//		};

	//		userManager.UserValidator = new UserValidator<Account>(userManager)
	//		{
	//			AllowOnlyAlphanumericUserNames = false,
	//			RequireUniqueEmail = true
	//		};

	//		//userManager.EmailService = new EmailService();

	//		var dataProtectionProvider = options.DataProtectionProvider;
	//		if (dataProtectionProvider != null)
	//		{
	//			userManager.UserTokenProvider = new DataProtectorTokenProvider<Account>(dataProtectionProvider.Create("ASP.NET Identity"))
	//			{
	//				//Code for email confirmation and reset password life time
	//				TokenLifespan = TimeSpan.FromHours(6)
	//			};
	//		}
	//		return userManager;
	//	}
	//	//public override async Task<CustomPrincipal> CreateIdentityAsync(Account account, string authenticationType)
	//	//{
	//	//    return await Task.Run(() => cla)
	//	//}		
	//}
}