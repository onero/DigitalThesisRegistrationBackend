using System;
using DTRDAL.Entities;
using DTRDAL.Repositories;
using DTRDAL.Repositories.Implementations;
using Xunit;

namespace DTRDALTests.Implementations
{
    public class AppendixRepositoryShould
    {
        private readonly IAppendixRepository _repository;

        public AppendixRepositoryShould()
        {
            _repository = new AppendixRepository();
        }

        [Fact]
        public void SaveAppendix()
        {
            var appendixToSave = new Appendix()
            {
                Condition = "Test",
                Resources = "Test"
            };
            var saved = _repository.Save(appendixToSave);
            Assert.True(saved);
        }

        [Fact]
        public void LoadExistingAppendix()
        {
            var appendixToSave = new Appendix()
            {
                Condition = "Test",
                Resources = "Test"
            };
            _repository.Save(appendixToSave);

            var loadedAppendix = _repository.Load();
            Assert.NotNull(loadedAppendix);
            Assert.Contains(appendixToSave.Condition, loadedAppendix.Condition);
            Assert.Contains(appendixToSave.Resources, loadedAppendix.Resources);
        }
    }
}