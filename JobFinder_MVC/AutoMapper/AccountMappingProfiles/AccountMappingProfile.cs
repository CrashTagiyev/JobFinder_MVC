using AutoMapper;
using JobFinder_Domain.Users;
using JobFinder_Presentation.Areas.AllUsers.Models.ViewModels.AccountViewModels;

namespace JobFinder_Presentation.AutoMapper.AccountMappingProfiles
{
    public class AccountMappingProfile:Profile
	{
        public AccountMappingProfile()
        {
            CreateMap<RegisterVM, AppUser>();
        }
    }
}
