using System.Collections.Generic;

namespace Api.Application.ViewModels.Response
{
    public class ResponseMessages
    {
        public static IDictionary<ResponseStatusEnum, string> Messages = new Dictionary<ResponseStatusEnum, string>()
        {
            { ResponseStatusEnum.Error, "Internal server error" },
            { ResponseStatusEnum.Success, "Success" },
            { ResponseStatusEnum.NoModified, "Could not modify" },
            { ResponseStatusEnum.NotFound, "Not found" },
            { ResponseStatusEnum.BadRequest, "Verifique os campos informados" },
            { ResponseStatusEnum.Unprocessable, "Check the fields provided" },
            { ResponseStatusEnum.Forbidden, "User does not have permission" },
            { ResponseStatusEnum.Conflict, "Conflict" },
            { ResponseStatusEnum.Unauthorized, "Unauthorized access" }
        };
    }
}