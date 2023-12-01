using DatabaseInteraction.DatabaseConfiguration;
using DatabaseInteraction.Models.HumanResources;

namespace DatabaseInteraction.Services;

public class SqlDepartmentService
{
    private readonly DatabaseContext _dbContext = new DbContextFactory().CreateDbContext();

    public Department GetDepartmentById(int departmentId)
    {
        return _dbContext.Departments.FirstOrDefault(m => m.DepartmentId == departmentId)!;
    }

    public Department GetDepartmentByName(string name)
    {
        return _dbContext.Departments.FirstOrDefault(m => m.Name == name)!;
    }

    public void CreateDepartment(Department departmentToAdd)
    {
        _dbContext.Departments.Add(departmentToAdd);
        _dbContext.SaveChanges();
    }


    public Department? DeleteDepartmentRow(Department departmentToDelete)
    {
        _dbContext.Departments.Remove(departmentToDelete);
        _dbContext.SaveChanges();

        return _dbContext.Departments.FirstOrDefault(e => e.DepartmentId == departmentToDelete.DepartmentId);
    }

    public Department? UpdateDepartmentGroupName(Department departmentToUpdate, string departmentGroupName)
    {
        departmentToUpdate.GroupName = departmentGroupName;

        _dbContext.Departments.Update(departmentToUpdate);
        _dbContext.SaveChanges();

        return _dbContext.Departments.FirstOrDefault(e => e.DepartmentId == departmentToUpdate.DepartmentId);
    }
    
    public int GetDepartmentsAmount()
    {
        return _dbContext.Departments.Count();
    }
    
    public IQueryable<Department> GetDepartmentsAccordingDate(DateTime date)
    {
        return _dbContext.Departments.Where(e => e.ModifiedDate == date);
    }
    
    public IQueryable<Department> GetDepartmentsWhereNameStartsWithLetter(string name)
    {
        return _dbContext.Departments.Where(e => e.Name!.StartsWith(name));
    }
}