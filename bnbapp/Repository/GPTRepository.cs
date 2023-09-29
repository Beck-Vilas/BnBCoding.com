//this is a an api call to openai and will use an interface to return the value to register.cshtml.cs
using bnbapp.IRepository;
using DevExpress.XtraPrinting;

namespace bnbapp.Repository
{

    public class GPTRepository : IGPTRepository
    {
        public async Task<string> GetGPT(string url)
        {
            //i removed this feature do to using up all my credits :(
            //easy to add back in though




            return "Please confirm your email address for security reasons.  <a href='" + url+"'>Verify Your Account By Clicking Here</a>.";

        }
    }
}
