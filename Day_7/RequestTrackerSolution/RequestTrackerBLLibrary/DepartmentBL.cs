﻿using RequestTrackerDALLibrary;
using ReqTrackerModellib;

namespace RequestTrackerBLLibrary
{
    public class DepartmentBL
    {
        readonly IRepository<int, Department> _departmentRepository;
        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

    }
}
