using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoftConsult.IGenericRepository;
using SoftConsult.Models;
using SoftConsult.ViewModel;
using System.Data;

namespace SoftConsult.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string _connectionString;

    public EmployeeRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<bool> CreateEmployeeAsync(Employee employeeInformation,string operation)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand command = new SqlCommand("dbo.sp_EmployeeCRUD", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Action", operation);
        command.Parameters.AddWithValue("@EmployeeCode", employeeInformation.EmployeeCode);
        command.Parameters.AddWithValue("@OPRCode", employeeInformation.OPRCode);
        command.Parameters.AddWithValue("@SurnameId", employeeInformation.SurnameId);
        command.Parameters.AddWithValue("@FatherName", employeeInformation.FatherName);
        command.Parameters.AddWithValue("@FullName", employeeInformation.FullName);
        command.Parameters.AddWithValue("@ProfilePictureUrl", employeeInformation.ProfilePictureUrl);
        command.Parameters.AddWithValue("@OfficeLocation", employeeInformation.OfficeLocation);
        command.Parameters.AddWithValue("@NationalityId", employeeInformation.NationalityId);
        command.Parameters.AddWithValue("@DateOfBirth", employeeInformation.DateOfBirth.ToDateTime(TimeOnly.MinValue));
        command.Parameters.AddWithValue("@CNIC", employeeInformation.CNIC);
        command.Parameters.AddWithValue("@IDExpiryDate", employeeInformation.IDExpiryDate.ToDateTime(TimeOnly.MinValue));
        command.Parameters.AddWithValue("@SectionId", employeeInformation.SectionId);
        command.Parameters.AddWithValue("@DepartmentId", employeeInformation.DepartmentId);
        command.Parameters.AddWithValue("@DesignationId", employeeInformation.DesignationId);
        command.Parameters.AddWithValue("@ReligionId", employeeInformation.ReligionId);
        command.Parameters.AddWithValue("@GenderId", employeeInformation.GenderId);
        command.Parameters.AddWithValue("@MaritalStatusId", employeeInformation.MaritalStatusId);
        command.Parameters.AddWithValue("@BloodGroupId", employeeInformation.BloodGroupId);
        command.Parameters.AddWithValue("@IsHOD", employeeInformation.IsHOD);
        command.Parameters.AddWithValue("@IsAsstHOD", employeeInformation.IsAsstHOD);
        command.Parameters.AddWithValue("@LeavePolicyCodeId", employeeInformation.LeavePolicyCodeId);
        command.Parameters.AddWithValue("@JoiningDate", employeeInformation.JoiningDate.ToDateTime(TimeOnly.MinValue));
        command.Parameters.AddWithValue("@EmploymentStatusId", employeeInformation.EmploymentStatusId);
        command.Parameters.AddWithValue("@JobStatusId", employeeInformation.JobStatusId);
        command.Parameters.AddWithValue("@ConfirmationDate",
            employeeInformation.ConfirmationDate.HasValue
                ? employeeInformation.ConfirmationDate.Value.ToDateTime(TimeOnly.MinValue)
                : DBNull.Value);

        command.Parameters.AddWithValue("@DateOfLeaving",
            employeeInformation.DateOfLeaving.HasValue
                ? employeeInformation.DateOfLeaving.Value.ToDateTime(TimeOnly.MinValue)
                : DBNull.Value);

        command.Parameters.AddWithValue("@Reason", employeeInformation.Reason);
        command.Parameters.AddWithValue("@GradeId", employeeInformation.GradeId);
        command.Parameters.AddWithValue("@DepartmentLevelId", employeeInformation.DepartmentLevelId);

        await connection.OpenAsync();

        int affectedRow = await command.ExecuteNonQueryAsync();
        return affectedRow > 0;
    }

    public async Task<Employee?> GetById(int Id,string operation)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand command = new SqlCommand("sp_EmployeeCRUD", connection);
        command.CommandType = CommandType.StoredProcedure;
        await connection.OpenAsync();
        command.Parameters.AddWithValue("@Action", operation);
        command.Parameters.AddWithValue("@Id", Id);
        using SqlDataReader reader = await command.ExecuteReaderAsync();
        if (!reader.HasRows) return null;
        await reader.ReadAsync();
        var employee = new Employee
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            EmployeeCode = reader.GetString(reader.GetOrdinal("EmployeeCode")),
            OPRCode = reader.GetString(reader.GetOrdinal("OPRCode")),
            SurnameId = reader.GetInt32(reader.GetOrdinal("SurnameId")),
            FatherName = reader.GetString(reader.GetOrdinal("FatherName")),
            FullName = reader.GetString(reader.GetOrdinal("FullName")),
            ProfilePictureUrl = reader.GetString(reader.GetOrdinal("ProfilePictureUrl")),
            OfficeLocation = reader.GetString(reader.GetOrdinal("OfficeLocation")),
            DepartmentId = reader.GetInt32(reader.GetOrdinal("DepartmentId")),
            Department = reader.GetString(reader.GetOrdinal("Department")),
            Nationality = reader.GetString(reader.GetOrdinal("Nationality")),
            NationalityId = reader.GetInt32(reader.GetOrdinal("NationalityId")),
            DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DateOfBirth"))),
            CNIC = reader.GetString(reader.GetOrdinal("CNIC")),
            IDExpiryDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("IDExpiryDate"))),
            SectionId = reader.GetInt32(reader.GetOrdinal("SectionId")),
            Section = reader.GetString(reader.GetOrdinal("Section")),
            DesignationId = reader.GetInt32(reader.GetOrdinal("DesignationId")),
            DesignationName = reader.GetString(reader.GetOrdinal("DesignationName")),
            ReligionId = reader.GetInt32(reader.GetOrdinal("ReligionId")),
            Religion = reader.GetString(reader.GetOrdinal("Religion")),
            GenderId = reader.GetInt32(reader.GetOrdinal("GenderId")),
            Gender = reader.GetString(reader.GetOrdinal("Gender")),
            MaritalStatusId = reader.GetInt32(reader.GetOrdinal("MaritalStatusId")),
            MaritalStatus = reader.GetString(reader.GetOrdinal("MaritalStatus")),
            BloodGroupId = reader.GetInt32(reader.GetOrdinal("BloodGroupId")),
            Group = reader.GetString(reader.GetOrdinal("Group")),
            IsHOD = reader.GetBoolean(reader.GetOrdinal("IsHOD")),
            IsAsstHOD = reader.GetBoolean(reader.GetOrdinal("IsAsstHOD")),
            LeavePolicyCodeId = reader.GetInt32(reader.GetOrdinal("LeavePolicyCodeId")),
            JoiningDate = DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("JoiningDate"))),
            EmploymentStatusId = reader.GetInt32(reader.GetOrdinal("EmploymentStatusId")),
            EmploymentStatus = reader.GetString(reader.GetOrdinal("EmploymentStatus")),
            JobStatusId = reader.GetInt32(reader.GetOrdinal("JobStatusId")),
            JobStatus = reader.GetString(reader.GetOrdinal("JobStatus")),
            ConfirmationDate = reader.IsDBNull(reader.GetOrdinal("ConfirmationDate"))
                ? null
                : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("ConfirmationDate"))),

            DateOfLeaving = reader.IsDBNull(reader.GetOrdinal("DateOfLeaving"))
                ? null
                : DateOnly.FromDateTime(reader.GetDateTime(reader.GetOrdinal("DateOfLeaving"))),
            Reason = reader.GetString(reader.GetOrdinal("Reason")),
            GradeId = reader.GetInt32(reader.GetOrdinal("GradeId")),
            EGrade = reader.GetString(reader.GetOrdinal("EGrade")),
            DepartmentLevelId = reader.GetInt32(reader.GetOrdinal("DepartmentLevelId")),
            LevelName = reader.GetString(reader.GetOrdinal("LevelName")),
        };
        return employee;
    }

    public async Task<bool> UpdateEmployeeAsync(Employee employeeInformation, string operation)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand command = new SqlCommand("dbo.sp_EmployeeCRUD", connection);
        command.CommandType = CommandType.StoredProcedure;
        await connection.OpenAsync();
        command.Parameters.AddWithValue("@Action", operation);
        command.Parameters.AddWithValue("@Id", employeeInformation.Id);
        command.Parameters.AddWithValue("@EmployeeCode", employeeInformation.EmployeeCode);
        command.Parameters.AddWithValue("@OPRCode", employeeInformation.OPRCode);
        command.Parameters.AddWithValue("@SurnameId", employeeInformation.SurnameId);
        command.Parameters.AddWithValue("@FatherName", employeeInformation.FatherName);
        command.Parameters.AddWithValue("@FullName", employeeInformation.FullName);
        command.Parameters.AddWithValue("@ProfilePictureUrl", employeeInformation.ProfilePictureUrl);
        command.Parameters.AddWithValue("@OfficeLocation", employeeInformation.OfficeLocation);
        command.Parameters.AddWithValue("@NationalityId", employeeInformation.NationalityId);
        command.Parameters.AddWithValue("@DateOfBirth", employeeInformation.DateOfBirth.ToDateTime(TimeOnly.MinValue));
        command.Parameters.AddWithValue("@CNIC", employeeInformation.CNIC);
        command.Parameters.AddWithValue("@IDExpiryDate", employeeInformation.IDExpiryDate.ToDateTime(TimeOnly.MinValue));
        command.Parameters.AddWithValue("@SectionId", employeeInformation.SectionId);
        command.Parameters.AddWithValue("@DepartmentId", employeeInformation.DepartmentId);
        command.Parameters.AddWithValue("@DesignationId", employeeInformation.DesignationId);
        command.Parameters.AddWithValue("@ReligionId", employeeInformation.ReligionId);
        command.Parameters.AddWithValue("@GenderId", employeeInformation.GenderId);
        command.Parameters.AddWithValue("@MaritalStatusId", employeeInformation.MaritalStatusId);
        command.Parameters.AddWithValue("@BloodGroupId", employeeInformation.BloodGroupId);
        command.Parameters.AddWithValue("@IsHOD", employeeInformation.IsHOD);
        command.Parameters.AddWithValue("@IsAsstHOD", employeeInformation.IsAsstHOD);
        command.Parameters.AddWithValue("@LeavePolicyCodeId", employeeInformation.LeavePolicyCodeId);
        command.Parameters.AddWithValue("@JoiningDate", employeeInformation.JoiningDate.ToDateTime(TimeOnly.MinValue));
        command.Parameters.AddWithValue("@EmploymentStatusId", employeeInformation.EmploymentStatusId);
        command.Parameters.AddWithValue("@JobStatusId", employeeInformation.JobStatusId);
        command.Parameters.AddWithValue("@ConfirmationDate",
            employeeInformation.ConfirmationDate.HasValue
                ? employeeInformation.ConfirmationDate.Value.ToDateTime(TimeOnly.MinValue)
                : DBNull.Value);
        command.Parameters.AddWithValue("@DateOfLeaving",
            employeeInformation.DateOfLeaving.HasValue
                ? employeeInformation.DateOfLeaving.Value.ToDateTime(TimeOnly.MinValue)
                : DBNull.Value);
        command.Parameters.AddWithValue("@Reason", employeeInformation.Reason);
        command.Parameters.AddWithValue("@GradeId", employeeInformation.GradeId);
        command.Parameters.AddWithValue("@DepartmentLevelId", employeeInformation.DepartmentLevelId);
        int affectedRow = await command.ExecuteNonQueryAsync();
        await connection.CloseAsync();
        return affectedRow > 0;
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
    string sortDirection,
    string operation)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand command = new SqlCommand("dbo.sp_EmployeeCRUD", connection);

        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Action", operation);
        command.Parameters.AddWithValue("@OfficeLocation", officeLocation ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@MaritalStatusId", MaritalStatusId ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@SectionId", SectionId ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@DepartmentId", DepartmentId ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@ReligionId", religionId ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@JobStatusId", jobStatusId ?? (object)DBNull.Value);
        command.Parameters.AddWithValue("@PageNumber", PageNumber);
        command.Parameters.AddWithValue("@PageSize", PageSize);
        command.Parameters.AddWithValue("@SortOrder", sortDirection);

        var totalRecordsParam = new SqlParameter("@TotalRecords", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        command.Parameters.Add(totalRecordsParam);

        await connection.OpenAsync();

        var employees = new List<EmployeeListViewModel>();

        using (SqlDataReader reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                employees.Add(new EmployeeListViewModel
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                    FatherName = reader.GetString(reader.GetOrdinal("FatherName")),
                    OfficeLocation = reader.GetString(reader.GetOrdinal("OfficeLocation")),
                    JobStatus = reader.GetString(reader.GetOrdinal("JobStatus")),
                    EGrade = reader.GetString(reader.GetOrdinal("EGrade")),
                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                    Religion = reader.GetString(reader.GetOrdinal("Religion")),
                    MaritalStatus = reader.GetString(reader.GetOrdinal("MaritalStatus"))
                });
            }
            reader.Close();
        }
        int totalRecords = totalRecordsParam.Value == DBNull.Value
    ? 0
    : Convert.ToInt32(totalRecordsParam.Value);
        return new PagedViewModel
        {
            Employees = employees,
            TotalRecords = totalRecords,
            PageNumber = PageNumber,
            PageSize = PageSize
        };
    }

    public async Task<List<SelectListItem>> Fill_Comb(int a)
    {
        List<SelectListItem> dropdownItems = new List<SelectListItem>();

        using SqlConnection connection = new SqlConnection(_connectionString);
        using SqlCommand command = new SqlCommand("dbo.Fill_Comb", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Action", a);

        await connection.OpenAsync();

        using SqlDataReader reader = await command.ExecuteReaderAsync();

        while (reader.Read())
        {
            dropdownItems.Add(new SelectListItem
            {
                Value = reader[0].ToString(),
                Text = reader[1].ToString()
            });
        }
        return dropdownItems;
    }
}