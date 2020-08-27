using System;
using System.ComponentModel;
namespace DynamicSample.Books.Dtos
{
    [Serializable]
    public class CreateUpdateBookDto
    {
        public string Name { get; set; }

        public string Author { get; set; }
    }
}