using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EmpManager.Entities
{
    public class SmallButtonModel
    {
        public string Action { get; set; }
        public string Text { get; set; }
        public string Glyph { get; set; }
        public string ButtonType { get; set; }
        public int? Id { get; set; }
        public int? AssetID { get; set; }
        public int? AttendanceID { get; set; }
        public int? ClientID { get; set; }
        public int? DepartmentID { get; set; }
        public int? DesignationID { get; set; }
        public int? EmployeeID { get; set; }
        public int? EmpSalaryID { get; set; }
        public int? HolidayID { get; set; }
        public int? LeadID { get; set; }
        public int? LeaveID { get; set; }
        public int? LeaveTypeID { get; set; }
        public int? PayrollID { get; set; }
        public int? SettingID { get; set; }
        public int? TerminationId { get; set; }
        public int? ThemeSettingID { get; set; }
        public int? TicketID { get; set; }


        public string ActionParameters
        {
            get
            {
                var param = new StringBuilder("?");
                if (Id != null && Id > 0)
                    param.Append(String.Format("{0}={1}&", "id", Id));

                if (AssetID != null && AssetID > 0)
                    param.Append(String.Format("{0}={1}&", "assetID", AssetID));

                if (AttendanceID != null && AttendanceID > 0)
                    param.Append(String.Format("{0}={1}&", "attendanceID", AttendanceID));

                if (ClientID != null && ClientID > 0)
                    param.Append(String.Format("{0}={1}&", "slientID", ClientID));

                if (DesignationID != null && DesignationID > 0)
                    param.Append(String.Format("{0}={1}&", "designationID", DesignationID));

                if (EmployeeID != null && EmployeeID > 0) 
                    param.Append(String.Format("{0}={1}&", "employeeID", EmployeeID));

                if (HolidayID != null && HolidayID > 0)
                    param.Append(String.Format("{0}={1}&", "holidayID", HolidayID));

                if (LeadID != null && LeadID > 0)
                    param.Append(String.Format("{0}={1}&", "leadID", LeadID));

                if (LeaveID != null && LeaveID > 0)
                    param.Append(String.Format("{0}={1}&", "leaveID", LeaveID));

                if (PayrollID != null && PayrollID > 0)
                    param.Append(String.Format("{0}={1}&", "payrollID", PayrollID));

                if (SettingID != null && SettingID > 0)
                    param.Append(String.Format("{0}={1}&", "settingID", SettingID));

                if (TerminationId != null && TerminationId > 0)
                    param.Append(String.Format("{0}={1}&", "terminationId", TerminationId));

                if (PayrollID != null && PayrollID > 0)
                    param.Append(String.Format("{0}={1}&", "payrollID", PayrollID));


                if (ThemeSettingID != null && ThemeSettingID > 0)
                    param.Append(String.Format("{0}={1}&", "themeSettingID", ThemeSettingID));

                if (TicketID != null && TicketID > 0)
                    param.Append(String.Format("{0}={1}&", "ticketID", TicketID));
                




                return param.ToString().Substring(0, param.Length - 1);
            }
        }

    }
}