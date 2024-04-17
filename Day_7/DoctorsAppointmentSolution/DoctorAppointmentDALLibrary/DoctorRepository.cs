using DoctorAppointmentModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DoctorAppointmentDALLibrary
{
     public class DoctorRepository : IRepository<int, Doctor>
    {
        readonly Dictionary<int, Doctor> _doctor;

       public DoctorRepository()
       {
            _doctor = new Dictionary<int, Doctor>();

       }
        public List<Doctor> GetAll()
        {
            if (_doctor.Count == 0) return null;
            return _doctor.Values.ToList();
              
        }

        public Doctor GetById(int key)
        {
            return _doctor[key] ?? null;
        }
        int GenerateId()
        {
            if (_doctor.Count == 0) return 1;
            int id = _doctor.Keys.Max() + 1;
            return id;
        }

        public Doctor Add(Doctor item)
        {
            if (_doctor.ContainsValue(item)) return null;
            int id = GenerateId();
            _doctor[id] = item;
            return _doctor[id];
        }

        public Doctor Update(Doctor item)
        {
            if (_doctor.ContainsKey(item.Id) == false) return null;
            _doctor[item.Id] = item;
            return _doctor[item.Id];
        }

        public Doctor Delete(int key)
        {
            if (_doctor.ContainsKey(key) ==false) return null;
            Doctor RemovedDoc = _doctor[key];
            _doctor.Remove(key);
            return RemovedDoc;
        }
       

        
    }
}
