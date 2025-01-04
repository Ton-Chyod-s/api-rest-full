using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiarioOficial.CrossCutting.DTOs.OfficialDiary
{
    public record OfficialDiaryDTO
        (
            string Number,
            string Day,
            string File,
            string Description,
            long SessionId,
            long PersonId
        );

}
