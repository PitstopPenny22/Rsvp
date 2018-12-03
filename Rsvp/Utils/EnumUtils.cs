using Rsvp.Utils.Enums;
using System.Collections.Generic;

namespace Rsvp.Utils
{
    public class EnumUtils
    {
        public static Dictionary<RsvpStatus, int> EnumStatusToDbStatusIdMap = new Dictionary<RsvpStatus, int>
        {
            { RsvpStatus.Accepted, 4 },
            { RsvpStatus.Declined, 3 }
        };
    }
}