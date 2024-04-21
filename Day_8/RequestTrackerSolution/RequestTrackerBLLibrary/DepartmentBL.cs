using RequestTrackerDALLibrary;
using ReqTrackerModellib;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL : IDepartmentService
    {
        readonly IRepository<int, Department> _departmentRepository;
        void ThrowingNullExeception(string text) 
        {
            throw new NullReferenceException($"The Department with given {text} doesn't exist");
        }
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var res = _departmentRepository.Add(department);
            if(res == null) 
            {
                throw new DuplicateObjectException("The Department Already Existed");
            }
            return department.Id;   
        }

        public Department ChangeDepartmentName( string departmentNewName, int id )
        {
            var department = _departmentRepository.GetById(id);
            if (department == null)  ThrowingNullExeception("id");
            department.Name = departmentNewName;
           return _departmentRepository.Update(department);
        }

        public Department GetDepartmentById(int id)
        {
            var deparment = _departmentRepository.GetById(id);
            if (deparment == null) ThrowingNullExeception("id");
            return deparment;
        }

        public Department GetDepartmentByName(string departmentName)
        {
               var departments = _departmentRepository.GetAll();
             Department department = null;
            if (departments == null) throw new Exception("There is no Departments Present");
            for(int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Name.ToLower() == departmentName.ToLower()) 
                {
                    department = departments[i];
                    break;
                }
            }
            if (department == null) ThrowingNullExeception("name");
            return department;

        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var department = _departmentRepository.GetById(departmentId);
            if (department == null) ThrowingNullExeception("id");
            return department.Department_Head;
            
        }
    }
}
