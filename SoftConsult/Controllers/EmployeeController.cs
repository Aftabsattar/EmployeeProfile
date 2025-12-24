using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftConsult.Context;
using SoftConsult.IService;
using SoftConsult.ViewModel;

namespace SoftConsult.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeInformation;
    private readonly AppDbContext _appDbContext;
    public EmployeeController(AppDbContext appDbContext, IEmployeeService employeeInformation)
    {
        _employeeInformation = employeeInformation;
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> CreateEmployee()
    {
        var vm = new EmployeeViewModel
        {
            SurNameList = await _appDbContext.SurName.FromSqlRaw("EXEC dbo.sp_GetSurName").AsNoTracking().ToListAsync(),
            NationalityList = await _appDbContext.Nationality.FromSqlRaw("EXEC sp_GetNationality").AsNoTracking().ToListAsync(),
            SectionList = await _appDbContext.Sections.FromSqlRaw("EXEC dbo.sp_GetSection").AsNoTracking().ToListAsync(),
            DepartmentLevelList = await _appDbContext.DepartmentLevels.FromSqlRaw("Exec dbo.sp_GetDepartmentLevel").AsNoTracking().ToListAsync(),
            LevelPolicyList = await _appDbContext.LevelPolicie.FromSqlRaw("EXEC dbo.sp_GetLevelPolicy").AsNoTracking().ToListAsync(),
            ReligionList = await _appDbContext.Religion.FromSqlRaw("EXEC sp_GetReligion").AsNoTracking().ToListAsync(),
            GenderList = await _appDbContext.Gender.FromSqlRaw("EXEC dbo.sp_GetGender").AsNoTracking().ToListAsync(),
            MaritalStatusList = await _appDbContext.MaritalStatuses.FromSqlRaw("EXEC sp_GetMaritalStatus").AsNoTracking().ToListAsync(),
            BloodGroupList = await _appDbContext.BloodGroup.FromSqlRaw("EXEC dbo.sp_GetBloodGroups").AsNoTracking().ToListAsync(),
            DesignationsList = await _appDbContext.Designation.FromSqlRaw("Exec dbo.sp_GetDesignation").AsNoTracking().ToListAsync(),
            DepartmentList = await _appDbContext.Departments.FromSqlRaw("EXEC dbo.sp_GetDepartments").AsNoTracking().ToListAsync(),
            Grades = await _appDbContext.Grade.FromSqlRaw("EXEC dbo.sp_GetGrade").AsNoTracking().ToListAsync(),
            EmploymentStatusList = await _appDbContext.EmployeeStatus.FromSqlRaw("EXEC dbo.sp_GetEmployeeStatus").AsNoTracking().ToListAsync(),
            JobStatusList = await _appDbContext.JobStatus.FromSqlRaw("EXEC dbo.sp_GetJobStatus").AsNoTracking().ToListAsync()
        };
        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(EmployeeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.SurNameList = await _appDbContext.SurName.FromSqlRaw("EXEC dbo.sp_GetSurName").AsNoTracking().ToListAsync();
            model.NationalityList = await _appDbContext.Nationality.FromSqlRaw("EXEC sp_GetNationality").AsNoTracking().ToListAsync();
            model.SectionList = await _appDbContext.Sections.FromSqlRaw("EXEC dbo.sp_GetSection").AsNoTracking().ToListAsync();
            model.DepartmentLevelList = await _appDbContext.DepartmentLevels.FromSqlRaw("Exec dbo.sp_GetDepartmentLevel").AsNoTracking().ToListAsync();
            model.LevelPolicyList = await _appDbContext.LevelPolicie.FromSqlRaw("EXEC dbo.sp_GetLevelPolicy").AsNoTracking().ToListAsync();
            model.ReligionList = await _appDbContext.Religion.FromSqlRaw("EXEC sp_GetReligion").AsNoTracking().ToListAsync();
            model.GenderList = await _appDbContext.Gender.FromSqlRaw("EXEC dbo.sp_GetGender").AsNoTracking().ToListAsync();
            model.MaritalStatusList = await _appDbContext.MaritalStatuses.FromSqlRaw("EXEC sp_GetMaritalStatus").AsNoTracking().ToListAsync();
            model.BloodGroupList = await _appDbContext.BloodGroup.FromSqlRaw("EXEC dbo.sp_GetBloodGroups").AsNoTracking().ToListAsync();
            model.DesignationsList = await _appDbContext.Designation.FromSqlRaw("Exec dbo.sp_GetDesignation").AsNoTracking().ToListAsync();
            model.DepartmentList = await _appDbContext.Departments.FromSqlRaw("EXEC dbo.sp_GetDepartments").AsNoTracking().ToListAsync();
            model.Grades = await _appDbContext.Grade.FromSqlRaw("EXEC dbo.sp_GetGrade").AsNoTracking().ToListAsync();
            model.EmploymentStatusList = await _appDbContext.EmployeeStatus.FromSqlRaw("EXEC dbo.sp_GetEmployeeStatus").AsNoTracking().ToListAsync();
            model.JobStatusList = await _appDbContext.JobStatus.FromSqlRaw("EXEC dbo.sp_GetJobStatus").AsNoTracking().ToListAsync();
            return View(model);

        }

        var res = await _employeeInformation.GetById(model.Id);

            if (res != null && res.Id == model.Id)
            {
                res.Id = model.Id;
                res.EmployeeCode = model.EmployeeCode;
                res.FullName = model.FullName;
                res.FatherName = model.FatherName;
                res.ProfilePictureUrl = model.ProfilePictureUrl;
                res.OPRCode = model.OPRCode;
                res.DateOfBirth = model.DateOfBirth;
                res.DateOfLeaving = model.DateOfLeaving;
                res.ConfirmationDate = model.ConfirmationDate;
                res.IDExpiryDate = model.IDExpiryDate;
                res.JoiningDate = model.JoiningDate;
                res.CNIC = model.CNIC;
                res.Reason = model.Reason;
                res.IsAsstHOD = model.IsAsstHOD;
                res.IsHOD = model.IsHOD;
                var result = await _employeeInformation.UpdateEmployeeAsync(res);
            }
            else
            {
                await _employeeInformation.CreateEmployee(model);
                TempData["Success"] = "Employee added successfully";
            return View(model);
        }
        TempData["Success"] = "Employee Updated successfully";
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeList(
        string? officeLocation,  
        int? MaritalStatusId, 
        int? SectionId,
        int? DepartmentId, 
        int? religionId,
        int? JobStatusId,
        int PageNumber =1, 
        int PageSize =30,
        string sortDirection = "ASC"
        )
    {
        if (PageNumber < 1) PageNumber = 1;
        var employees = await _employeeInformation.GetEmployee(officeLocation, MaritalStatusId, SectionId, DepartmentId, religionId, JobStatusId, PageNumber, PageSize, sortDirection);
        ViewBag.ReligionList = await _appDbContext.Religion.FromSqlRaw("EXEC sp_GetReligion").AsNoTracking().ToListAsync();
        ViewBag.SelectedReligionId = religionId;
        ViewBag.MaritalStatusList = await _appDbContext.MaritalStatuses.FromSqlRaw("EXEC sp_GetMaritalStatus").AsNoTracking().ToListAsync();
        ViewBag.MaritalStatusSelectedId = MaritalStatusId;
        ViewBag.DepartmentList= await _appDbContext.Departments.FromSqlRaw("EXEC dbo.sp_GetDepartments").AsNoTracking().ToListAsync();
        ViewBag.DepartmentId = DepartmentId;
        ViewBag.SectionList = await _appDbContext.Sections.FromSqlRaw("EXEC dbo.sp_GetSection").AsNoTracking().ToListAsync();
        ViewBag.SectionId = SectionId;
        ViewBag.JobStatusList = await _appDbContext.JobStatus.FromSqlRaw("EXEC dbo.sp_GetJobStatus").AsNoTracking().ToListAsync();
        ViewBag.JobStatusSelectedId = JobStatusId;
        if (employees == null)
        {
            return View(employees);
        }
        return View(employees);
    }


    [HttpGet("{Id}")]
    public async Task<IActionResult> GetEmployee(int Id)
    {
        var employee = await _employeeInformation.GetById(Id);
        if (employee == null)
            return NotFound();

        var NewVm = new EmployeeViewModel
        {
            Id= employee.Id,
            OPRCode = employee.OPRCode,
            FatherName = employee.FatherName,
            FullName = employee.FullName,
            ProfilePictureUrl = employee.ProfilePictureUrl,
            OfficeLocation = employee.OfficeLocation,
            DateOfBirth = employee.DateOfBirth,
            DateOfLeaving = employee.DateOfLeaving,
            IDExpiryDate = employee.IDExpiryDate,
            JoiningDate = employee.JoiningDate,
            ConfirmationDate = employee.ConfirmationDate,
            Reason = employee.Reason,
            CNIC = employee.CNIC,
            IsAsstHOD = employee.IsAsstHOD,
            IsHOD = employee.IsHOD,
            SurNameList = await _appDbContext.SurName.FromSqlRaw("EXEC dbo.sp_GetSurName").AsNoTracking().ToListAsync(),
            NationalityList = await _appDbContext.Nationality.FromSqlRaw("EXEC sp_GetNationality").AsNoTracking().ToListAsync(),
            SectionList = await _appDbContext.Sections.FromSqlRaw("EXEC dbo.sp_GetSection").AsNoTracking().ToListAsync(),
            DepartmentLevelList = await _appDbContext.DepartmentLevels.FromSqlRaw("Exec dbo.sp_GetDepartmentLevel").AsNoTracking().ToListAsync(),
            LevelPolicyList = await _appDbContext.LevelPolicie.FromSqlRaw("EXEC dbo.sp_GetLevelPolicy").AsNoTracking().ToListAsync(),
            ReligionList = await _appDbContext.Religion.FromSqlRaw("EXEC sp_GetReligion").AsNoTracking().ToListAsync(),
            GenderList = await _appDbContext.Gender.FromSqlRaw("EXEC dbo.sp_GetGender").AsNoTracking().ToListAsync(),
            MaritalStatusList = await _appDbContext.MaritalStatuses.FromSqlRaw("EXEC sp_GetMaritalStatus").AsNoTracking().ToListAsync(),
            BloodGroupList = await _appDbContext.BloodGroup.FromSqlRaw("EXEC dbo.sp_GetBloodGroups").AsNoTracking().ToListAsync(),
            DesignationsList = await _appDbContext.Designation.FromSqlRaw("Exec dbo.sp_GetDesignation").AsNoTracking().ToListAsync(),
            DepartmentList = await _appDbContext.Departments.FromSqlRaw("EXEC dbo.sp_GetDepartments").AsNoTracking().ToListAsync(),
            Grades = await _appDbContext.Grade.FromSqlRaw("EXEC dbo.sp_GetGrade").AsNoTracking().ToListAsync(),
            EmploymentStatusList = await _appDbContext.EmployeeStatus.FromSqlRaw("EXEC dbo.sp_GetEmployeeStatus").AsNoTracking().ToListAsync(),
            JobStatusList = await _appDbContext.JobStatus.FromSqlRaw("EXEC dbo.sp_GetJobStatus").AsNoTracking().ToListAsync()
        };
        return View("CreateEmployee", NewVm);
    }
}