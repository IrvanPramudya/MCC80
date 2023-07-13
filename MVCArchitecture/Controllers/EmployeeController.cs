using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    internal class EmployeeController
    {
        private Employee _ModelEmployee;
        private ViewEmployee _EmployeeView;
        
        public EmployeeController(Employee ModelEmployee, ViewEmployee EmployeeView)
        {
            _ModelEmployee = ModelEmployee;
            _EmployeeView = EmployeeView;
        }
        public void getall()
        {
            var result = _ModelEmployee.getall();

            if(result.Count == 0)
            {
                _EmployeeView.isempty();
            }
            else
            {
                _EmployeeView.getall(result);
            }
        }
        public void getbyid()
        {
            var getid = _EmployeeView.getbyid();
            var result = _ModelEmployee.getbyid(getid);

            _EmployeeView.getoutput(result);

        }
        public void insert()
        {
            var data = _EmployeeView.create();
            var result = _ModelEmployee.insert(data);

            switch (result)
            {
                case 0:
                    _EmployeeView.error();
                    break;
                case -1:
                    _EmployeeView.failure();
                    break;
                default:
                    _EmployeeView.success();
                    break;
            }

        }
        public void delete()
        {
            var getid = _EmployeeView.delete();
            var result = _ModelEmployee.delete(getid);

            switch (result)
            {
                case 0:
                    _EmployeeView.error();
                    break;
                case -1:
                    _EmployeeView.failure();
                    break;
                default:
                    _EmployeeView.success();
                    break;
            }
        }
        public void update()
        {
            var data = _EmployeeView.edit();
            var result = _ModelEmployee.update(data);

            switch (result)
            {
                case 0:
                    _EmployeeView.error();
                    break;
                case -1:
                    _EmployeeView.failure();
                    break;
                default:
                    _EmployeeView.success();
                    break;
            }
        }
    }
}
