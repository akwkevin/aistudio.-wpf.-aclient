using System;
using System.Collections.Generic;
using System.Text;

namespace AIStudio.Core.Models
{
    public enum ResponseCode
    {
        OK,//"#OK";
        FAILED,//"#Failed";

        //Server Side
        SERVER_VERSION_UNMATCHED,// "#ServerVersionUnmatched";
        SERVER_EXCEPTION,//"#ServerException";
        SERVER_UNKNOWN_MESSAGE_TYPE,// "#ServerUnknownMessageType";

        //Client Side
        CLIENT_INPUT_ERROR,//"#ClientInputError";
        CLIENT_EXCEPTION,// "#ClientException";
    }
}

