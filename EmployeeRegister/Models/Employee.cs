using EmployeeRegister.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeRegister.Models
{
    public class Employee
    {
        private readonly List<DepartmentList> _departments;
        private RegisterContext db = new RegisterContext();

        public Employee()
        {
            _departments = db.DepartmentList.ToList();
        }

        public int Id { get; set; }
        [StringLength(30,ErrorMessage = "Should be less than 30")]
        [Required(ErrorMessage = "Ha-ha Let's try again")]
        public string FirstName { get; set; }
        [StringLength(30, ErrorMessage ="Should be less than 30")]
        [Required(ErrorMessage = "Ha-ha Let's try again")]
        public string LastName { get; set; }
        public int Salary { get; set; }
        public string  Position { get; set; }
        public string  Department { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [RestrictedYear]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",
                ApplyFormatInEditMode = true)]
        [RestrictedDate(ErrorMessage = "Ha-ha Let's try again 2")]
        public DateTime JobDate { get; set; }


        //Departments
        public IEnumerable<SelectListItem> Departments
        {
            get { return new SelectList(_departments, "Id", "Name"); }
        }
    }
    //Positions
    public enum Positions
    {
        Developer,
        Manager
    }
    public class RestrictedDate : ValidationAttribute
    {
        public RestrictedDate(): base ("{0} Is to early")
        {

        }

        protected override ValidationResult IsValid(object value,ValidationContext Context )
        {
            if (value!=null)
            {
                DateTime _date = (DateTime)value;
                if (_date < DateTime.Now)
                {
                    var errorMessage = FormatErrorMessage(Context.DisplayName);
                    return new ValidationResult(errorMessage);
                }

            }
            return ValidationResult.Success;  
        }
    }

    public class RestrictedYear : ValidationAttribute
    {
        public RestrictedYear() : base("{0} You are perfect!!!")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext Context)
        {
            if (value != null)
            {
                DateTime _date = (DateTime)value;
                if (_date.Year > DateTime.Now.Year-10 || _date.Year< DateTime.Now.Year - 70)
                {
                    var errorMessage = FormatErrorMessage(Context.DisplayName);
                    return new ValidationResult(errorMessage);
                }

            }
            return ValidationResult.Success;
        }
    }
}