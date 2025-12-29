using Microsoft.AspNetCore.Mvc.Rendering;
using SoftConsult.Models;
using System.ComponentModel.DataAnnotations;
namespace SoftConsult.ViewModel;
public class EmployeeViewModel
{
    public int Id{ get; set; }
    [Required]
    public string EmployeeCode { get; set; } = string.Empty;
    [Required]
    public string OPRCode { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int SurnameId { get; set; }
    [Required]
    [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Only letters are allowed")]
    [StringLength(20)]
    public string FatherName { get; set; } = string.Empty;
    [Required]
    [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "Only letters are allowed")]
    [StringLength(20)]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public string ProfilePictureUrl { get; set; } = string.Empty;
    [Required]
    [StringLength(15)]
    public string OfficeLocation { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int NationalityId { get; set; }
    public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required]
    public string CNIC { get; set; } = string.Empty;
    public DateOnly IDExpiryDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int SectionId { get; set; }
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int DepartmentId { get; set; }
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int DesignationId { get; set; }
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int ReligionId { get; set; }
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int GenderId { get; set; }
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int MaritalStatusId { get; set; }
    [Required]
    public int ClasificationId { get; set; }
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int BloodGroupId { get; set; }
    public bool IsHOD { get; set; }
    public bool IsAsstHOD { get; set; }
    [Required(ErrorMessage = "Please Select an Item")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select an Item")]
    public int LeavePolicyCodeId { get; set; }
    public DateOnly JoiningDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [Required(ErrorMessage = "Please Select JobStatusId")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select JobStatusId")]
    public int EmploymentStatusId { get; set; }
    [Required(ErrorMessage = "Please Select JobStatusId")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select JobStatusId")]
    public int JobStatusId { get; set; }
    public DateOnly? ConfirmationDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public DateOnly? DateOfLeaving { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public string Reason { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please Select Grade")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select Grade")]
    public int GradeId { get; set; }
    [Required(ErrorMessage = "Please Select Department Level")]
    [Range(1, int.MaxValue, ErrorMessage = "Please Select Department Level")]
    public int DepartmentLevelId { get; set; }
    public List<SelectListItem> DepartmentList { get; set; }
    public List<SelectListItem> DesignationsList { get; set; }
    public List<SelectListItem> NationalityList { get; set; }
    public List<SelectListItem> SectionList { get; set; }
    public List<SelectListItem> SurNameList { get; set; }
    public List<SelectListItem> DepartmentLevelList {  get; set; }
    public List<SelectListItem> LevelPolicyList { get; set; }
    public List<SelectListItem> GenderList { get; set; }
    public List<SelectListItem> MaritalStatusList { get; set; }
    public List<SelectListItem> BloodGroupList { get; set; }
    public  List<SelectListItem> ReligionList { get; set; } 
    public List<SelectListItem> Grades { get; set; }
    public List<SelectListItem> EmploymentStatusList { get; set; }
    public List<SelectListItem> JobStatusList { get; set; }
}