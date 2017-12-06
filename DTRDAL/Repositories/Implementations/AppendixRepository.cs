using System;
using System.Diagnostics;
using System.IO;
using DTRDAL.Entities;

namespace DTRDAL.Repositories.Implementations
{
    internal class AppendixRepository : IAppendixRepository
    {
        private readonly string _location = Environment.CurrentDirectory;
        private readonly string _testFile = "appendix.txt";
        public Appendix Load()
        {
            using (var file = new StreamReader($"{_location}/{_testFile}"))
            {
                return new Appendix
                {
                    Condition = file.ReadLine(),
                    Resources = file.ReadLine()
                };
            }
        }

        public bool Save(Appendix appendix)
        {
            using (var file = new StreamWriter($"{_location}/{_testFile}"))
            {
                file.WriteLine(appendix.Condition);
                file.WriteLine(appendix.Resources);
            }
            return true;
        }
    }
}