using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    internal class DepartementController
    {
        private Departement _ModelDepartement;
        private ViewDepartement _DepartementView;

        public DepartementController(Departement modelDepartement, ViewDepartement departementView)
        {
            _ModelDepartement = modelDepartement;
            _DepartementView = departementView;
        }
        public void getall()
        {
            var result = _ModelDepartement.getall();

            if(result.Count is 0)
            {
                _DepartementView.isempty();
            }
            else
            {
                _DepartementView.getall(result);
            }
        }
        public void getbyid()
        {
            var getid = _DepartementView.getbyid();
            var result = _ModelDepartement.getbyid(getid);

            _DepartementView.getoutput(result);
        }
        public void insert()
        {
            var data = _DepartementView.create();
            var result = _ModelDepartement.insert(data);

            switch (result)
            {
                case 0:
                    _DepartementView.error();
                    break;
                case -1:
                    _DepartementView.failure();
                    break;
                default:
                    _DepartementView.success();
                    break;
            }
        }
        public void update()
        {
            var data = _DepartementView.edit();
            var result = _ModelDepartement.update(data);

            switch (result)
            {
                case 0:
                    _DepartementView.error();
                    break;
                case -1:
                    _DepartementView.failure();
                    break;
                default:
                    _DepartementView.success();
                    break;
            }
        }
        public void delete()
        {
            var getid = _DepartementView.delete();
            var result = _ModelDepartement.delete(getid);

            switch (result)
            {
                case 0:
                    _DepartementView.error();
                    break;
                case -1:
                    _DepartementView.failure();
                    break;
                default:
                    _DepartementView.success();
                    break;
            }
        }
    }
}
