using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoftConsult.Context;
using SoftConsult.IGenericRepository;
using SoftConsult.Models;
using SoftConsult.ViewModel;

namespace SoftConsult.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _appDbContext;
    public EmployeeRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<bool> CreateEmployeeAsync(Employee employeeInformation)
    {
        var Parametter = new[]
{
    new SqlParameter("@EmployeeCode", employeeInformation.EmployeeCode),
    new SqlParameter("@OPRCode", employeeInformation.OPRCode),
    new SqlParameter("@SurnameId", employeeInformation.SurnameId),
    new SqlParameter("@FatherName", employeeInformation.FatherName),
    new SqlParameter("@FullName", employeeInformation.FullName),
    new SqlParameter("@ProfilePictureUrl", employeeInformation.ProfilePictureUrl),
    new SqlParameter("@OfficeLocation", employeeInformation.OfficeLocation),
    new SqlParameter("@NationalityId", employeeInformation.NationalityId),
    new SqlParameter("@DateOfBirth", employeeInformation.DateOfBirth.ToDateTime(TimeOnly.MinValue)),
    new SqlParameter("@CNIC", employeeInformation.CNIC),
    new SqlParameter("@IDExpiryDate", employeeInformation.IDExpiryDate.ToDateTime(TimeOnly.MinValue)),
    new SqlParameter("@SectionId", employeeInformation.SectionId),
    new SqlParameter("@DepartmentId", employeeInformation.DepartmentId),
    new SqlParameter("@DesignationId", employeeInformation.DesignationId),
    new SqlParameter("@ReligionId", employeeInformation.ReligionId),
    new SqlParameter("@GenderId", employeeInformation.GenderId),
    new SqlParameter("@MaritalStatusId", employeeInformation.MaritalStatusId),
    new SqlParameter("@BloodGroupId", employeeInformation.BloodGroupId),
    new SqlParameter("@IsHOD", employeeInformation.IsHOD),
    new SqlParameter("@IsAsstHOD", employeeInformation.IsAsstHOD),
    new SqlParameter("@LeavePolicyCodeId", employeeInformation.LeavePolicyCodeId),
    new SqlParameter("@JoiningDate", employeeInformation.JoiningDate.ToDateTime(TimeOnly.MinValue)),
    new SqlParameter("@EmploymentStatusId", employeeInformation.EmploymentStatusId),
    new SqlParameter("@JobStatusId", employeeInformation.JobStatusId),
    new SqlParameter("@ConfirmationDate",
        employeeInformation.ConfirmationDate.HasValue
            ? employeeInformation.ConfirmationDate.Value.ToDateTime(TimeOnly.MinValue)
            : DBNull.Value),

    new SqlParameter("@DateOfLeaving",
        employeeInformation.DateOfLeaving.HasValue
            ? employeeInformation.DateOfLeaving.Value.ToDateTime(TimeOnly.MinValue)
            : DBNull.Value),

    new SqlParameter("@Reason", employeeInformation.Reason),
    new SqlParameter("@GradeId", employeeInformation.GradeId),
    new SqlParameter("@DepartmentLevelId", employeeInformation.DepartmentLevelId)
};
        var result = await _appDbContext.Database.ExecuteSqlRawAsync(
        @"EXEC dbo.sp_CreateEmployee
                @EmployeeCode = @EmployeeCode,
                @OPRCode = @OPRCode,
                @SurnameId = @SurnameId,
                @FatherName = @FatherName,
                @FullName = @FullName,
                @ProfilePictureUrl = @ProfilePictureUrl,
                @OfficeLocation = @OfficeLocation,
                @NationalityId = @NationalityId,
                @DateOfBirth = @DateOfBirth,
                @CNIC = @CNIC,
                @IDExpiryDate = @IDExpiryDate,
                @SectionId = @SectionId,
                @DepartmentId = @DepartmentId,
                @DesignationId = @DesignationId,
                @ReligionId = @ReligionId,
                @GenderId = @GenderId,
                @MaritalStatusId = @MaritalStatusId,
                @BloodGroupId = @BloodGroupId,
                @IsHOD = @IsHOD,
                @IsAsstHOD = @IsAsstHOD,
                @LeavePolicyCodeId = @LeavePolicyCodeId,
                @JoiningDate = @JoiningDate,
                @EmploymentStatusId = @EmploymentStatusId,
                @JobStatusId = @JobStatusId,
                @ConfirmationDate = @ConfirmationDate,
                @DateOfLeaving = @DateOfLeaving,
                @Reason = @Reason,
                @GradeId = @GradeId,
                @DepartmentLevelId = @DepartmentLevelId",
        Parametter);

        return result > 0;
    }

    public async Task<Employee?> GetById(int Id)
    {
        var employee =  _appDbContext.Employees
            .FromSqlRaw(
                "EXEC dbo.GetEmployeeById @Id",
                new SqlParameter("@Id", Id)
            )
            .AsNoTracking()
            .AsEnumerable()     
            .FirstOrDefault();
        
        return employee;       
    }

    public async Task<bool> UpdateEmployeeAsync(Employee employeeInformation)
    {
        var Parametter = new[]
    {
            new SqlParameter("@Id", employeeInformation.Id),
    new SqlParameter("@EmployeeCode", employeeInformation.EmployeeCode),
    new SqlParameter("@OPRCode", employeeInformation.OPRCode),
    new SqlParameter("@SurnameId", employeeInformation.SurnameId),
    new SqlParameter("@FatherName", employeeInformation.FatherName),
    new SqlParameter("@FullName", employeeInformation.FullName),
    new SqlParameter("@ProfilePictureUrl", employeeInformation.ProfilePictureUrl),
    new SqlParameter("@OfficeLocation", employeeInformation.OfficeLocation),
    new SqlParameter("@NationalityId", employeeInformation.NationalityId),
    new SqlParameter("@DateOfBirth", employeeInformation.DateOfBirth.ToDateTime(TimeOnly.MinValue)),
    new SqlParameter("@CNIC", employeeInformation.CNIC),
    new SqlParameter("@IDExpiryDate", employeeInformation.IDExpiryDate.ToDateTime(TimeOnly.MinValue)),
    new SqlParameter("@SectionId", employeeInformation.SectionId),
    new SqlParameter("@DepartmentId", employeeInformation.DepartmentId),
    new SqlParameter("@DesignationId", employeeInformation.DesignationId),
    new SqlParameter("@ReligionId", employeeInformation.ReligionId),
    new SqlParameter("@GenderId", employeeInformation.GenderId),
    new SqlParameter("@MaritalStatusId", employeeInformation.MaritalStatusId),
    new SqlParameter("@BloodGroupId", employeeInformation.BloodGroupId),
    new SqlParameter("@IsHOD", employeeInformation.IsHOD),
    new SqlParameter("@IsAsstHOD", employeeInformation.IsAsstHOD),
    new SqlParameter("@LeavePolicyCodeId", employeeInformation.LeavePolicyCodeId),
    new SqlParameter("@JoiningDate", employeeInformation.JoiningDate.ToDateTime(TimeOnly.MinValue)),
    new SqlParameter("@EmploymentStatusId", employeeInformation.EmploymentStatusId),
    new SqlParameter("@JobStatusId", employeeInformation.JobStatusId),
    new SqlParameter("@ConfirmationDate",
        employeeInformation.ConfirmationDate.HasValue
            ? employeeInformation.ConfirmationDate.Value.ToDateTime(TimeOnly.MinValue)
            : DBNull.Value),

    new SqlParameter("@DateOfLeaving",
        employeeInformation.DateOfLeaving.HasValue
            ? employeeInformation.DateOfLeaving.Value.ToDateTime(TimeOnly.MinValue)
            : DBNull.Value),

    new SqlParameter("@Reason", employeeInformation.Reason),
    new SqlParameter("@GradeId", employeeInformation.GradeId),
    new SqlParameter("@DepartmentLevelId", employeeInformation.DepartmentLevelId)
};
        var result = await _appDbContext.Database.ExecuteSqlRawAsync(
        @"EXEC dbo.UpdateEmployee
                @Id=@Id,
                @EmployeeCode = @EmployeeCode,
                @OPRCode = @OPRCode,
                @SurnameId = @SurnameId,
                @FatherName = @FatherName,
                @FullName = @FullName,
                @ProfilePictureUrl = @ProfilePictureUrl,
                @OfficeLocation = @OfficeLocation,
                @NationalityId = @NationalityId,
                @DateOfBirth = @DateOfBirth,
                @CNIC = @CNIC,
                @IDExpiryDate = @IDExpiryDate,
                @SectionId = @SectionId,
                @DepartmentId = @DepartmentId,
                @DesignationId = @DesignationId,
                @ReligionId = @ReligionId,
                @GenderId = @GenderId,
                @MaritalStatusId = @MaritalStatusId,
                @BloodGroupId = @BloodGroupId,
                @IsHOD = @IsHOD,
                @IsAsstHOD = @IsAsstHOD,
                @LeavePolicyCodeId = @LeavePolicyCodeId,
                @JoiningDate = @JoiningDate,
                @EmploymentStatusId = @EmploymentStatusId,
                @JobStatusId = @JobStatusId,
                @ConfirmationDate = @ConfirmationDate,
                @DateOfLeaving = @DateOfLeaving,
                @Reason = @Reason,
                @GradeId = @GradeId,
                @DepartmentLevelId = @DepartmentLevelId",
        Parametter);
        return result > 0;
    }

    public async Task<PagedViewModel> GetEmployee(
        string? officeLocation,
        int? DepartmentId, 
        int? MaritalStatusId, 
        int? SectionId,
        int? religionId, 
        int? jobStatusId, 
        int PageNumber, 
        int PageSize, 
        string sortDirection = "ASC")
    {
        var totalRecordsParam = new SqlParameter
        {
            ParameterName = "@TotalRecords",
            SqlDbType = System.Data.SqlDbType.Int,
            Direction = System.Data.ParameterDirection.Output
        };

        var employees = await _appDbContext.EmployeeList
            .FromSqlRaw(@"EXEC dbo.GetEmployees 
            @OfficeLocation,
            @MaritalStatusId,
            @SectionId,
            @DepartmentId,
            @ReligionId,
            @JobStatusId,
            @PageNumber,
            @PageSize,
            @SortOrder,
            @TotalRecords OUTPUT",
                new SqlParameter("@OfficeLocation", officeLocation ?? (object)DBNull.Value),
                new SqlParameter("@MaritalStatusId", MaritalStatusId ?? (object)DBNull.Value),
                new SqlParameter("@SectionId", SectionId ?? (object)DBNull.Value),
                new SqlParameter("@DepartmentId", DepartmentId ?? (object)DBNull.Value),
                new SqlParameter("@ReligionId", religionId ?? (object)DBNull.Value),
                new SqlParameter("@JobStatusId", jobStatusId ?? (object)DBNull.Value),
                new SqlParameter("@PageNumber", PageNumber),
                new SqlParameter("@PageSize", PageSize),
                new SqlParameter("@SortOrder", sortDirection),
                totalRecordsParam
            ).ToListAsync();

       int totalRecords = (int)totalRecordsParam.Value;
        return new PagedViewModel
        {
            Employees = employees,
            TotalRecords = totalRecords,
            PageNumber = PageNumber,
            PageSize = PageSize
        };
    }
}