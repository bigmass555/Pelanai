using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public static class Helper
{
    public static class Time
    {
        public static int Month = GetMonthInt();
        public static string MonthName = GetMonthName(FullDate);
        public static int Date = GetTodayDate();
        public static string Day = GetDayOfWeek(GetFullDate().ToString());
        public static int Minute = GetMin();
        public static int Hour = GetHour();
        public static string Meridium = GetmMeridium();
        public static int Year = GetYear();
        public static DateTime FullDate = GetFullDate();
        public static string GetMonthName(DateTime date)
        {
            string month_str = date.ToString("MMMM");
            return month_str;
        }
        static int GetYear()
        {
            int year_int = DateTime.Now.Year;
            return year_int;
        }
        static int GetMonthInt()
        {
            return DateTime.Now.Month;
        }
        static int GetHour()
        {
            string hour_str = DateTime.Now.ToString("hhhh");
            int hour_int = int.Parse(hour_str);
            return hour_int;
        }
        static string GetmMeridium()
        {
            string meridum_str = DateTime.Now.ToString("tt");
            return meridum_str;
        }
        static int GetMin()
        {
            string minute_str = DateTime.Now.ToString("mm");
            int minute_int = int.Parse(minute_str);
            return minute_int;
        }
        static int GetTodayDate()
        {
            string date_str = DateTime.Now.ToString("dd");
            int date_int = int.Parse(date_str);
            return date_int;
        }
        static DateTime GetFullDate()
        {
            DateTime date = DateTime.Today;
            return date;
        }
        public static int GetDayInt(string dateInput)
        {
            DateTime datetime = DateTime.Parse(dateInput);
            List<string> days_list = new List<string>
        {
            "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
        };
            string day_str = datetime.DayOfWeek.ToString();
            int day_int = days_list.IndexOf(day_str);

            return day_int;
        }
        /// <summary>
        /// เปลี่ยนวันที่ให้กลายเป็นวันในสัปดาห์ ตามชื่อไง โธ่เว้ย!
        /// </summary>
        /// <param name="dateInput"> ใส่เดี่ยว </param>
        /// <returns></returns>
        public static string GetDayOfWeek(string dateInput)
        {
            string day_str = DateTime.Parse(dateInput).DayOfWeek.ToString();
            return day_str;
        }
        /// <summary>
        /// เอาไว้หาวันนั้นของเดือน เอ้ย! วันแรกของเดือน
        /// </summary>
        /// <param name="monthInt">รับค่าเดือน</param>
        /// <param name="yearInt">รับค่าปี</param>
        /// <returns></returns>
        public static int GetFirstDaysOfMonth(int monthInt, int yearInt)
        {
            string cal_sting_date = monthInt.ToString() + "/1/" + yearInt.ToString();
            int first_days_of_month = GetDayInt(cal_sting_date);
            return first_days_of_month;
        }
        /// <summary>
        /// ใช้คำนวญวันข้างหน้า
        /// </summary>
        /// <param name="dateInput">วันเริ่มต้น</param>
        /// <param name="num">วันที่ผ่านไป เช่น 3 หรือ -3</param>
        /// <returns></returns>
        public static DateTime CalDate(string dateInput, int num)
        {
            DateTime date = DateTime.Parse(dateInput);
            DateTime result_date = date + TimeSpan.Parse(num.ToString());
            return result_date;
        }
        /// <summary>
        /// บวกลบวันตามตัวเลขที่ส่งมา
        /// </summary>
        /// <param name="day"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        public static DateTime SubtractDate(DateTime date, int month = 0, int day = 0, int year = 0)
        {
            date = date.AddDays(day);
            date = date.AddMonths(month);
            date = date.AddYears(year);
            return date;
        }
        /// <summary>
        /// เปลี่ยนวันใน type of string ให้เป็น type of Datetime
        /// </summary>
        /// <param name="dateInput">วันที่</param>
        /// <returns></returns>
        public static DateTime GetDate(string dateInput)
        {
            DateTime result_date = DateTime.Parse(dateInput);
            return result_date;
        }
    }
}