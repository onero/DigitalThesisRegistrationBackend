using System;
using DTRDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DTRDALTests.implementations
{
    public static class TestContext
    {
        /// <summary>
        /// Provide a random context for InMemory testing purposes
        /// </summary>
        public static DTRContext Context => new DTRContext(new DbContextOptionsBuilder<DTRContext>()
            .UseInMemoryDatabase($"{Guid.NewGuid()}")
            .Options);
    }
}