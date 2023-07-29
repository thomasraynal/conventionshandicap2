using ConventionsHandicap.App.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ConventionsHandicap.Controller.Dto
{

    public class DepartmentValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (null == value)
            {
                return false;
            }

            return true;

            //return Consts.Academies.SelectMany(academy => academy.Departments).Any(department => department == $"{value}");
        }

    }

    public class AcademyValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (null == value)
            {
                return false;
            }

            return true;

            //return Consts.Academies.Any(academy => academy.Name == $"{value}");
        }

    }

}
