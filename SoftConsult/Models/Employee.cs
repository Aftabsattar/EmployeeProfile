using System.ComponentModel.DataAnnotations;

namespace SoftConsult.Models;

    public class Employee
    {   
    public int Id { get; set; }
    [Required]
    public string EmployeeCode { get; set; } = string.Empty;
    [Required]
    public string OPRCode { get; set; } = string.Empty;
    [Required]
    public int SurnameId { get; set; }
    [Required]
    [StringLength(50)]
    public string Surname { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string FatherName { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string FullName { get; set; } = string.Empty;
    [Required]
    public string ProfilePictureUrl { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string OfficeLocation { get; set; } = string.Empty;
    [Required]
    public int DepartmentId { get; set; }
    [Required]
    [StringLength(50)]
    public string Department { get; set; } = string.Empty;
    [Required]
    [StringLength(50)]
    public string Nationality { get; set; } = string.Empty;
    [Required]
    public int NationalityId { get; set; }
    public DateOnly DateOfBirth { get; set; }
    [Required]
    [StringLength(20)]
    public string CNIC { get; set; } = string.Empty;
    public DateOnly IDExpiryDate { get; set; }
    [Required]
    public int SectionId { get; set; }
    [Required]
    [StringLength(50)]
    public string Section { get; set; } = string.Empty;
    [Required]
    public int DesignationId { get; set; }
    [Required]
    [StringLength(50)]
    public string DesignationName { get; set; } = string.Empty;
    [Required]
    public int ReligionId { get; set; }
    [Required]
    [StringLength(20)]
    public string Religion { get; set; } = string.Empty;
    [Required]
    public int GenderId { get; set; }
    [Required]
    [StringLength(10)]
    public string Gender { get; set; } = string.Empty;
    [Required]
    public int MaritalStatusId { get; set; }
    [Required]
    [StringLength(10)]
    public string MaritalStatus { get; set; } = string.Empty;
    [Required]
    public int BloodGroupId { get; set; }
    [Required]
    public string Group { get; set; } = string.Empty;
    [Required]
    public bool IsHOD { get; set; }
    [Required]
    public bool IsAsstHOD { get; set; }
    [Required]
    public int LeavePolicyCodeId { get; set; }
    public DateOnly JoiningDate { get; set; }
    [Required]
    public int EmploymentStatusId { get; set; }
    [Required]
    [StringLength(50)]
    public string EmploymentStatus { get; set; } = string.Empty;
    [Required]
    public int JobStatusId { get; set; }
    [Required]
    [StringLength(50)]
    public string JobStatus { get; set; } = string.Empty;
    public DateOnly? ConfirmationDate { get; set; }
    public DateOnly? DateOfLeaving { get; set; }
    [Required]
    [StringLength(100)]
    public string Reason { get; set; } = string.Empty;
    [Required]
    public int GradeId { get; set; }
    [Required]
    public string EGrade { get; set; } = string.Empty;
    [Required]
    public int DepartmentLevelId { get; set; }
    [Required]
    [StringLength(20)]
    public string LevelName { get; set; } = string.Empty;
}