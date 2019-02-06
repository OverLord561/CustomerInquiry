using System;

namespace CustomerInquiryWebApi.Extensions
{
    public static class DateTimeExtensions
    {
        public static string DateTimeTo_ddMMyyyy_hhmm(this DateTime time)
        {
            return time.ToString("dd:MM:yyyy hh:mm");
        }
    }
}
