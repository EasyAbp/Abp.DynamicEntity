using System;
using System.Threading.Tasks;
using DynamicSample.Books;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace DynamicSample.EntityFrameworkCore.Books
{
    public class BookRepositoryTests : DynamicSampleEntityFrameworkCoreTestBase
    {
        private readonly IRepository<Book, Guid> _bookRepository;

        public BookRepositoryTests()
        {
            _bookRepository = GetRequiredService<IRepository<Book, Guid>>();
        }

        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
