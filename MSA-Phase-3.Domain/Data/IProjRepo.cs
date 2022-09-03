using MSA_Phase_3.Domain.Models;

namespace MSA_Phase_3.Domain.Data
{
    public interface IProjRepo
    {
        User addUser(string username);
    }
}
