using Service.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface ITestService
    {
        List<TestViewModel> GetData();

        TestViewModel GetTestVM();

        int Create(TestEditViewModel model);

        void Update(TestEditViewModel model);

        void Delete(int id);
    }
}
