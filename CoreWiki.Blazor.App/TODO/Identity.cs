using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWiki.ViewModels
{
	public class FakeUser
	{
		public FakeIdentity Identity;
		public bool IsInRole(string role) => true;
		public class FakeIdentity
		{
			public bool IsAuthenticated;
			public FakeIdentity(bool authenticated)
			{
				IsAuthenticated = authenticated;
			}
		}
		public FakeUser(bool authenticated)
		{
			Identity = new FakeIdentity(authenticated);
		}
		public FakeUser()
		{
			Identity = new FakeIdentity(true);
		}
	}
	public class FakeUserManager
	{
		public FakeUser FindByEmailAsync(string email)
		{
			return new FakeUser();
		}
	}
}
