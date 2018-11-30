using System.ComponentModel;

namespace Rsvp.Utils.Enums
{
    public enum HotelRequirementOptions
    {
        [Description("I do not require accommodation, thank you.")]
        None = 0,
        [Description("I would like hotel accommodation for Saturday only")]
        Saturday = 1,
        [Description("I would like hotel accommodation for Friday and Saturday.")]
        FridayAndSaturday = 2
    }
}