using DoctorAppointmentModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointmnet>
    {
        readonly Dictionary<int, Appointmnet> _appointment;

        public AppointmentRepository()
        {
            _appointment = new Dictionary<int, Appointmnet>();

        }
        public List<Appointmnet> GetAll()
        {
            if (_appointment.Count == 0) return null;
            return _appointment.Values.ToList();

        }

        public Appointmnet GetById(int key)
        {
            return _appointment[key] ?? null;
        }
        int GenerateId()
        {
            if (_appointment.Count == 0) return 1;
            int id = _appointment.Keys.Max() + 1;
            return id;
        }

        public Appointmnet Add(Appointmnet item)
        {
            if (_appointment.ContainsValue(item)) return null;
            int id = GenerateId();
            _appointment[id] = item;
            return _appointment[id];
        }

        public Appointmnet Update(Appointmnet item)
        {
            if (_appointment.ContainsKey(item.Id) == false) return null;
            _appointment[item.Id] = item;
            return _appointment[item.Id];
        }

        public Appointmnet Delete(int key)
        {
            if (_appointment.ContainsKey(key) == false) return null;
            Appointmnet RemovedDoc = _appointment[key];
            _appointment.Remove(key);
            return RemovedDoc;
        }



    }
}
