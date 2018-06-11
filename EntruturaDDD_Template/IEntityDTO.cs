using System;

namespace TrocoBrq
{
    public interface IEntityDTO
    {
        Guid Id { get; set; }
        string CriadoPor { get; set; }
        DateTime? DataCriacao { get; set; }
        bool Active { get; set; }
    }
}
