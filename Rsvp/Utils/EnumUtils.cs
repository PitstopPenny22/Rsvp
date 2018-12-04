using Rsvp.Utils.Enums;
using System.Collections.Generic;

namespace Rsvp.Utils
{
    public static class EnumUtils
    {
        public const int PendingReplyId = 2;

        public static Dictionary<RsvpStatus, int> EnumStatusToDbStatusIdMap = new Dictionary<RsvpStatus, int>
        {
            { RsvpStatus.Accepted, 4 },
            { RsvpStatus.Declined, 3 }
        };
    }
}