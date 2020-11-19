using System;

namespace test.mt.mediator.Components
{
    public interface ISiniestroAltaMedica
    {
        long SiniestroId { get; }
        DateTime FechaAltaMedica { get; set; }
    }

}