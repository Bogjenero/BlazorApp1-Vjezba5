using BlazorApp1.Data;

namespace BlazorApp1.Services
{
    public class EmployeesServicecs
    {
        AppDbContext _context;
        public EmployeesServicecs(AppDbContext? context)
        {
            _context = context;
        }
        public async Task<Employee> UpdateSongAsync(string id, Employee s)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return null;
            employee.FullName = s.FullName;
            employee.Department = s.Department;
            employee.Salary = s.Salary;
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task<Employee> InsertEmployeeAsync(Employee em)
        {
            _context.Employees.Add(em);
            await _context.SaveChangesAsync();
            return em;
        }
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var result = _context.Employees;
            return await Task.FromResult(result.ToList());
        }
        public async Task<Employee> GetEmployeesByIdAsync(string id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task<Employee> DeleteEmployeeAsync(string id)
        {
            var em = await _context.Employees.FindAsync(id);
            if (em == null)
                return null;
            _context.Employees.Remove(em);
            await _context.SaveChangesAsync();
            return em;
        }
    }
}
