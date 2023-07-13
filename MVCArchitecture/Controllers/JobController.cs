using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    internal class JobController
    {
        private Job _ModelJob;
        private ViewJob _JobView;

        public JobController(Job modelJob, ViewJob jobView)
        {
            _ModelJob = modelJob;
            _JobView = jobView;
        }

        public void getall()
        {
            var result = _ModelJob.getall();

            if(result.Count == 0)
            {
                _JobView.isempty();
            }
            else
            {
                _JobView.getall(result);
            }
        }
        public void getbyid()
        {
            var getid = _JobView.getbyid();
            var result = _ModelJob.getbyid(getid);

            _JobView.getoutput(result);
        }
        public void insert()
        {
            var data = _JobView.create();
            var result = _ModelJob.insert(data);

            switch (result)
            {
                case 0:
                    _JobView.error();
                    break;
                case -1:
                    _JobView.failure();
                    break;
                default:
                    _JobView.success();
                    break;
            }
        }
        public void update()
        {
            var data = _JobView.edit();
            var result = _ModelJob.update(data);

            switch (result)
            {
                case 0:
                    _JobView.error();
                    break;
                case -1:
                    _JobView.failure();
                    break;
                default:
                    _JobView.success();
                    break;
            }
        }
        public void delete()
        {
            var getid = _JobView.delete();
            var result = _ModelJob.delete(getid);
            switch (result)
            {
                case 0:
                    _JobView.error();
                    break;
                case -1:
                    _JobView.failure();
                    break;
                default:
                    _JobView.success();
                    break;
            }
        }
    }
}
