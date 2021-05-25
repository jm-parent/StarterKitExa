using System;
using System.Collections.Generic;
using System.Text;
using StarterKitApp.Services.Interfaces;

namespace StarterKitApp.Services
{
    public class SampleCalcService : ISampleCalcService
    {
        public int AddNumbers(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
