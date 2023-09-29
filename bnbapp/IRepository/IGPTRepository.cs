using System;

namespace bnbapp.IRepository
{
    public interface IGPTRepository
    {
        Task<string> GetGPT(string url);
    }
}
// Compare this snippet from Repository\StripeRepository.cs:
// using System;
//where to get