using My_Fight_APP.ViewModel;
using System.Threading.Tasks;

namespace My_Fight_APP.Repositories
{
    public interface IAdminInterface
    {
        Task LoginAdmin(LoginModel login);
        Task Register (RegisterModel register);
    }
}
