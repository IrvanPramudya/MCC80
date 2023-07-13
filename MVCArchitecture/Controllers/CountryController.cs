using MVCArchitecture.Models;
using MVCArchitecture.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture.Controllers
{
    internal class CountryController
    {
        private Country _CountryModel;
        private ViewCountry _ViewCountry;

        public CountryController(Country countryModel, ViewCountry viewCountry)
        {
            _CountryModel = countryModel;
            _ViewCountry = viewCountry;
        }
        public void getall()
        {
            var result = _CountryModel.getall();
            if(result.Count is 0)
            {
                _ViewCountry.isempty();
            }
            else
            {
                _ViewCountry.getall(result);
            }
        }
        public void getbyid()
        {
            var getid = _ViewCountry.getbyid();
            var result = _CountryModel.getbyid(getid);

            _ViewCountry.getoutput(result);
        }
        public void insert()
        {
            var country = _ViewCountry.create();
            var result = _CountryModel.insert(country);

            switch (result)
            {
                case 0:
                    _ViewCountry.error();
                    break;
                case -1:
                    _ViewCountry.failure();
                    break;
                default:
                    _ViewCountry.success();
                    break;
            }
        }
        public void update()
        {
            var country = _ViewCountry.edit();
            var result = _CountryModel.update(country);

            switch (result)
            {
                case 0:
                    _ViewCountry.error();
                    break;
                case -1:
                    _ViewCountry.failure();
                    break;
                default:
                    _ViewCountry.success();
                    break;
            }
        }
        public void delete()
        {
            var getid = _ViewCountry.delete();
            var result = _CountryModel.delete(getid);

            switch (result)
            {
                case 0:
                    _ViewCountry.error();
                    break;
                case -1:
                    _ViewCountry.failure();
                    break;
                default:
                    _ViewCountry.success();
                    break;
            }
        }
    }
}
