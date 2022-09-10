using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSA_Phase_3.Service.Services
{
    public interface ITextFilterService
    {
        bool ContainsProfanity(string text);
    }
}