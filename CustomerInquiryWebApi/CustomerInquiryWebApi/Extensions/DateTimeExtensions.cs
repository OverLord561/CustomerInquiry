using System;

namespace CustomerInquiryWebApi.Extensions
{
    public static class DateTimeExtensions
    {
        private const string ddMMyyyy_hhmm = "dd:MM:yyyy hh:mm";

        public static string DateTimeTo_ddMMyyyy_hhmm(this DateTime time)
        {
            return time.ToString(ddMMyyyy_hhmm);
        }
    }
}
