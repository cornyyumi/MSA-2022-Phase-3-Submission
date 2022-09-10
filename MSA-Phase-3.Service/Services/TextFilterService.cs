using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSA_Phase_3.Service.Services
{
    public class TextFilterService : ITextFilterService
    {
        public bool ContainsProfanity(string text)
        {
            var filter = new ProfanityFilter.ProfanityFilter();
            return filter.DetectAllProfanities(text).Count > 0 ? true : false;
        }
    }
}