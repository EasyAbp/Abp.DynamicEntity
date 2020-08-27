using System;
using Volo.Abp.Application.Dtos;

namespace DynamicSample.Books.Dtos
{
    [Serializable]
    public class BookDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Author { get; set; }
    }
}