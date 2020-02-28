using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EmpManager.Entities
{
    public class EditButtonModel
    {
        public int Id { get; set; }
        public int AssetID { get; set; }
        public int AttendanceID { get; set; }
        public int ClientID { get; set; }
        public int DepartmentID { get; set; }
        public int DesignationID { get; set; }
        public int EmployeeID { get; set; }
        public int EmpSalaryID { get; set; }
        public int HolidayID { get; set; }
        public int LeadID { get; set; }
        public int LeaveID { get; set; }
        public int LeaveTypeID { get; set; }
        public int PayrollID { get; set; }
        public int SettingID { get; set; }
        public int TerminationId { get; set; }
        public int ThemeSettingID { get; set; }
        public int TicketID { get; set; }
        public string Link
        {
            get
            {
                var s = new StringBuilder("");
                if (AssetID > 0) s.Append(String.Format("{0}={1}&", "assetID", AssetID));

                if (AttendanceID > 0) s.Append(String.Format("{0}={1}&", "attendanceID", AttendanceID));

                if (ClientID > 0) s.Append(String.Format("{0}={1}&", "clientID", ClientID));

                if (DepartmentID > 0) s.Append(String.Format("{0}={1}&", "departmentID ", DepartmentID));

                if (DesignationID > 0) s.Append(String.Format("{0}={1}&", "designationID ", DesignationID));

                if (EmployeeID > 0) s.Append(String.Format("{0}={1}&", "employeeID ", EmployeeID));

                if (EmpSalaryID > 0) s.Append(String.Format("{0}={1}&", "empSalaryID ", EmpSalaryID));

                if (HolidayID > 0) s.Append(String.Format("{0}={1}&", "holidayID ", HolidayID));

                if (LeadID > 0) s.Append(String.Format("{0}={1}&", "leadID", LeadID));

                if (LeaveID > 0) s.Append(String.Format("{0}={1}&", "leaveID ", LeaveID));

                if (LeaveTypeID > 0) s.Append(String.Format("{0}={1}&", "leaveTypeID ", LeaveTypeID));

                if (PayrollID > 0) s.Append(String.Format("{0}={1}&", "payrollID ", PayrollID));
                if (SettingID > 0) s.Append(String.Format("{0}={1}&", "settingID ", SettingID));

                if (TerminationId > 0) s.Append(String.Format("{0}={1}&", "terminationId ", TerminationId));

                if (ThemeSettingID > 0) s.Append(String.Format("{0}={1}&", "themeSettingID ", ThemeSettingID));

                if (TicketID > 0) s.Append(String.Format("{0}={1}&", "ticketID  ", TicketID));



                return s.ToString().Substring(0, s.Length - 1);
            }
        }
    }
}