using Bouncer;

namespace Rsvp.Utils
{
    public static class ConnectionStringUtils
    {
        public static string GetConnectionString()
        {
            return new BouncerService().GetPass();
        }
    }
}